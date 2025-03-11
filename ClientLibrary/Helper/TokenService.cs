using NetcodeHub.Packages.WebAssembly.Storage.Cookie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Helper
{
    public class TokenService(IBrowserCookieStorageService cookieService) : ITokenService
    {
        public string FormToken(string jwt, string refresh)
        {
            return $"{jwt}.{refresh}";
        }

        public async Task<string> GetJwtTokenAsync(string key)
        {
           return await GetTokenAsync(key,0);

        }

        public async Task<string> GetRefreshTokenAsync(string key)
        {
            return await GetTokenAsync(key, 1);
        }

        private async Task<string> GetTokenAsync(string key, int postion)
        {
            try
            {
                string token = await cookieService.GetAsync(key);
                return token !=null ? token.Split('.')[postion]:null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task RemoveCookie(string key)
        {
            await cookieService.RemoveAsync(key);
        }

        public async Task SetCookie(string key, string value, int days, string path)
        {
           await cookieService.SetAsync(key, value, days, path);
        }
    }
}
