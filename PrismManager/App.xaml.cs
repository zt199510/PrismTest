using PrismManager.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using System.ComponentModel;
using Prism.DryIoc;

namespace PrismManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        /// <summary>
        /// 预设模块
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            
            //moduleCatalog.AddModule<LoginModule.LoginModuleModule>();

            var MedicineModuleType = typeof(HomeModule.HomeModuleModule);
            moduleCatalog.AddModule(new ModuleInfo() {
                ModuleName = MedicineModuleType.Name,
                ModuleType = MedicineModuleType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });
        }


        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog(); //目录创建于配置文件
        }

      


    }
}
