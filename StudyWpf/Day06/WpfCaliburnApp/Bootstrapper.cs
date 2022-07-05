using Caliburn.Micro;
using System.Windows;
using WpfCaliburnApp.ViewModels;

namespace WpfCaliburnApp
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();  //  칼리번을 쓰기위해서는 필요
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //  base.OnStartup(sender, e);
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
