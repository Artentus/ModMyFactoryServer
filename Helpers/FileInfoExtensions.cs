//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using System.IO;
using System.Threading.Tasks;

namespace ModMyFactoryServer.Helpers
{
    internal static class FileInfoExtensions
    {
        public static async Task WaitForCreationAsync(this FileInfo file)
        {
            while (!file.Exists)
                await Task.Delay(100);
        }
    }
}
