using HomeModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Reflection;

namespace HomeModule
{
    [Module(ModuleName = "HomeModuleModule", OnDemand = true)]
    public class HomeModuleModule : IModule
    {
   
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

    }
}