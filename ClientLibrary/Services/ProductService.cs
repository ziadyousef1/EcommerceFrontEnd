using ClientLibrary.Helper;
using ClientLibrary.Models;

namespace ClientLibrary.Services
{
    public class ProductService(IHttpClienthelper httpCLient, IApiCallHelper apihelper) : IProductService
    {
        public async Task<ServiceResponse> AddAsync(CreateProduct product)
        {
            var client = await httpCLient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constants.Product.Create,
                Type = Constants.ApiCallType.Post,
                Model = product,
                Client = client,
                Id = null!
            };
            var response = await apihelper.ApiCallType<CreateProduct>(apiCall);
            return response == null ? apihelper.ConnectionError() : await apihelper.GetServiceResponse<ServiceResponse>(response);
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            var client = await httpCLient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constants.Product.Delete,
                Type = Constants.ApiCallType.Delete,
                Model = null,
                Client = client,
            };
            apiCall.ToString(id);
            var response = await apihelper.ApiCallType<Dummy>(apiCall);
            return response == null ? apihelper.ConnectionError() : await apihelper.GetServiceResponse<ServiceResponse>(response);
        }

        public async Task<List<GetProduct>> GetAllAsync()
        {
            var client = httpCLient.GetPublicClient();
            var apiCall = new ApiCall
            {
                Route = Constants.Product.GetAll,
                Type = Constants.ApiCallType.Get,
                Client = client,
                Model = null!,
                Id = null!
            };
            var response = await apihelper.ApiCallType<List<GetProduct>>(apiCall);
            return response == null ? new List<GetProduct>() : await apihelper.GetServiceResponse<List<GetProduct>>(response);
        }

        public async Task<GetProduct> GetByIdAsync(Guid id)
        {
            var client = httpCLient.GetPublicClient();
            var apiCall = new ApiCall
            {
                Route = Constants.Product.Get,
                Type = Constants.ApiCallType.Get,
                Client = client,
                Model = null!,
            };
            apiCall.ToString(id);
            var response = await apihelper.ApiCallType<GetProduct>(apiCall);
            return response == null ? null! : await apihelper.GetServiceResponse<GetProduct>(response);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
        {
            var client = await httpCLient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constants.Product.Update,
                Type = Constants.ApiCallType.Put,
                Model = product,
                Client = client,
            };
            var response = await apihelper.ApiCallType<ServiceResponse>(apiCall);
            return response == null ? apihelper.ConnectionError() : await apihelper.GetServiceResponse<ServiceResponse>(response);
        }
    }
}
