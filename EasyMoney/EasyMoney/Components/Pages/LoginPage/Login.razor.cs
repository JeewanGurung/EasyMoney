using EasyMoney.Models.RequestModels;
using EasyMoney.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace EasyMoney.Components.Pages.LoginPage
{
    public partial class Login
    {
        private LoginRequestModel _loginModel = new();
        [Inject] private ILoginService _loginService { get; set; }

        private async Task SubmitAsync()
        {
            var response = await _loginService.LoginAsync(_loginModel);
            _navigationManager.NavigateTo("/", true);
        }
    }
}