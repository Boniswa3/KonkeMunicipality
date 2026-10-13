
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KonkeMunicipality
{
    public partial class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblMessage;
        private Button btnLogin;

        public LoginForm()
        {
            InitializeComponent();
            BuildLoginInterface();
        }


        private void BuildLoginInterface()
        {
            Color navy = Color.FromArgb(20, 43, 74);
            Color blue = Color.FromArgb(37, 86, 166);
            Color pageBackground = Color.FromArgb(243, 246, 250);
            Color mutedText = Color.FromArgb(91, 105, 123);

            Text = "Konke Local Municipality | Sign In";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(520, 500);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = pageBackground;
            Font = new Font("Segoe UI", 10F);

            // Municipality header
            Panel header = new Panel
            {
                BackColor = navy,
                Location = new Point(0, 0),
                Size = new Size(520, 125)
            };
            Controls.Add(header);

            Label lblMunicipality = new Label
            {
                Text = "KONKE MUNICIPALITY",
                Font = new Font("Segoe UI", 21F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 22),
                Size = new Size(480, 45)
            };
            header.Controls.Add(lblMunicipality);

            Label lblSubtitle = new Label
            {
                Text = "Sign in to access municipal services",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(220, 229, 240),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 72),
                Size = new Size(480, 25)
            };
            header.Controls.Add(lblSubtitle);

            // Login card
            Panel loginPanel = new Panel
            {
                BackColor = Color.White,
                Location = new Point(35, 150),
                Size = new Size(450, 310),
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(loginPanel);

            Label lblWelcome = new Label
            {
                Text = "Welcome",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = navy,
                Location = new Point(30, 18),
                Size = new Size(390, 32),
                TextAlign = ContentAlignment.MiddleCenter
            };
            loginPanel.Controls.Add(lblWelcome);

            Label lblUsername = new Label
            {
                Text = "Username",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = navy,
                Location = new Point(35, 65),
                AutoSize = true
            };
            loginPanel.Controls.Add(lblUsername);

            txtUsername = new TextBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(35, 88),
                Size = new Size(370, 30),
                MaxLength = 100,
                BorderStyle = BorderStyle.FixedSingle
            };
            loginPanel.Controls.Add(txtUsername);

            Label lblPassword = new Label
            {
                Text = "Password",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = navy,
                Location = new Point(35, 130),
                AutoSize = true
            };
            loginPanel.Controls.Add(lblPassword);

            txtPassword = new TextBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(35, 153),
                Size = new Size(370, 30),
                PasswordChar = '*',
                MaxLength = 100,
                BorderStyle = BorderStyle.FixedSingle
            };
            loginPanel.Controls.Add(txtPassword);

            btnLogin = new Button
            {
                Text = "Sign In",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(35, 201),
                Size = new Size(370, 42),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;
            loginPanel.Controls.Add(btnLogin);

            lblMessage = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Firebrick,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 250),
                Size = new Size(410, 35)
            };
            loginPanel.Controls.Add(lblMessage);

            AcceptButton = btnLogin;
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text =
                    "Please enter both username and password.";
                return;
            }

            // Temporary development credentials only.
            // Replace with secure authentication before deployment.
            if (username.Equals(
                    "resident",
                    StringComparison.OrdinalIgnoreCase)
                && password == "Resident@123")
            {
                OpenMainMenu();
            }
            else
            {
                lblMessage.Text =
                    "Invalid username or password.";
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void OpenMainMenu()
        {
            Hide();

            using (MainMenuForm mainMenu = new MainMenuForm())
            {
                mainMenu.ShowDialog();
            }

            Close();
        }
    }
}

