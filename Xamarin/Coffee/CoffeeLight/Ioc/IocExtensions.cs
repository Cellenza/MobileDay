using GalaSoft.MvvmLight.Ioc;

namespace CoffeeLight
{
    public static class IocExtensions
    {
        public static void RegisterSafe<TInterface, TImplementation>(this SimpleIoc ioc)
            where TInterface : class
            where TImplementation : class
        {
            if (!ioc.IsRegistered<TInterface>())
                ioc.Register<TInterface, TImplementation>();
        }

        public static void RegisterSafe<TImplementation>(this SimpleIoc ioc)
            where TImplementation : class
        {
            if (!ioc.IsRegistered<TImplementation>())
                ioc.Register<TImplementation>();
        }
    }
}
