using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Authentication;
using ClientLibrary.Models.Category;
using System.Web;

namespace ClientLibrary.Services
{
    public class AuthenticationService(IApiCallHelper apiHelper,IHttpClienthelper clientHelper) : IAuthenticationService
    {
        public async Task<ServiceResponse> CreateUser(CreateUser user)
        {
            var client = await clientHelper.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constants.Authentication.Register,
                Type = Constants.ApiCallType.Post,
                Model = user,
                Client = client,
                Id = null!


            };
            var response = await apiHelper.ApiCallType<CreateUser>(apiCall);

            return response == null ? apiHelper.ConnectionError() : await apiHelper.GetServiceResponse<ServiceResponse>(response);
        }

        public async Task<LoginResponse> Login(LoginUser user)
        {
            var client = await clientHelper.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constants.Authentication.Login,
                Type = Constants.ApiCallType.Post,
                Model = user,
                Client = client,
                Id = null!


            };
            var response = await apiHelper.ApiCallType<LoginUser>(apiCall);

            return response == null ? new LoginResponse(Message: apiHelper.ConnectionError().Message)
                : await apiHelper.GetServiceResponse<LoginResponse>(response);
        }

        public async Task<LoginResponse> RefreshToken(string token)
        {
            var client = clientHelper.GetPublicClient();
            var apiCall = new ApiCall
            {
                Route = Constants.Authentication.RefreshToken,
                Type = Constants.ApiCallType.Get,
                Client = client,
                Model = null!,
                Id = HttpUtility.UrlDecode(token)
            };
            var response = await apiHelper.ApiCallType<Dummy>(apiCall);
            return response == null ? null : await apiHelper.GetServiceResponse<LoginResponse>(response);
        }
    }
}
