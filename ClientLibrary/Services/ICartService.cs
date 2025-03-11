using ClientLibrary.Models;

namespace ClientLibrary.Services;

public interface ICartService
{
    Task<ServiceResponse> CheckOutAsync(CheckOut checkOut );
    Task<ServiceResponse> SaveCheckOutHistoryAsync(IEnumerable<CreateCartItem> checkOuts);
}



