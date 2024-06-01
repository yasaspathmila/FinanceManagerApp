using System;
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
    }
}
