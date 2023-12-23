using ComponentFactory.Krypton.Toolkit;
using Guna.UI2.WinForms.Suite;
using gym_management_system.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system
{
    public partial class Add_Person : Form
    {
        private Image image = null;
        private string base64 = null;
        private bool Mem = false, Emp = false, Tra = false;
        string Gender;
        bool Role, passE = false, status_Add;
        private MemberModel member;
        private EmployeeModel employee;
        private TrainerModel trainer;
        private Loading_Indicator loading;

        public Add_Person()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        public Add_Person(bool Mem = false, bool Emp = false, bool Tra = false)
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            btnSub.Enabled = false;
            if (Mem)
            {
                this.Mem = true;
                member = new MemberModel();

            }else if(Emp)
            {
                this.Emp = true;
                employee = new EmployeeModel();
                textU.Visible = true;
                textPass.Visible = true;
                textCPass.Visible = true;
                panelR.Visible = true;
                textU.Text = "UserName";
            }
            else if (Tra)
            {
                this.Tra = true;
                trainer = new TrainerModel();
                textU.Visible = true;
                textPP.Visible = true;
                textU.Text = "Specialization";
            }

        }

        private void get_gender()
        {
            if(radioButtonM.Checked)
            {
                Gender = "male";
            }else if(radioButtonF.Checked)
            {
                Gender = "Femal";
            }
        }

        private void get_Role()
        {
            if (radioButtonA.Checked)
            {
                Role = true;
            }
            else if (radioButtonF.Checked)
            {
                Role = false;
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            textBrith.ForeColor = Color.FromArgb(70, 71, 78);
            textBrith.Text = metroDateTime1.Value.ToString("yyyy-MM-dd");
        }

        private void textF_Enter(object sender, EventArgs e)
        {
            if (textF.Text == "First Name")
            {
                textF.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                textF.Text = string.Empty;
            }
        }

        private void textF_Leave(object sender, EventArgs e)
        {
            if (textF.Text == "")
            {
                textF.Text = "First Name";
                textF.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
            }
        }

        private void textS_Enter(object sender, EventArgs e)
        {
            if (textS.Text == "Second Name")
            {
                textS.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                textS.Text = string.Empty;
            }
        }

        private void textS_Leave(object sender, EventArgs e)
        {
            if (textS.Text == "")
            {
                textS.Text = "Second Name";
                textS.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
            }
        }

        private void textE_Enter(object sender, EventArgs e)
        {
            if (textE.Text == "Email")
            {
                textE.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                textE.Text = string.Empty;
            }
        }

        private void textE_Leave(object sender, EventArgs e)
        {
            if (textE.Text == "")
            {
                textE.Text = "Email";
                textE.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
            }
        }

        private void textU_Enter(object sender, EventArgs e)
        {
            if (Emp)
            {
                if (textU.Text == "Username")
                {
                    textU.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                    textU.Text = string.Empty;
                }
            }
            else if (Tra)
            {
                if (textU.Text == "Specialization")
                {
                    textU.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                    textU.Text = string.Empty;
                }
            }
            
        }

        private void textU_Leave(object sender, EventArgs e)
        {
            if (Emp)
            {
                if (textU.Text == "")
                {
                    textU.Text = "Username";
                    textU.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
                }
            }else if (Tra)
            {
                if (textU.Text == "")
                {
                    textU.Text = "Specialization";
                    textU.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
                }
            }
            
        }

        private void textPP_Enter(object sender, EventArgs e)
        {
            if (textPP.Text == "Private Price")
            {
                textPP.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                textPP.Text = string.Empty;
            }
        }

        private void textPP_Leave(object sender, EventArgs e)
        {
            if (textPP.Text == "")
            {
                textPP.Text = "Private Price";
                textPP.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
            }
        }

        private void textPass_Enter(object sender, EventArgs e)
        {
            if (textPass.Text == "Password")
            {
                if (textPass.Text == "Password")
                {
                    textPass.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                    textPass.Text = string.Empty;
                }
                textPass.PasswordChar = '*';
            }
            hide_pass_btn.Visible = true;
        }

        private void textPass_Leave(object sender, EventArgs e)
        {
            if (textPass.Text == "")
            {
                textPass.PasswordChar = '\0';
                textPass.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
                textPass.Text = "Password";
            }
            if (textPass.Text != "Password")
            {
                textPass.PasswordChar = '*';
                if (textCPass.Text != textPass.Text && textCPass.Text != "Confirm Password")
                {
                    textCPass.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
                    passE = false;
                }
                else
                {
                    textCPass.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                    passE = true;
                }
            }
            show_pass_btn.Visible = false;
            hide_pass_btn.Visible = false;
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            labelimageError.Text = string.Empty;
            OpenFileDialog open_form = new OpenFileDialog();
            open_form.Title = "Choose Picture";
            open_form.Filter = "Images|*.jpg;*.png;*.bmp";
            open_form.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (open_form.ShowDialog() == DialogResult.OK)
            {
                if (Global.mangeImage.GetFileSizeInBytes(open_form.FileName) > 1000)
                {
                    labelimageError.Text = "This image is Big in Size";
                    return;
                }
                image = Global.mangeImage.CompressImageSize(Image.FromFile(open_form.FileName));
                if (image == null)
                {
                    labelimageError.Text = "This image is Big in Size";
                    return;
                }
                bunifuPictureBox1.Image = image;
                base64 = Global.mangeImage.CompressImageSizeGetBase64(Image.FromFile(open_form.FileName));
            }
        }
        private void show_pass_btn_Click(object sender, EventArgs e)
        {
            hide_pass_btn.Visible = true;
            show_pass_btn.Visible = false;
            textPass.PasswordChar = '*';
        }

        private void show_pass_btn2_Click(object sender, EventArgs e)
        {
            hide_pass_btn2.Visible = true;
            show_pass_btn2.Visible = false;
            textCPass.PasswordChar = '*';
        }

        private void textCPass_Enter(object sender, EventArgs e)
        {
            if (textCPass.Text == "Confirm Password")
            {
                if (textCPass.Text == "Confirm Password")
                {
                    textCPass.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                    textCPass.Text = string.Empty;
                }
                textCPass.PasswordChar = '*';
            }
            hide_pass_btn2.Visible = true;
        }

        private void textCPass_Leave(object sender, EventArgs e)
        {
            if (textCPass.Text == "")
            {
                textCPass.PasswordChar = '\0';
                textCPass.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
                textCPass.Text = "Confirm Password";
            }
            if (textCPass.Text != "Confirm Password")
            {
                textCPass.PasswordChar = '*';
                if(textCPass.Text != textPass.Text && textPass.Text != "Password")
                {
                    textCPass.StateActive.Content.Color1 = Color.FromArgb(255, 115, 115);
                    passE = false;
                }
                else
                {
                    textCPass.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                    passE = true;
                }
            }
            show_pass_btn2.Visible = false;
            hide_pass_btn2.Visible = false;
        }

        private void hide_pass_btn_Click(object sender, EventArgs e)
        {
            hide_pass_btn.Visible = false;
            show_pass_btn.Visible = true;
            textPass.PasswordChar = '\0';
        }

        private void radioButtonA_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonA.ForeColor = Color.FromArgb(70, 71, 78);
            radioButtonU.ForeColor = Color.FromArgb(70, 71, 78);
            get_Role();
        }

        private void radioButtonM_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonM.ForeColor = Color.FromArgb(70, 71, 78);
            radioButtonF.ForeColor = Color.FromArgb(70, 71, 78);
            get_gender();
        }

        private void radioButtonU_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonA.ForeColor = Color.FromArgb(70, 71, 78);
            radioButtonU.ForeColor = Color.FromArgb(70, 71, 78);
            get_Role();
        }

        private void radioButtonF_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonM.ForeColor = Color.FromArgb(70, 71, 78);
            radioButtonF.ForeColor = Color.FromArgb(70, 71, 78);
            get_gender();
        }

        private void textP_Enter(object sender, EventArgs e)
        {
            if (textP.Text == "Phone")
            {
                textP.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                textP.Text = string.Empty;
            }
        }

        private void textP_Leave(object sender, EventArgs e)
        {
            if (textP.Text == "")
            {
                textP.Text = "Phone";
                textP.StateActive.Content.Color1 = Color.FromArgb(70, 71, 78);
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (Emp)
            {
                employee.FirstName = textF.Text;
                employee.SecondName = textS.Text;
                employee.Admin = Role;
                employee.AccountStatus = true;
                employee.Brithday = metroDateTime1.Value;
                employee.Gender = Gender;
                employee.Email = textE.Text;
                employee.PhoneNumber = textP.Text == "Phone" ? null : textP.Text;
                employee.Username = textU.Text;
                employee.Password = textPass.Text;
                employee.Picture = image;
                employee.Base64Image = base64;
            }else if (Mem)
            {
                member.FirstName = textF.Text;
                member.SecondName = textS.Text;
                member.Email = textE.Text;
                member.Picture = image;
                member.Brithday = metroDateTime1.Value;
                member.Base64Image = base64;
                member.Gender = Gender;
                member.PhoneNumber = textP.Text == "Phone" ? null : textP.Text;
            }else if (Tra)
            {
                trainer.FirstName = textF.Text;
                trainer.SecondName = textS.Text;
                trainer.Email = textE.Text;
                trainer.Picture = image;
                trainer.Brithday= metroDateTime1.Value;
                trainer.Base64Image = base64;
                trainer.Gender = Gender;
                trainer.PrivateLessonPrice = Convert.ToInt32(textPP.Text);
                trainer.PhoneNumber = textP.Text == "Phone" ? null : textP.Text;
                trainer.Status = true;
            }
            loading = new Loading_Indicator();
            loading.Show();
            backgroundWorkeradd.RunWorkerAsync();
        }

        private void backgroundWorkeradd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (status_Add)
            {
                labelerrorAdd.Text = string.Empty;
            }
            else
            {
                labelerrorAdd.Text = "error on Add";
            }
            loading.Close();
        }

        private void backgroundWorkeradd_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Emp)
            {
                status_Add = Global.employeeService.addEmployee(employee);
            }else if (Mem)
            {
                status_Add = Global.memberService.addMember(member);
            }else if (Tra)
            {
                status_Add = Global.trainerService.addTrainer(trainer);
            }
        }

        private void textPP_TextChanged(object sender, EventArgs e)
        {
            if (textF.Text != "First Name" && textS.Text != "Second Name" && textE.Text != "Email" && textBrith.Text != "Brithdate" && (radioButtonM.Checked || radioButtonF.Checked))
            {
                if (Emp)
                {
                    if(textU.Text != "Username" && textPass.Text != "Password" && textCPass.Text != "Confirm Password" && (radioButtonA.Checked || radioButtonU.Checked) && passE)
                    {
                        btnSub.Enabled = true;
                    }
                    else
                    {
                        btnSub.Enabled = false;
                    }
                } else if (Mem)
                {
                    btnSub.Enabled = true;
                }else if (Tra)
                {
                    if (textU.Text != "Specialization" && textPP.Text != "Private Price")
                    {
                        btnSub.Enabled = true;
                    }
                    else
                    {
                        btnSub.Enabled = false;
                    }
                }
                
            }
            else
            {
                btnSub.Enabled = false;
            }
        }

        private void hide_pass_btn2_Click(object sender, EventArgs e)
        {
            hide_pass_btn2.Visible = false;
            show_pass_btn2.Visible = true;
            textCPass.PasswordChar = '\0';
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
