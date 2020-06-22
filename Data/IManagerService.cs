//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using ModMyFactory;
using ModMyFactory.Mods;
using System.Collections.Generic;

namespace ModMyFactoryServer.Data
{
    internal interface IManagerService
    {
        ModManager Manager { get; }

        IReadOnlyCollection<Modpack> Modpacks { get; }

        Modpack CreateModpack();

        bool RemoveModpack(Modpack modpack);
    }
}
