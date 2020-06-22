//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using System.Diagnostics;
using System.Threading.Tasks;

namespace ModMyFactoryServer.Helpers
{
    internal static class ProcessExtensions
    {
        public static async Task WaitForExitAsync(this Process process)
        {
            while (!process.HasExited)
                await Task.Delay(100);
        }
    }
}
