namespace EasyMoney.Models.ResponseModels
{
    public class LoginResponseModel
    {
        public Int64 UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; }   =string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
