using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace CoffeeLight.ViewModels
{
    public class ViewModelLocator
    {
        public const string ListPageKey = "ListPage";
        public const string MapPageKey = "MapPage";
        public const string HomePageKey = "HomePage";

        public CoffeeListViewModel List => SimpleIoc.Default.GetInstance<CoffeeListViewModel>();

        public CoffeeMapViewModel Map => SimpleIoc.Default.GetInstance<CoffeeMapViewModel>();

        public HomeViewModel Home => SimpleIoc.Default.GetInstance<HomeViewModel>();

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var ioc = SimpleIoc.Default;

            ioc.RegisterSafe<HomeViewModel>();
            ioc.RegisterSafe<CoffeeListViewModel>();
            ioc.RegisterSafe<CoffeeMapViewModel>();
        }
    }
}
