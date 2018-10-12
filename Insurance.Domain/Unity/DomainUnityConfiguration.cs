using Insurance.Domain.Login.Contracts;
using Insurance.Domain.Login.Services;
using Insurance.Infrastructure.Extensions;
using Unity;

namespace Insurance.Domain.Unity
{
    public static class DomainUnityConfiguration
    {
        public static void Configure(IUnityContainer container)
        {
            container.AddService<ILoginService, LoginService>();
        }
    }
}
