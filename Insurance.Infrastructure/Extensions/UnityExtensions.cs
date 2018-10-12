using Insurance.Infrastructure.Base;
using Unity;
using Unity.Lifetime;

namespace Insurance.Infrastructure.Extensions
{
    public static class UnityExtensions
    {
        public static void AddRepository<TInterface, TClass>(this IUnityContainer unityContainer)
           where TInterface : IBaseRepository
           where TClass : BaseRepository, TInterface
        {
            unityContainer.RegisterType<TInterface, TClass>(lifetimeManager: new PerResolveLifetimeManager());
        }
        public static void AddService<TInterface, TClass>(this IUnityContainer unityContainer)
            where TInterface : IBaseService
            where TClass : BaseService, TInterface
        {
            unityContainer.RegisterType<TInterface, TClass>(lifetimeManager: new PerResolveLifetimeManager());
        }
    }
}
