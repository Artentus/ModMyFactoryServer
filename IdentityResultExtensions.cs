//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace ModMyFactoryServer
{
    public static class IdentityResultExtensions
    {
        public static bool IsDuplicateUsername(this IdentityResult result)
            => result.Errors.Any(error => error.Code == IdentityResultCode.DuplicateUserName);

        public static bool IsPasswordInvalid(this IdentityResult result)
            => result.Errors.Any(error => error.Code == IdentityResultCode.PasswordMismatch);

        public static bool IsPasswordPolicyViolation(this IdentityResult result)
            => result.Errors.Any(error =>
               (error.Code == IdentityResultCode.PasswordRequiresDigit)
            || (error.Code == IdentityResultCode.PasswordRequiresLower)
            || (error.Code == IdentityResultCode.PasswordRequiresNonAlphanumeric)
            || (error.Code == IdentityResultCode.PasswordRequiresUniqueChars)
            || (error.Code == IdentityResultCode.PasswordRequiresUpper)
            || (error.Code == IdentityResultCode.PasswordTooShort));
    }
}
