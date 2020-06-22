//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using Microsoft.AspNetCore.Identity;

namespace ModMyFactoryServer
{
    public static class IdentityResultCode
    {
        public const string ConcurrencyFailure = nameof(IdentityErrorDescriber.ConcurrencyFailure);
        public const string Default = nameof(IdentityErrorDescriber.DefaultError);
        public const string DuplicateEmail = nameof(IdentityErrorDescriber.DuplicateEmail);
        public const string DuplicateRoleName = nameof(IdentityErrorDescriber.DuplicateRoleName);
        public const string DuplicateUserName = nameof(IdentityErrorDescriber.DuplicateUserName);
        public const string InvalidEmail = nameof(IdentityErrorDescriber.InvalidEmail);
        public const string InvalidRoleName = nameof(IdentityErrorDescriber.InvalidRoleName);
        public const string InvalidToken = nameof(IdentityErrorDescriber.InvalidToken);
        public const string InvalidUserName = nameof(IdentityErrorDescriber.InvalidUserName);
        public const string LoginAlreadyAssociated = nameof(IdentityErrorDescriber.LoginAlreadyAssociated);
        public const string PasswordMismatch = nameof(IdentityErrorDescriber.PasswordMismatch);
        public const string PasswordRequiresDigit = nameof(IdentityErrorDescriber.PasswordRequiresDigit);
        public const string PasswordRequiresLower = nameof(IdentityErrorDescriber.PasswordRequiresLower);
        public const string PasswordRequiresNonAlphanumeric = nameof(IdentityErrorDescriber.PasswordRequiresNonAlphanumeric);
        public const string PasswordRequiresUniqueChars = nameof(IdentityErrorDescriber.PasswordRequiresUniqueChars);
        public const string PasswordRequiresUpper = nameof(IdentityErrorDescriber.PasswordRequiresUpper);
        public const string PasswordTooShort = nameof(IdentityErrorDescriber.PasswordTooShort);
        public const string RecoveryCodeRedemptionFailed = nameof(IdentityErrorDescriber.RecoveryCodeRedemptionFailed);
        public const string UserAlreadyHasPassword = nameof(IdentityErrorDescriber.UserAlreadyHasPassword);
        public const string UserAlreadyInRole = nameof(IdentityErrorDescriber.UserAlreadyInRole);
        public const string UserLockoutNotEnabled = nameof(IdentityErrorDescriber.UserLockoutNotEnabled);
        public const string UserNotInRole = nameof(IdentityErrorDescriber.UserNotInRole);
    }
}
