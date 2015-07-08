using Bifrost.Slack.Core;
using Cirrious.CrossCore.IoC;

namespace Bifrost.Slack.UI.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            // allow the client to initialize its IoC dependencies
            Client.RegisterIoC();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}