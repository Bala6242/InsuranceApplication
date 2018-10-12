using Insurance.Domain.Login.Contracts;
using System.Web.Http;

namespace InsuranceManagement.ApiControllers
{
    [RoutePrefix("api/login")]
    public class LoginController : BaseApiController
    {
        private readonly ILoginService _loginService;
        [HttpGet]
        [Route("{name:string}")]
        public void GetLoginDetail(string name)
        {
            _loginService.GetLoginDetails(name);
        }
    }
}