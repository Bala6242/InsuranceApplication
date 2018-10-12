using Insurance.Data.Login.Contracts;
using Insurance.Data.Login.Repositories;
using Insurance.Infrastructure.Extensions;
using Unity;

namespace Insurance.Data.Unity
{
    public static class DataUnityConfiguration
    {
        public static void Configure(IUnityContainer container)
        {
            container.AddRepository<ILoginRepository, LoginRepository>();
        }
    }
}
