using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Services;
using System.Net;

namespace BlazorWasm.Authentication
{
    public class RefreshTokenHandler(ITokenService tokenService,IHttpClienthelper clienthelper
        ,IAuthenticationService authenticationService):DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isPost = request.Equals(HttpMethod.Post);
            bool isPut = request.Equals(HttpMethod.Put);
            bool isDelete = request.Equals(HttpMethod.Delete);
            var result = await base.SendAsync(request, cancellationToken);
            if(isPost || isPut || isDelete)
            {
                if (result.StatusCode != HttpStatusCode.Unauthorized)
                        return result;
                var refreshToken = await tokenService.GetRefreshTokenAsync(Constants.Cookie.Name);
                if (string.IsNullOrEmpty(refreshToken))
                    return result;
                var loginResponse = await MakeApiCall(refreshToken);
                if (loginResponse == null)
                    return result;
                await clienthelper.GetPrivateClientAsync();

            return await base.SendAsync(request, cancellationToken);

            }
            return result;
        }

        private async Task<LoginResponse> MakeApiCall(string refreshToken)
        {
            var result = await authenticationService.RefreshToken(refreshToken);
            if(result.IsSuccess)

            {
                string cookievalue = tokenService.FormToken(result.Token, result.RefreshToken);
                await tokenService.RemoveCookie(Constants.Cookie.Name);
                await tokenService.SetCookie
                    (Constants.Cookie.Name, 
                    cookievalue,
                    Constants.Cookie.Days,
                    Constants.Cookie.Path);

                return result;

            }
            return null;
        }
    }
}
