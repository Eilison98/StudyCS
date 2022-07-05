using System.Windows;

namespace Wpf_Basic_App
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, WPF!", "First WPF");  //  메세지 박스를 사용하여
        }
    }
}
