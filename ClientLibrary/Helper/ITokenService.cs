using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Helper
{
    public interface ITokenService
    {
        Task<string> GetJwtTokenAsync(string key);   
        Task<string> GetRefreshTokenAsync(string key);
        string FormToken(string jwt,string refresh);
        Task SetCookie(string key, string value,int days,string path);
        Task RemoveCookie(string key);

    }
}
