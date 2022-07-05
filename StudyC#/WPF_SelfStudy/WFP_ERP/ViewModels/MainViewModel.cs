using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WFP_ERP.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        // WarehouseViewModel
        public void LoadWarehouse_inventory()
        {
            ActivateItemAsync(new WarehouseViewModel());
        }

        // ProductViewModel
        public void LoadProduct()
        {
            ActivateItemAsync(new ProductViewModel());
        }

        // WearingViewModel
        public void LoadWearing()
        {
            ActivateItemAsync(new WearingViewModel());
        }

        // ReleaseViewModel
        public void LoadRelease()
        {
            ActivateItemAsync(new ReleaseViewModel());
        }

        // UsercorrectionViewModel
        public void LoadUserCount()
        {
            ActivateItemAsync(new UserCountViewModel());
        }

        // UserViewModel
        public void LoadUser()
        {
            ActivateItemAsync(new UserViewModel());
        }
    }
}
