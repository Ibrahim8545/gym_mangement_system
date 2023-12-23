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
    public partial class Members : Form
    {
        private List<MemberModel> members;
        private List<MemberModel> filteredList;
        public Members()
        {
            InitializeComponent();
            panelloading.Visible = true;
            MemberData.AutoGenerateColumns = false;
            backgroundWorkergetMember.RunWorkerAsync();
        }

        private void backgroundWorkergetMember_DoWork(object sender, DoWorkEventArgs e)
        {
            members = Global.memberService.getAllMember();
        }

        private void backgroundWorkergetMember_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(members != null)
            {
                panelloading.Visible = false;
                panelconnectionError.Visible = false;
                panelMemberView.Visible = true;
                Global.mangeDataGrid.GridRefresh(ref MemberData,members);
            }
            else
            {
                panelloading.Visible = false;
                panelconnectionError.Visible = true;
                panelMemberView.Visible = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                panelloading.Visible = true;
                panelconnectionError.Visible = false;
                panelMemberView.Visible = false;
                backgroundWorkergetMember.RunWorkerAsync();
            }catch(Exception ex)
            {
                Console.WriteLine($"Error! on backgroundWorkergetMember is : {ex.Message}");
            }
            
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if(textSearch.Text != "Search")
            {
                try
                {
                    backgroundWorkerMemberFilter.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error! on backgroundWorkerMemberFilter is : {ex.Message}");
                }
            }
        }

        private void backgroundWorkerMemberFilter_DoWork(object sender, DoWorkEventArgs e)
        {
            filteredList = members.Where(members => members.Name.ToLower().Contains(textSearch.Text) || members.Id.ToString().Contains(textSearch.Text) || members.Name.Contains(textSearch.Text) || members.Name.ToUpper().Contains(textSearch.Text)).ToList();
        }

        private void backgroundWorkerMemberFilter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (filteredList != null)
            {
                Global.mangeDataGrid.GridRefresh(ref MemberData, filteredList);
            }
        }

        private void textSearch_Enter(object sender, EventArgs e)
        {
            if (textSearch.Text == "Search")
            {
                textSearch.Text = string.Empty;
                textSearch.StateActive.Content.Color1 = Color.FromArgb(189, 188, 205);
                if (textSearch.TabStop == false)
                {
                    textSearch.TabStop = true;
                }
            }
        }

        private void textSearch_Leave(object sender, EventArgs e)
        {
            if (textSearch.Text == "")
            {
                textSearch.Text = "Search";
                textSearch.StateActive.Content.Color1 = Color.FromArgb(70, 71, 78);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Person add_Person = new Add_Person(Mem: true);
            add_Person.ShowDialog();
            panelloading.Visible = true;
            panelconnectionError.Visible = false;
            panelMemberView.Visible = false;
            backgroundWorkergetMember.RunWorkerAsync();
        }
    }
}
