using PersonalFinanceManager.Controllers;
using System;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly UserController _userController;

        public RegisterForm()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            if (_userController.RegisterUser(username, password))
            {
                MessageBox.Show("Registration successful!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Registration failed.");
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
