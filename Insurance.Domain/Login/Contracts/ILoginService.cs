using Insurance.Infrastructure.Base;

namespace Insurance.Domain.Login.Contracts
{
    public  interface ILoginService : IBaseService
    {
        void GetLoginDetails(string name);
    }
}
