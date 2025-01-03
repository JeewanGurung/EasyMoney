using EasyMoney.Models.RequestModels;
using EasyMoney.Models.ResponseModels;
using EasyMoney.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace EasyMoney.Services.Implementations
{
    public class LoginService : DapperService, ILoginService
    {
        public LoginService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel loginModel)
        {
            var Users = await GetQueryFirstOrDefaultResultAsync<LoginResponseModel>("Select * from tblUser where Username=UserName", new { UserName = loginModel.UserName });
            if (Users == null)
            {
                throw new ArgumentException("User not Found");
            }
            if (Users.Password != loginModel.Password)
            {
                throw new ArgumentException("Password do not matched");
            }
            return Users;
        }
    }
}
