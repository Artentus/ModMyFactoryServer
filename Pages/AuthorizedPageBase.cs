//  Copyright (C) 2020 Mathis Rech
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ModMyFactoryServer.Pages
{
    // Base for all pages that require authentication
    public abstract class AuthorizedPageBase : ComponentBase
    {
        // Store user for derived classes
        protected IdentityUser? User { get; private set; }

#pragma warning disable CS8618

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public UserManager<IdentityUser> UserManager { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; }

#pragma warning restore CS8618

        private async Task<bool> CheckAuthenticationStateAsync(Task<AuthenticationState> task)
        {
            var authState = await task;
            var user = authState.User;
            User = await UserManager.GetUserAsync(user);

            return user.Identity.IsAuthenticated;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            // If the user is not authenticated we redirect directly to the login page
            bool isAuthenticated = await CheckAuthenticationStateAsync(AuthenticationStateTask);
            if (!isAuthenticated) NavigationManager.NavigateTo("/login");
        }
    }
}
