using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginModule.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand LoginCmd { get; private set; }

        IEventAggregator ea;

        public ViewAViewModel(IEventAggregator aggregator)
        {
            Message = "View A from your Prism Module";

            LoginCmd = new DelegateCommand(LoginMethod);
            ea = aggregator;
        }

        private void LoginMethod()
        {
            //登陆操作
            bool logflag = true;

            //登陆操作成功后，发送消息
            ea.GetEvent<LoginSentEvent>().Publish(logflag);
        }
    }
    public class LoginSentEvent : Prism.Events.PubSubEvent<bool>
    {

    }
   

}
