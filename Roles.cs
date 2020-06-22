//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using System.Collections.Generic;

namespace ModMyFactoryServer
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";

        public static IEnumerable<string> Enumerate()
        {
            yield return Admin;
            yield return User;
        }
    }
}
