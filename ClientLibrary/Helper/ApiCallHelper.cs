using ClientLibrary.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Helper
{
    public class ApiCallHelper : IApiCallHelper
    {
        public Task<HttpResponseMessage> ApiCallType<TModel>(ApiCall apiCall)
        {
            try
            {
                switch(apiCall.Type)
                {
                    case Constants.ApiCallType.Post:
                        return apiCall.Client!.PostAsJsonAsync(apiCall.Route,(TModel) apiCall.Model!);
                    case Constants.ApiCallType.Get:
                        string idRoute = apiCall.Id !=null ? $"{apiCall.Id}": null!;
                        return apiCall.Client!.GetAsync($"{apiCall.Route}/{idRoute}");
                        case Constants.ApiCallType.Put:
                        return apiCall.Client!.PutAsJsonAsync(apiCall.Route, (TModel)apiCall.Model!);
                    case Constants.ApiCallType.Delete:
                        return apiCall.Client!.DeleteAsync($"{apiCall.Route}/{apiCall.Id}");
                    default:
                        throw new Exception("Invalid Api Call Type");
                }

            }
            catch (Exception)
            {

                return null!;
            }
        }

        public ServiceResponse ConnectionError()
        {
            return new ServiceResponse(Message: "Error occured in comunicating to the server");
        }

        public async Task<TResponse> GetServiceResponse<TResponse>(HttpResponseMessage message)
        {
           var response = await message.Content.ReadFromJsonAsync<TResponse>();
            return response!;
        }
    }
}
