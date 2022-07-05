using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WFP_ERP.Helpers;
using WFP_ERP.Models;

namespace WFP_ERP.Views
{
    /// <summary>
    /// WarehouseView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WarehouseView : UserControl
    {
        public WarehouseView()
        {
            InitializeComponent();
        }

        // DB 데이터 조건검색
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
        }

        // DB 데이터 전체조회
        private void btnLookup_Click(object sender, RoutedEventArgs e)
        {
            List<TblERPInformationList> list = new List<TblERPInformationList>();
            try
            {
                using (var ctx = new ErpInformationEntities4())
                {
                    list = ctx.TblERPInformationList.ToList();
                }
                this.DataContext = list;
                Commons.ShowMessageAsync("전체조회", "재고실사현황 전체조회 완료!");
            }
            catch (Exception ex)
            {
                Commons.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }
    }
}
