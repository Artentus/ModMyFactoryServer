//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

namespace ModMyFactoryServer.Data
{
    internal sealed class SettingService : ISettingService
    {
        private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.All // This is ok because the JSON never leaves the server
        };

        private readonly FileInfo _settingsFile;
        private readonly Dictionary<string, object> _values;

        public SettingService()
        {
            _settingsFile = new FileInfo("settings.json");
            if (_settingsFile.Exists)
            {
                try
                {
                    var json = File.ReadAllText(_settingsFile.FullName);
                    var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json, _jsonSettings);
                    _values = result ?? new Dictionary<string, object>();
                }
                catch (JsonSerializationException)
                {
                    _values = new Dictionary<string, object>();
                }
            }
            else
            {
                _values = new Dictionary<string, object>();
            }
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(_values, _jsonSettings);
            File.WriteAllText(_settingsFile.FullName, json);
        }

        public Task SaveAsync()
        {
            var json = JsonConvert.SerializeObject(_values, _jsonSettings);
            return File.WriteAllTextAsync(_settingsFile.FullName, json);
        }

        public T Get<T>(string key) where T : notnull => (T)_values[key];

        public void Set<T>(string key, T value) where T : notnull => _values[key] = value;

        public bool TryGet<T>(string key, [MaybeNullWhen(false)] out T result) where T : notnull
        {
            var exists = _values.TryGetValue(key, out var obj);

            if (exists)
            {
                if (obj is null)
                {
                    // Invalid state
                    _values.Remove(key);
                    result = default;
                    return false;
                }
                else
                {
                    result = (T)obj;
                    return true;
                }

            }
            else
            {
                result = default;
                return false;
            }
        }
    }
}
