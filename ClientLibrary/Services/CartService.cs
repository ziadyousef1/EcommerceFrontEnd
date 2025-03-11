using ClientLibrary.Helper;
using ClientLibrary.Models;

namespace ClientLibrary.Services.ClientLibrary.Services;

public class CartService(IHttpClienthelper httpClient, IApiCallHelper apiHelper) : ICartService
{
    public async Task<ServiceResponse> CheckOutAsync(CheckOut checkOut)
    {
        var privateClient = await httpClient.GetPrivateClientAsync();
        var apiCallModel = new ApiCall
        {
            Route = Constants.Cart.Checkout,
            Type = Constants.ApiCallType.Post,
            Client = privateClient,
            Id = null!,
            Model = checkOut
        };

        var result = await apiHelper.ApiCallType<CheckOut>(apiCallModel);
        if (result == null)
            return apiHelper.ConnectionError(); 
        return await apiHelper.GetServiceResponse<ServiceResponse>(result);
    }

    public async Task<ServiceResponse> SaveCheckOutHistoryAsync(IEnumerable<CreateCartItem> checkOuts)
    {
        var privateClient = await httpClient.GetPrivateClientAsync();
        var apiCallModel = new ApiCall
        {
            Route = Constants.Cart.SaveCart,
            Type = Constants.ApiCallType.Post,
            Client = privateClient,
            Id = null!,
            Model = checkOuts
        };

        var result = await apiHelper.ApiCallType<IEnumerable<CreateCartItem>>(apiCallModel);
        if (result == null)
            return apiHelper.ConnectionError();
            
        return await apiHelper.GetServiceResponse<ServiceResponse>(result);
    }
}