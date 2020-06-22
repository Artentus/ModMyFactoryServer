//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using ModMyFactory.BaseTypes;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

namespace ModMyFactoryServer.Data
{
    internal interface IInstanceService : INotifyPropertyChanged
    {
        bool IsInstanceInstalled { get; }

        AccurateVersion? InstanceVersion { get; }

        bool IsInstanceRunning { get; }

        Task SendCommand(string command);

        Task StartInstanceAsync(string savegame, DirectoryInfo? modDirectory = null, params string[] arguments);

        Task StopInstanceAsync();

        Task UpdateInstanceAsync(AccurateVersion targetVersion, bool isExperimental);
    }
}
