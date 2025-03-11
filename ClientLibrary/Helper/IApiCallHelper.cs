using ClientLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Helper
{
    public interface IApiCallHelper
    {
        Task<HttpResponseMessage> ApiCallType<TModel>(ApiCall apiCall);
        Task<TResponse> GetServiceResponse<TResponse>(HttpResponseMessage message);
        ServiceResponse ConnectionError();
    }
}
