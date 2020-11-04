﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace SiUpin.WebUI.Common
{
    public class ServerAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public IEnumerable<Claim> _claims { get; private set; }

        public ServerAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public HttpClient Client() => _httpClient;

        public string GetParsedMemberUsername() => _claims.Select(x => x.Value).ToList()[0];

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Ambil Cookie dari Local Storage
            var savedToken = await GetTokenAsync();

            Console.WriteLine($"savedToken: {savedToken}");

            if (!string.IsNullOrEmpty(savedToken))
            {
                // Jangan dihapus dulu, kayanya bakalan kepake
                //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.Bearer, savedToken);

                _claims = ParseClaimsFromJwt(savedToken);

                var claimsIdentity = new ClaimsIdentity(_claims, Constants.AuthenticationType.ServerAuthentication);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                var authenticationState = new AuthenticationState(claimsPrincipal);

                return await Task.FromResult(authenticationState);
            }
            else
            {
                // Jangan dihapus dulu, kayanya bakalan kepake
                //_httpClient.DefaultRequestHeaders.Authorization = null;

                var claimsIdentity = new ClaimsIdentity();
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                var authenticationState = new AuthenticationState(claimsPrincipal);

                return await Task.FromResult(authenticationState);
            }
        }

        public async Task MarkUserAsAuthenticatedAsync(string token)
        {
            // Simpan token ke Local Storage
            await _localStorage.SetItemAsync(Constants.StorageKey.Token, token);

            // Extract isi token ke dalam IEnumerable of Claims
            _claims = ParseClaimsFromJwt(token);

            //Simpan IEnumerable of Claims ke Memory
            var claimsIdentity = new ClaimsIdentity(_claims, Constants.AuthenticationType.ServerAuthentication);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var authenticationState = new AuthenticationState(claimsPrincipal);
            var authenticationStateTask = Task.FromResult(authenticationState);
            NotifyAuthenticationStateChanged(authenticationStateTask);

            //Set DefaultRequestHeaders dengan token
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.Bearer, token);
        }

        public async Task MarkUserAsLoggedOutAsync()
        {
            // Hapus token dari Local Storage
            await _localStorage.RemoveItemAsync(Constants.StorageKey.Token);

            //Simpan ClaimsIdentity kosong ke Memory
            var claimsIdentity = new ClaimsIdentity();
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var authenticationState = new AuthenticationState(claimsPrincipal);
            var authenticationStateTask = Task.FromResult(authenticationState);
            NotifyAuthenticationStateChanged(authenticationStateTask);

            //Set DefaultRequestHeaders jadi null
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public async Task<string> GetTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>(Constants.StorageKey.Token);
        }
    }
}