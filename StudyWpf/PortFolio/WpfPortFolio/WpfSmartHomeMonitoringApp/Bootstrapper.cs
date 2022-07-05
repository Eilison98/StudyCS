﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfSmartHomeMonitoringApp.ViewModels;

namespace WpfSmartHomeMonitoringApp
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container;  //  다이얼로그, 팝업, 기타설정....

        public Bootstrapper()
        {
            Initialize();  //  !
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        /// <summary>
        /// Caliburn MVVM 초기 설정
        /// </summary>
        protected override void Configure()
        {
            container = new SimpleContainer();
            container.Singleton<IWindowManager, WindowManager>();  //  같은프로그램은 하나만 실행할수있게
            container.PerRequest<MainViewModel>();
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //base.OnStartup(sender, e);
            DisplayRootViewFor<MainViewModel>();
        }
    }
}