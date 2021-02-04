using PrismManager.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using System.ComponentModel;
using Prism.DryIoc;
using System.Reflection;

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
            var MedicineModuleType = typeof(HomeModule.HomeModuleModule);
            moduleCatalog.AddModule(SetModuleInfo(MedicineModuleType.Name + ",ViewA", MedicineModuleType.AssemblyQualifiedName));
        }





        ModuleInfo SetModuleInfo(string Nmae,string Moduletype, InitializationMode initialization=InitializationMode.OnDemand)
        {
            return new ModuleInfo()
            {
                ModuleName = Nmae,
                ModuleType = Moduletype,
                InitializationMode = InitializationMode.OnDemand
            };
           
        }


        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog(); //目录创建于配置文件
        }

      


    }
}
