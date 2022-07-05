using AppConfiguration;
using System.Windows.Forms;

namespace mook_CarInfo
{
    // 앞으로 추가되는 화면(Form) 및 기존의 모든 화면(Form)에서 하나의 SqlConnection을
    // 계속 재사용하기 위해서 부모 화면(Form) 의 생성자에서 ConfigurationMgr() 생성자를 호출해서
    // 사용함.

    // 모든 Form은 ApplicationRootForm 을 상속 받아서 사용하게 되게 됨으로
    // 결국 Slq Connection은 하나로만 사용하게 됨.
     
    public partial class ApplicationRootForm : Form
    {
        protected ConfigurationMgr configurationMgr;
        public ApplicationRootForm()
        {
            InitializeComponent();

            // Form은 디자인 화면이 있어, 디자인 화면에서 RunTime 과 관계된 코드가 동시에
            // 동작이 되지 않도록 하기 위함.

            // 디자인 모드의 화면이 보이지 않게 되는 경우가 간혹 발생하는 경우가 있음.
            // Form 위의 컨트롤이 보이지 않아서, 제어를 할 수 가 없음.

            // 현재 RunTime인지를 확인한 후 ConfigurationMgr 객채를 생성하려고 함.
            if (System.ComponentModel.LicenseManager.UsageMode ==
                System.ComponentModel.LicenseUsageMode.Runtime)
            {
                configurationMgr = new ConfigurationMgr();
            }
        }
    }
}
