using PersonalFinanceManager.Controllers;
using System;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserController _userController;

        public LoginForm()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            if (_userController.AuthenticateUser(username, password))
            {
                MessageBox.Show("Login successful!");
                var mainForm = new MainForm(username);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
