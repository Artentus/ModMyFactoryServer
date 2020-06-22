//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using ModMyFactory.BaseTypes;
using System.Threading.Tasks;

namespace ModMyFactoryServer.Data
{
    internal interface IApiService
    {
        Task<(AccurateVersion? stable, AccurateVersion? experimental)> GetLatestFactorioVersionsAsync();
    }
}
