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
    public partial class Loading_Indicator : Form
    {
        public Loading_Indicator()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Visible = false;
            this.Load += Loading_Indicator_Load;
        }

        private void Loading_Indicator_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            timer_fadding.Start();
        }

        private void timer_fadding_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 0.92)
            {
                this.Opacity += 0.05;
            }
            else
            {
                timer_fadding.Stop();
            }
        }
    }
}
