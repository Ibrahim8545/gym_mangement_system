using ComponentFactory.Krypton.Toolkit;
using gym_management_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system
{
    public partial class Login_form : Form
    {
        private EmployeeModel employeeModel = Global.employeeModel;
        private Loading_Indicator loadingIndicator;
        public Login_form()
        {
            InitializeComponent();
            loadingIndicator = new Loading_Indicator();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void TexteBox_Enter(ref KryptonTextBox t)
        {
            t.Text = string.Empty;
            t.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
            if (textUsername.TabStop == false || textPassword.TabStop == false)
            {
                textPassword.TabStop = true;
                textUsername.TabStop = true;
            }
        }

        private void textUsername_Enter(object sender, EventArgs e)
        {
            if (textUsername.Text == "Username")
            {
                lab_username_err.Text = "";
                TexteBox_Enter(ref textUsername);
            }
            lab_login_error.Text = string.Empty;
        }

        private void textPassword_Enter(object sender, EventArgs e)
        {
            if (textPassword.Text == "Password")
            {
                lab_pass_err.Text = "";
                textPassword.TextAlign = HorizontalAlignment.Left;
                TexteBox_Enter(ref textPassword);
                textPassword.PasswordChar = '*';
                textPassword.StateActive.Content.Padding = new Padding(left: 6, top: 13, right: 0, bottom: 13);
            }
            lab_login_error.Text = string.Empty;
            hide_pass_btn.Visible = true;
        }

        private void textUsername_Leave(object sender, EventArgs e)
        {
            if (textUsername.Text == "")
            {
                textUsername.Text = "Username";
                textUsername.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
                lab_username_err.Text = "Username Required!";
            }
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if (textPassword.Text == "")
            {
                textPassword.TextAlign = HorizontalAlignment.Center;
                textPassword.PasswordChar = '\0';
                textPassword.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
                textPassword.StateActive.Content.Padding = new Padding(left: 0, top: 12, right: 0, bottom: 13);
                textPassword.Text = "Password";
                lab_pass_err.Text = "Password Required!";
            }
            if (textPassword.Text != "Password")
            {
                textPassword.PasswordChar = '*';
            }
            show_pass_btn.Visible = false;
            hide_pass_btn.Visible = false;
        }

        private void textPassword_TextAlignChanged(object sender, EventArgs e)
        {
            if (textPassword.TextAlign == HorizontalAlignment.Center)
            {
                btnLogin.Focus();
            }
        }

        public void Enter_Key(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerLogin.IsBusy)
            {
                return;
            }
            if (textUsername.Text != "Username" && textPassword.Text != "Password" && !string.IsNullOrEmpty(textUsername.Text) && !string.IsNullOrEmpty(textPassword.Text))
            {
                loadingIndicator.Show();
                backgroundWorkerLogin.RunWorkerAsync();

            }
            else
            {
                if (textUsername.Text == "Username")
                {
                    textUsername.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
                    lab_username_err.Text = "Username Required!";
                }
                if (textPassword.Text == "Password")
                {
                    textPassword.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
                    lab_pass_err.Text = "Password Required!";
                }
                if (string.IsNullOrEmpty(textUsername.Text))
                {
                    textUsername.Text = "Username";
                    textUsername.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
                    lab_username_err.Text = "Username Required!";
                }
                if (string.IsNullOrEmpty(textPassword.Text))
                {
                    textPassword.Text = "Password";
                    textPassword.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
                    lab_pass_err.Text = "Password Required!";
                }
            }

        }

        private void show_pass_btn_Click(object sender, EventArgs e)
        {
            hide_pass_btn.Visible = true;
            show_pass_btn.Visible = false;
            textPassword.PasswordChar = '*';
        }

        private void hide_pass_btn_Click(object sender, EventArgs e)
        {
            hide_pass_btn.Visible = false;
            show_pass_btn.Visible = true;
            textPassword.PasswordChar = '\0';
        }

        private void backgroundWorkerLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            string username = textUsername.Text, password = textPassword.Text;
            employeeModel = Global.employeeService.login(username, password);
        }

        private void backgroundWorkerLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingIndicator.Close();
            loadingIndicator = new Loading_Indicator();
            if (employeeModel != null)
            {
                if (employeeModel.AccountStatus == true)
                {
                    Main_Form mainForm = new Main_Form(employeeModel);
                    this.Visible = false;
                    mainForm.ShowDialog();
                    this.Visible = true;
                }
            }
            else
            {
                lab_login_error.Text = "Username or Password is InCorrect";
            }
        }
    }
}
