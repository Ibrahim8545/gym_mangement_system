using Bunifu.UI.WinForms;
using BunifuAnimatorNS;
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
using static gym_management_system.Home;

namespace gym_management_system
{
    public partial class subscribe : Form
    {
        private PackgeModel packgeModel;
        private MonthOfferModel monthOfferModel;
        private List<ClassModel> classes;
        private List<ClassModel> classesListch = new List<ClassModel>();
        private List<MemberModel> memberModels;
        private List<ClassSubscriptionModel> classsubscriptionModels;
        private EmployeeModel employeeModel;
        private bool can_sub = false, supStatus;
        private int numOfCheckClassP = 0;
        private List<CheckBox> checkedClass;
        private Loading_Indicator loading_Indicator = new Loading_Indicator();
        private double price, disc;
        private bool pac = false, mon = false, cla = false, pri = false;
        public subscribe()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            btnCan.Focus();
        }

        private void RemoveAllControlsFromPanel(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                control.Dispose();
            }
            panel.Controls.Clear();
        }

        public subscribe(PackgeModel model, Image image, EmployeeModel employee)
        {
            InitializeComponent();
            pac = true;
            employeeModel = employee;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            btnCan.Focus();
            labelSub.Text = "Package Subscribtion";
            panelData.Visible = false;
            labelSub.Focus();
            packgeModel = model;
            price = packgeModel.MonthOffer.Price;
            disc = price - (price * ((packgeModel.DiscountPercentage) / 100.0));
            panelpackge.BackgroundImage = image;
            panelpackge.BackgroundImageLayout = ImageLayout.Stretch;
            labelpackgename.Text = packgeModel.Name;
            labelmonthoffer.Text = packgeModel.MonthOffer.NumOfMonth + " Month + " + packgeModel.MonthOffer.MaxNumFreze + " Freze day";
            labelnumclass.Text = packgeModel.NumOfClass + " Class";
            labelnuminvaite.Text = packgeModel.NumOfInvatation + " Invatiation";
            labelDiscount.Text = packgeModel.DiscountPercentage + "% Discount";
            btnSub.Enabled = false;
            labelprice.Text = disc + "EGP";
            panelPackgeSub.Visible = true;
        }

        public subscribe(MonthOfferModel model, Image image, EmployeeModel employee)
        {
            InitializeComponent();
            mon = true;
            employeeModel = employee;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            btnCan.Focus();
            labelSub.Text = "Month Subscribtion";
            panelData.Visible = false;
            labelSub.Focus();
            monthOfferModel = model;
            price = monthOfferModel.Price;
            panelMonth.BackgroundImage = image;
            panelMonth.BackgroundImageLayout = ImageLayout.Stretch;
            labelnumMonth.Text = monthOfferModel.NumOfMonth + " Month";
            labelfrezeNum.Text = monthOfferModel.MaxNumFreze + " Freze day";
            labelmonthprice.Text = price + "EGP";
            labelprice.Text = price + "EGP";
            btnSub.Enabled = false;
            panelMonthSubscription.Visible = true;
        }

        private void customCheckboxclasses(int x, int y, ClassModel classModel, Panel p)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.ForeColor = Color.FromArgb(70, 71, 78);
            Font checkFontNP = new Font(new FontFamily("Gilroy-SemiBold"), 28, FontStyle.Bold, GraphicsUnit.Pixel);
            checkBox.Font = checkFontNP;
            checkBox.Size = new Size(159, 48);
            checkBox.Location = new Point(x, y);
            checkBox.Text = classModel.Name;
            checkBox.Tag = classModel;
            p.Controls.Add(checkBox);
            checkBox.CheckedChanged += new EventHandler(checkBox_Checked);
        }

        private void checkBox_Checked(object sender, System.EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                if (checkBox.Checked)
                {
                    if (checkBox.Tag is ClassModel classModel)
                    {
                        classesListch.Add(classModel);
                        price += classModel.Price;
                        disc = price - (price * ((packgeModel.DiscountPercentage) / 100.0));
                        labelprice.Text = disc + "EGP";
                        numOfCheckClassP++;
                    }
                    if (numOfCheckClassP == packgeModel.NumOfClass)
                    {
                        if (!can_sub)
                        {
                            btnSub.Enabled = true;
                        }
                        foreach (CheckBox checkBox1 in panelclassesDataP.Controls.OfType<CheckBox>())
                        {
                            if (!checkBox1.Checked)
                            {
                                checkBox1.Enabled = false;
                            }
                        }
                    }
                }
                else
                {
                    if (checkBox.Tag is ClassModel classModel)
                    {
                        classesListch.Remove(classModel);
                        price -= classModel.Price;
                        disc = price - (price * ((packgeModel.DiscountPercentage) / 100.0));
                        labelprice.Text = disc + "EGP";
                        numOfCheckClassP--;
                    }
                    if (numOfCheckClassP == (packgeModel.NumOfClass)-1)
                    {
                        if (!can_sub)
                        {
                            btnSub.Enabled = false;
                        }
                        foreach (CheckBox checkBox1 in panelclassesDataP.Controls.OfType<CheckBox>())
                        {
                            if (!checkBox1.Checked)
                            {
                                checkBox1.Enabled = true;
                            }
                        }
                    }
                }
                
            }
                
        }

        private void subscribe_Load(object sender, EventArgs e)
        {

        }
        private List<MonthSubscriptionModel> model;
        private void btnCan_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if(textSearch.Text != "Search")
            {
                if(int.TryParse(textSearch.Text, out int id))
                {
                    memberModels = Global.memberService.Search(textSearch.Text, true, byId: true);
                    if(memberModels != null)
                    {
                        if (pac)
                        {
                            can_sub = Global.PackgeSupscribtionService.CheckMemberInPackageSubscription(memberModels[0].Id);
                            classes = Global.classService.GetUnsubscribedClasses(memberModels[0].Id, true, true);

                        }
                        else if (mon)
                        {
                            can_sub = Global.monthSubscriptionService.CheckMemberInMonthSubscription(memberModels[0].Id);
                        }
                    }   
                }
                else
                {
                    lab_search_err.Text = "Please enter id as a number";
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (memberModels != null)
            {
                labelName.Text = memberModels[0].Name;
                labelAge.Text = memberModels[0].Age.ToString();
                labelPhone.Text = memberModels[0].PhoneNumber;
                labelEmail.Text = memberModels[0].Email;
                labelBrithday.Text = memberModels[0].Brithday.ToString("yyyy/MM/dd");
                panelloading.Visible = false;
                panelNoDatamember.Visible = false;
                panelData.Visible = true;
                if (can_sub)
                {
                    labelCanSup.Text = "Can`t Subscripe";
                    labelCanSup.ForeColor = Color.FromArgb(255, 87, 51);
                    btnSub.Enabled = false;
                }
                else
                {
                    labelCanSup.Text = "Can Subscripe";
                    labelCanSup.ForeColor = Color.FromArgb(80, 200, 120);
                }
                if (pac)
                {
                    int y = 8;
                    RemoveAllControlsFromPanel(panelclassesDataP);
                    bool x = false;
                    if(classes != null)
                    {
                        foreach (ClassModel classModel in classes)
                        {
                            x = true;
                            customCheckboxclasses(10, y, classModel, panelclassesDataP);
                            y += 50;
                        }
                    }
                    panelloadingclassP.Visible = false;
                    panelnoDataclasesP.Visible = x != false ? false : true;
                    panelclassesDataP.Visible = x;
                }
                
            }
            else
            {
                panelloading.Visible = false;
                panelNoDatamember.Visible = true;
                panelData.Visible = false;
                if (pac)
                {
                    panelloadingclassP.Visible = false;
                    panelnoDataclasesP.Visible = true;
                    panelclassesDataP.Visible = false;
                }
            }
        }
        public void Enter_Key(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(textSearch.Text != "Search")
            {
                try
                {
                    panelloading.Visible = true;
                    panelNoDatamember.Visible = false;
                    panelData.Visible = false;
                    labelsubError.Visible = false;
                    if(pac)
                    {
                        panelloadingclassP.Visible = true;
                        panelnoDataclasesP.Visible = false;
                        panelclassesDataP.Visible = false;
                    }
                    backgroundWorker1.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error! backgond Worker search is {ex.Message}");
                }
            }
            
        }

        private void textSearch_Enter(object sender, EventArgs e)
        {
            if(textSearch.Text == "Search")
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

        private void btnSub_Click(object sender, EventArgs e)
        {
            loading_Indicator.Show();
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loading_Indicator.Hide();
            if (supStatus)
            {
                labelsubError.Visible = false;
                labelSub.Text = "Can`t Subscripe";
                labelCanSup.ForeColor = Color.FromArgb(255, 87, 51);
            }
            else
            {
                labelsubError.Visible = true;
                labelsubError.Text = "Error on Subscribtion";
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (pac)
            {
                supStatus = Global.PackgeSupscribtionService.SubscribePackage(packgeModel, memberModels[0], employeeModel, classesListch);
            }
            else if(mon)
            {

            }else if(cla)
            {

            }else if(pri)
            {

            }
            
        }
    }
}
