//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using ModMyFactory.BaseTypes;
using ModMyFactory.WebApi.Factorio;
using System.Threading.Tasks;

namespace ModMyFactoryServer.Data
{
    internal sealed class ApiService : IApiService
    {
        public async Task<(AccurateVersion? stable, AccurateVersion? experimental)> GetLatestFactorioVersionsAsync()
        {
            var info = await DownloadApi.GetReleasesAsync();
            bool hasStable = info.stable.TryGetValue(FactorioBuild.Headless, out var stable);
            bool hasExp = info.experimental.TryGetValue(FactorioBuild.Headless, out var exp);
            return (hasStable ? (AccurateVersion?)stable : null, hasExp ? (AccurateVersion?)exp : null);
        }
    }
}
