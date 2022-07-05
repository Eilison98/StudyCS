using Caliburn.Micro;
using System;
using System.Threading;
using System.Threading.Tasks;
using WpfSmartHomeMonitoringApp.Helpers;

namespace WpfSmartHomeMonitoringApp.ViewModels
{
    class MainViewModel : Conductor<object>  //  Screen에는 ActivateItem[Async] 메서드 없음
    {
        public MainViewModel()
        {
            DisplayName = "SmartHome Monitoring v2.0";  //  Window Title
        }

        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            //  비활성화 처리
            if (Commons.MQTT_CLIENT.IsConnected)
            {
                Commons.MQTT_CLIENT.Disconnect();
                Commons.MQTT_CLIENT = null;
            }

            return base.OnDeactivateAsync(close, cancellationToken);
        }

        public void LoadDataBaseView()
        {
            ActivateItemAsync(new DataBaseViewModel());
        }

        public void LoadRealBaseView()
        {
            ActivateItemAsync(new RealTimeViewModel());
        }

        public void LoadHistory()
        {
            ActivateItemAsync(new HistoryViewModel());
        }

        //  Program Exit
        public void ExitProgram()
        {
            Environment.Exit(0);
        }

        public void ExitToolbar()
        {
            Environment.Exit(0);
        }


        //  Start 메뉴, 아이콘 눌렀을때 처리할 이벤트
        public void PopInfoDialog()
        {
            TaskPopup();
        }

        public void StartSubscribe()
        {
            TaskPopup();
        }

        private void TaskPopup()
        {
            //  CustomPopupView
            var winManager = new WindowManager();
            var result = winManager.ShowDialogAsync(new CustomPopupViewModel("New Broker"));

            if (result.Result == true)
            {
                ActivateItemAsync(new DataBaseViewModel());  //  화면전환
            }
        }

        public void PopInfoView()
        {
            var winManager = new WindowManager();
            winManager.ShowDialogAsync(new CustomInfoViewModel("About"));
        }
    }
}
