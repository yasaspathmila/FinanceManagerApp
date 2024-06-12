using System.Drawing.Drawing2D;
using System.Drawing;
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
            ApplyCustomTheme();
            this.BackColor = Color.LightBlue; // Set form background color
            this.Font = new Font("Segoe UI", 10);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
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
                    button.BackColor = Color.CornflowerBlue;
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = Color.RoyalBlue;
                    button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = control as ComboBox;
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Color.DarkBlue;
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
                else if (control is TextBox)
                {
                    TextBox textBox = control as TextBox;
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.DarkBlue;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.DarkBlue, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
