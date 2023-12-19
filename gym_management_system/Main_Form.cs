using ComponentFactory.Krypton.Toolkit;
using gym_management_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system
{
    public partial class Main_Form : Form
    {
        private KryptonCheckButton nb = new KryptonCheckButton();
        private List<Form> form = new List<Form>();
        public EmployeeModel employee;
        public Main_Form()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            nb = ButtonHome;
            nb.Checked = true;
            if(employee != null)
            {
                if (employee.Picture != null)
                {
                    PictureBoxAccountProfile.Image = employee.Picture;
                }
                else
                {
                    Console.WriteLine("Error! No Profile Picture to Load");
                }
                labelName.Text = employee.Name;
            }
            else
            {
                Console.WriteLine("Error! No employee data to load");
            }

        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }
        public Main_Form(EmployeeModel employeeModel)
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            nb = ButtonHome;
            nb.Checked = true;
            employee = employeeModel;
            PictureBoxAccountProfile.Image = employee.Picture;
            labelName.Text = employee.Name;
        }

        private void timer_slider_hide_Tick(object sender, EventArgs e)
        {
            if (Panel_slider.Size.Width > 102)
            {
                int x = Panel_slider.Size.Width - 21, y = Panel_slider.Size.Height;
                Panel_slider.Size = new Size(x, y);
                int z = mainpanel.Size.Width + 21, w = mainpanel.Size.Height;
                mainpanel.Size = new Size(z, w);
                int ly = mainpanel.Location.Y, lx = mainpanel.Location.X - 21;
                mainpanel.Location = new Point(lx, ly);
            }
            else
            {
                timer_slider_hide.Stop();
            }
        }

        private void timer_slider_show_Tick(object sender, EventArgs e)
        {
            if (Panel_slider.Size.Width < 333)
            {
                int x = Panel_slider.Size.Width + 21, y = Panel_slider.Size.Height;
                Panel_slider.Size = new Size(x, y);
                int z = mainpanel.Size.Width - 21, w = mainpanel.Size.Height;
                mainpanel.Size = new Size(z, w);
                int ly = mainpanel.Location.Y, lx = mainpanel.Location.X + 21;
                mainpanel.Location = new Point(lx, ly);
            }
            else
            {
                timer_slider_show.Stop();
            }
        }

        private void KryptonButtonSetting(KryptonCheckButton button)
        {
            nb.Checked = false;
            nb = button;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!timer_slider_show.Enabled && !timer_slider_hide.Enabled)
            {
                if (Panel_slider.Size.Width == 333)
                {
                    timer_slider_hide.Start();
                    pictureBox1.Image = Image.FromFile("system_image\\bars-sort 1.png");
                }
                else if (Panel_slider.Size.Width == 102)
                {
                    pictureBox1.Image = Image.FromFile("system_image\\bars-staggered 2Greypng.png");
                    timer_slider_show.Start();

                }
            }
        }

        private void ButtonHome_Click(object sender, EventArgs e)
        {
            if (!ButtonHome.Checked)
            {
                ButtonHome.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonHome);
        }

        private void ButtonMembers_Click(object sender, EventArgs e)
        {
            if (!ButtonMembers.Checked)
            {
                ButtonMembers.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonMembers);
        }

        private void ButtonAnnouncement_Click(object sender, EventArgs e)
        {
            if (!ButtonAnnouncement.Checked)
            {
                ButtonAnnouncement.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonAnnouncement);
        }

        private void ButtonEmployees_Click(object sender, EventArgs e)
        {
            if (!ButtonEmployees.Checked)
            {
                ButtonEmployees.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonEmployees);
        }

        private void ButtonSubscriptions_Click(object sender, EventArgs e)
        {
            if (!ButtonSubscriptions.Checked)
            {
                ButtonSubscriptions.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonSubscriptions);
        }

        private void ButtonPayments_Click(object sender, EventArgs e)
        {
            if (!ButtonPayments.Checked)
            {
                ButtonPayments.Checked = true;
                return;
            }
            KryptonButtonSetting(ButtonPayments);
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            Home home = new Home();
            loadform(home);
        }
    }
}
