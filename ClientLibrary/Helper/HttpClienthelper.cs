using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Helper
{
    public class HttpClienthelper(IHttpClientFactory clientFactory, ITokenService tokenService) : IHttpClienthelper
    {
        public async Task<HttpClient> GetPrivateClientAsync()
        {
            var client = clientFactory.CreateClient(Constants.ApiClient.Name);
            string token = await tokenService.GetJwtTokenAsync(Constants.Cookie.Name);
            if (string.IsNullOrEmpty(token))
                return client;
           
            client.DefaultRequestHeaders.Authorization = new 
                AuthenticationHeaderValue(Constants.Authentication.Type, token);
            return client;



        }

        public HttpClient GetPublicClient()
        {
           return clientFactory.CreateClient(Constants.ApiClient.Name);
        }
    }
}
