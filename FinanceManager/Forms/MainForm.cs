using System.Windows.Forms;

namespace PersonalFinanceManager.Forms
{
    public partial class MainForm : Form
    {
        private readonly string _username;

        public MainForm(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {

        }

    }
}
