using Insurance.Data.Login.Contracts;
using Insurance.Domain.Login.Contracts;
using Insurance.Infrastructure.Base;

namespace Insurance.Domain.Login.Services
{
    class LoginService : BaseService, ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        void ILoginService.GetLoginDetails(string name)
        {
            _loginRepository.GetLoginDetails("");
        }
    }
}
