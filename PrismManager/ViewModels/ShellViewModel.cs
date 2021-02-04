﻿using LoginModule.ViewModels;
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
     
        private string _title = "Prism Unity Application";

        /// <summary>
        /// 注释
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public ShellViewModel(IContainerExtension Container, IRegionManager regionManager, IEventAggregator eventAggregator, IModuleManager moduleManager)
        {
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


        private void NvanPage<T>() {

            //获取对应ContentControl
            _region = _regionManager.Regions["MainRegion"];
            var PageMod=_region.Views.Where(o => o.GetType() == typeof(T)).FirstOrDefault();
            if (PageMod==null)
            {
                _moduleManager.LoadModule("HomeModuleModule");
                NvanPage<T>();
            }
            else
            {
                _region.Activate(PageMod);
            }
        } 


        private void MessageReceived(bool loginState)
        {
            if (loginState)
            {
                NvanPage<HomeModule.Views.ViewA>();
            }
        }

  

    }
}
