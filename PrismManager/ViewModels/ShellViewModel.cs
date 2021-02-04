using LoginModule.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using PrismManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace PrismManager.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        IEventAggregator ea;

        IContainerExtension _container;
        IRegionManager _regionManager;
        IRegion _region;
        IModuleManager _moduleManager;

        #region 属性

        private int _Width;

        public int Width
        {
            get { return _Width; }
            set { SetProperty(ref _Width, value); }
        }

        private int _Height;

        public int Height
        {
            get { return _Height; }
            set { SetProperty(ref _Height,value); }

        }


        #endregion

        public ShellViewModel(IContainerExtension Container, IRegionManager regionManager, IEventAggregator eventAggregator, IModuleManager moduleManager)
        {
            Width = 340;
            Height = 390;
            #region 接受登陆消息
            ea = eventAggregator;
            ea.GetEvent<LoginSentEvent>().Subscribe(MessageReceived);//订阅消息
            #endregion
            _regionManager = regionManager;
            _container = Container;
            _moduleManager = moduleManager;
            _moduleManager.LoadModuleCompleted += _moduleManager_LoadModuleCompleted;
        }

        private void _moduleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            MessageBox.Show($"{e.ModuleInfo.ModuleName}模块被加载了");
        }
        private void NvanPage<T>()
        {

            //获取对应ContentControl

            var PageMod = _region.Views.Where(o => o.GetType() == typeof(T)).FirstOrDefault();
            if (PageMod == null) return;
            _region.Activate(PageMod);
        }

        private void MessageReceived(bool loginState)
        {
            if (loginState)
            {
                _region = _regionManager.Regions["MainRegion"];
                _region.RemoveAll();
                _moduleManager.LoadModule("HomeModule");
                NvanPage<HomeModule.Views.ViewA>();
                Width = 1024;
                Height = 768;
            }
        }



    }

}
