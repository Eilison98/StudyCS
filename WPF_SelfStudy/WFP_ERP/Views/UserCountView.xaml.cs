using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WFP_ERP.Helpers;
using WFP_ERP.Models;

namespace WFP_ERP.Views
{
    /// <summary>
    /// LoadUsercorrectionView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserCountView : UserControl
    {
        public UserCountView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<TblUserTotalList> list = new List<TblUserTotalList>();
            try
            {
                using (var ctx = new ErpInformationEntities5())
                {
                    list = ctx.TblUserTotalList.ToList();
                }
                this.DataContext = list;
                Commons.ShowMessageAsync("전체조회", "전체직원 조회완료!");
            }
            catch (Exception ex)
            {
                Commons.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }
    }
}
