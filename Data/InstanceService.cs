//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using ModMyFactory.BaseTypes;
using ModMyFactory.Game;
using ModMyFactory.Server;
using ModMyFactory.WebApi.Factorio;
using ModMyFactoryServer.Helpers;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ModMyFactoryServer.Data
{
    internal sealed class InstanceService : IInstanceService
    {
        private IFactorioInstance? _instance;
        private bool _isInstanceRunning;
        private Process? _instanceProcess;

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool IsInstanceInstalled => !(_instance is null);

        public AccurateVersion? InstanceVersion => _instance?.Version;

        public bool IsInstanceRunning
        {
            get => _isInstanceRunning;
            private set
            {
                if (value != _isInstanceRunning)
                {
                    _isInstanceRunning = value;
                    RaisePropertyChanged(nameof(IsInstanceRunning));
                }
            }
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e)
            => PropertyChanged?.Invoke(this, e);

        private void RaisePropertyChanged(string propertyName)
            => OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

        private bool CheckSavegameExists(IFactorioInstance instance, string savegame, [MaybeNullWhen(false)] out FileInfo file)
        {
            var relative = new FileInfo(Path.Combine(instance.SavegameDirectory.FullName, savegame));
            var absolute = new FileInfo(savegame);

            if (relative.Exists)
            {
                file = relative;
                return true;
            }

            if (absolute.Exists)
            {
                file = absolute;
                return true;
            }

            file = null;
            return false;
        }

        private async Task WaitForGameStarted(StreamReader reader)
        {
            string logText = string.Empty;
            while (true)
            {
                logText += await reader.ReadToEndAsync();
                // Ugly hardcoded string-comparison, but there doesn't seem to be another way
                if (logText.Contains("changing state from(CreatingGame) to(InGame)")) break;
                await Task.Delay(100);
            }
        }

        public Task SendCommand(string command)
        {
            throw new NotImplementedException();
        }

        public async Task StartInstanceAsync(string savegame, DirectoryInfo? modDirectory = null, params string[] arguments)
        {
            if (_instance is null) throw new InvalidOperationException("Instance is not installed");
            if (IsInstanceRunning) throw new InvalidOperationException("Instance is already running");
            if (string.IsNullOrEmpty(savegame)) throw new ArgumentNullException(nameof(savegame));
            if (!CheckSavegameExists(_instance, savegame, out var savegameFile)) throw new ArgumentException("Specified savegame does not exist");

            var startOptions = new ServerStartOptions();
            _instanceProcess = _instance.StartServer(savegameFile, startOptions, modDirectory, arguments);

            var logFile = new FileInfo(Path.Combine(_instance.Directory.FullName, "factorio-current.log"));
            await logFile.WaitForCreationAsync();

            using var fs = logFile.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = new StreamReader(fs, Encoding.UTF8);
            await WaitForGameStarted(reader);

            // ToDo: open Rcon

            IsInstanceRunning = true;
        }

        public async Task StopInstanceAsync()
        {
            if (_instance is null) throw new InvalidOperationException("Instance is not installed");
            if (!IsInstanceRunning || (_instanceProcess is null)) throw new InvalidOperationException("Instance is not running");

            await SendCommand("/quit");

            // ToDo: close Rcon

            await _instanceProcess.WaitForExitAsync();

            _instanceProcess = null;
            IsInstanceRunning = false;
        }

        public async Task UpdateInstanceAsync(AccurateVersion targetVersion, bool isExperimental)
        {
            if (IsInstanceRunning) throw new InvalidOperationException("Instance cannot be updated while it is running");

            if (_instance is null)
            {
                // Download a fresh instance
                var tempFile = await DownloadApi.DownloadReleaseAsync(targetVersion, FactorioBuild.Headless, Platform.Linux64, null, null, "factorio.tmp");
            }
            else
            {
                // Update existing instance
            }
        }
    }
}
