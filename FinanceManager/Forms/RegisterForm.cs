using PersonalFinanceManager.Controllers;
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
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
            ApplyCustomTheme();
            this.BackColor = Color.PaleGoldenrod; // Set form background color
            this.Font = new Font("Segoe UI", 10);
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

        private void ApplyCustomTheme()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = control as Button;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.Brown;
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = Color.OrangeRed;
                    button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                else if (control is TextBox)
                {
                    TextBox textBox = control as TextBox;
                    textBox.BackColor = Color.WhiteSmoke;
                    textBox.ForeColor = Color.Brown;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.DarkOrange, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
