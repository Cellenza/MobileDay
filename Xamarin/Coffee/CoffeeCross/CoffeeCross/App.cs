using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore;
using Coffee.Services;

namespace CoffeeCross
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

			Mvx.RegisterType<ICoffeeService, CoffeeService> ();
			RegisterAppStart<ViewModels.HomeViewModel>();
        }
    }
}