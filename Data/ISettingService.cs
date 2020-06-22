//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace ModMyFactoryServer.Data
{
    internal interface ISettingService
    {
        bool TryGet<T>(string key, [MaybeNullWhen(false)] out T result) where T : notnull;

        T Get<T>(string key) where T : notnull;

        void Set<T>(string key, T value) where T : notnull;

        void Save();

        Task SaveAsync();
    }

    internal static class SettingServiceExtensions
    {
        public static T Get<T>(this ISettingService service, string key, T defaultValue) where T : notnull
        {
            if (service.TryGet(key, out T result)) return result;
            return defaultValue;
        }
    }
}
