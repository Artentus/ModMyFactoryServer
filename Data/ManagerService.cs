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
    internal sealed class ManagerService : IManagerService
    {
        public ModManager Manager => throw new System.NotImplementedException();

        public IReadOnlyCollection<Modpack> Modpacks => throw new System.NotImplementedException();

        public Modpack CreateModpack()
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveModpack(Modpack modpack)
        {
            throw new System.NotImplementedException();
        }
    }
}
