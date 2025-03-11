using ClientLibrary.Helper;
using ClientLibrary.Models;

namespace ClientLibrary.Services;

public interface IPaymentMethodService
{
    Task<IEnumerable<GetPaymentMethod>> GetPaymentMethodsAsync();
    
}
public class PaymentService: IPaymentMethodService
{
    private readonly IHttpClienthelper _httpClient;
    private readonly IApiCallHelper _apiCallHelper;

    public PaymentService(IHttpClienthelper httpClient, IApiCallHelper apiCallHelper)
    {
        _httpClient = httpClient;
        _apiCallHelper = apiCallHelper;
    }

    public async Task<IEnumerable<GetPaymentMethod>> GetPaymentMethodsAsync()
    {
        var privateClient =  _httpClient.GetPublicClient();
        var apiCallModel = new ApiCall
        {
            Route = Constants.Payment.GetAll,
            Type = Constants.ApiCallType.Get,
            Client = privateClient,
            Id = null!,
            Model = null!
        };

        var result = await _apiCallHelper.ApiCallType<Dummy>(apiCallModel);
        
        if (result.IsSuccessStatusCode)
            
            return await _apiCallHelper.GetServiceResponse<IEnumerable<GetPaymentMethod>>(result);
        return [];
    }
}