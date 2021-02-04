using LoginModule.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoginModule.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;

        public LoginViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            this._regionManager = regionManager;
            this._containerProvider = containerProvider;
  
        }
    }

    public class LoginSentEvent: PubSubEvent<bool> { }
}
