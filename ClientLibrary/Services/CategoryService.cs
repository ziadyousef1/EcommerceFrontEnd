using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Category;

namespace ClientLibrary.Services
{
    public class CategoryService (IHttpClienthelper httpCLient,IApiCallHelper apihelper): ICategoryService
    {
        public async Task<ServiceResponse> AddAsync(CreateCategory category)
        {
           var client = await httpCLient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constants.Category.Create,
                Type = Constants.ApiCallType.Post,
                Model = category,
                Client = client,
                Id=null!


            };
            var response = await apihelper.ApiCallType<CreateCategory>(apiCall);
           
            return response == null ? apihelper.ConnectionError() : await apihelper.GetServiceResponse<ServiceResponse>(response);
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            var client = await httpCLient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constants.Category.Delete,
                Type = Constants.ApiCallType.Delete,
                Model = null,
                Client = client,
               


            };
            apiCall.ToString(id);
            var response = await apihelper.ApiCallType<Dummy>(apiCall);

            return response == null ? apihelper.ConnectionError() : await apihelper.GetServiceResponse<ServiceResponse>(response);
        }

        public async Task<List<GetCategory>> GetAllAsync()
        {
            var client = httpCLient.GetPublicClient();
            var apiCall = new ApiCall
            {
                Route = Constants.Category.GetAll,
                Type = Constants.ApiCallType.Get,
                Client = client,
                Model = null!,
                Id = null!
            };
            var response = await apihelper.ApiCallType<List<GetCategory>>(apiCall);
            return response == null ? [] :await apihelper.GetServiceResponse<List<GetCategory>>(response);
        }

        public async Task<GetCategory> GetByIdAsync(Guid id)
        {
            var client = httpCLient.GetPublicClient();
            var apiCall = new ApiCall
            {
                Route = Constants.Category.Get,
                Type = Constants.ApiCallType.Get,
                Client = client,
                Model = null!,
               
            };
            apiCall.ToString(id);
            var response = await apihelper.ApiCallType<GetCategory>(apiCall);
            return response == null ? null! : await apihelper.GetServiceResponse<GetCategory>(response);
        }

        public async Task<IEnumerable<GetProduct>> GetProductsByCategory(Guid categoryId)
        {
            var client = httpCLient.GetPublicClient();
            var apiCall = new ApiCall
            {
                Route = Constants.Category.GetProductsByCategory,
                Type = Constants.ApiCallType.Get,
                Client = client,
                Model = null!,
            };
            apiCall.ToString(categoryId);
            var response = await apihelper.ApiCallType<Dummy>(apiCall);
            return response == null ? Enumerable.Empty<GetProduct>() : await apihelper.GetServiceResponse<IEnumerable<GetProduct>>(response);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
        {
            var client = await httpCLient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constants.Category.Update,
                Type = Constants.ApiCallType.Put,
                Model = category,
                Client = client,

               


            };
            var response = await apihelper.ApiCallType<ServiceResponse>(apiCall);

            return response == null ? apihelper.ConnectionError() : await apihelper.GetServiceResponse<ServiceResponse>(response);
        }
    }
}
