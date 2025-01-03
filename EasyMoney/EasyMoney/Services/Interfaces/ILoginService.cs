using EasyMoney.Models.RequestModels;
using EasyMoney.Models.ResponseModels;

namespace EasyMoney.Services.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponseModel> LoginAsync(LoginRequestModel loginModel);
    }
}
