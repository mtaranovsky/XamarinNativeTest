using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using XamarinNativeTest.Core.ViewModels;

namespace XamarinNativeTest.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterNavigationServiceAppStart<TicketsListViewModel>();
        }
    }
}