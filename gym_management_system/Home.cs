using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using gym_management_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system
{
    public partial class Home : Form
    {
        private List<ClassModel> classModels;
        private List<PackgeModel> packgeModels;
        private List<MonthOfferModel> monthOfferModels;
        private List<TrainerModel> trainersModels;
        private bool firstGetData = false;
        public Home()
        {
            InitializeComponent();
            panelschdata.Visible = false;
            backgroundWorkerclassSch.RunWorkerAsync();
            backgroundWorkerpackages.RunWorkerAsync();
            backgroundWorkerMonth.RunWorkerAsync();
            backgroundWorkerClsss.RunWorkerAsync();
            backgroundWorkertrainer.RunWorkerAsync();
        }

        private void customPackgePanel(int x, int y, PackgeModel packgeModel)
        {
            Bunifu.UI.WinForms.BunifuGradientPanel panel = new Bunifu.UI.WinForms.BunifuGradientPanel();
            Label lName = new Label();
            Label LMD = new Label();
            Label LCD = new Label();
            Label LNI = new Label();
            panel.Controls.Add(lName);
            panel.Controls.Add(LMD);
            panel.Controls.Add(LCD);
            panel.Controls.Add(LNI);
            Font labelFontNP = new Font(new FontFamily("Gilroy-SemiBold"), 34, FontStyle.Bold, GraphicsUnit.Pixel);
            Font labelFont = new Font(new FontFamily("Gilroy-SemiBold"), 12, FontStyle.Bold, GraphicsUnit.Point);
            panel.BorderRadius = 50;
            panel.Size = new System.Drawing.Size(367, 199);
            panel.Location = new System.Drawing.Point(x, y);
            panel.Tag = packgeModel;
            lName.Font = labelFontNP;
            lName.Text = packgeModel.Name;
            lName.Location = new System.Drawing.Point(2, 53);
            lName.Size = new Size(293, 49);
            lName.Tag = packgeModel;
            LMD.Font = labelFont;
            LMD.Text = packgeModel.MonthOffer.NumOfMonth + " Month + " + packgeModel.MonthOffer.MaxNumFreze + " Freze day";
            LMD.Location = new System.Drawing.Point(8, 102);
            LMD.Size = new Size(280, 29);
            LMD.Tag = packgeModel;
            LCD.Font = labelFont;
            LCD.Text = packgeModel.NumOfClass + " Class";
            LCD.Location = new System.Drawing.Point(8, 131);
            LCD.Size = new Size(280, 29);
            LCD.Tag = packgeModel;
            LNI.Font = labelFont;
            LNI.Text = packgeModel.NumOfInvatation + " Invatiation";
            LNI.Location = new System.Drawing.Point(8, 160);
            LNI.Size = new Size(280, 29);
            LNI.Tag = packgeModel;
            panelPackage.Controls.Add(panel);
            panel.Click += new System.EventHandler(panalPackge_Click);
            LNI.Click += new System.EventHandler(panalPackge_Click);
            lName.Click += new System.EventHandler(panalPackge_Click);
            LMD.Click += new System.EventHandler(panalPackge_Click);
            LCD.Click += new System.EventHandler(panalPackge_Click);
        }

        private void customMonthPanel(int x, int y, MonthOfferModel monthOfferModel)
        {
            Bunifu.UI.WinForms.BunifuGradientPanel panel = new Bunifu.UI.WinForms.BunifuGradientPanel();
            Label lName = new Label();
            Label LFD = new Label();
            Label LPD = new Label();
            panel.Controls.Add(lName);
            panel.Controls.Add(LFD);
            panel.Controls.Add(LPD);
            Font labelFontNP = new Font(new FontFamily("Gilroy-SemiBold"), 34, FontStyle.Bold, GraphicsUnit.Pixel);
            Font labelFont = new Font(new FontFamily("Gilroy-SemiBold"), 12, FontStyle.Bold, GraphicsUnit.Point);
            panel.BorderRadius = 50;
            panel.Size = new System.Drawing.Size(367, 199);
            panel.Location = new System.Drawing.Point(x, y);
            panel.Tag = monthOfferModel;
            lName.Font = labelFontNP;
            lName.Text = monthOfferModel.NumOfMonth + " Month";
            lName.Location = new System.Drawing.Point(2, 53);
            lName.Size = new Size(293, 49);
            lName.Tag = monthOfferModel;
            LFD.Font = labelFont;
            LFD.Text = monthOfferModel.MaxNumFreze + " Freze Number";
            LFD.Location = new System.Drawing.Point(8, 102);
            LFD.Size = new Size(280, 29);
            LFD.Tag = monthOfferModel;
            LPD.Font = labelFont;
            LPD.Text = monthOfferModel.Price + "$";
            LPD.Location = new System.Drawing.Point(8, 131);
            LPD.Size = new Size(280, 29);
            LPD.Tag = monthOfferModel;
            panelMonth.Controls.Add(panel);
            panel.Click += new System.EventHandler(panalMonth_Click);
            lName.Click += new System.EventHandler(panalMonth_Click);
            LFD.Click += new System.EventHandler(panalMonth_Click);
            LPD.Click += new System.EventHandler(panalMonth_Click);
        }

        private void customClassPanel(int x, int y, ClassModel classModel)
        {
            Bunifu.UI.WinForms.BunifuGradientPanel panel = new Bunifu.UI.WinForms.BunifuGradientPanel();
            Label lName = new Label();
            Label LS1D = new Label();
            Label LS2D = new Label();
            Label LTN = new Label();
            Label LP = new Label();
            panel.Controls.Add(lName);
            panel.Controls.Add(LS1D);
            panel.Controls.Add(LS2D);
            panel.Controls.Add(LTN);
            panel.Controls.Add(LP);
            Font labelFontNP = new Font(new FontFamily("Gilroy-SemiBold"), 34, FontStyle.Bold, GraphicsUnit.Pixel);
            Font labelFont = new Font(new FontFamily("Gilroy-SemiBold"), 12, FontStyle.Bold, GraphicsUnit.Point);
            panel.BorderRadius = 50;
            panel.Size = new System.Drawing.Size(367, 199);
            panel.Location = new System.Drawing.Point(x, y);
            panel.Tag = classModel;
            lName.Font = labelFontNP;
            lName.Text = classModel.Name;
            lName.Location = new System.Drawing.Point(2, 33);
            lName.Size = new Size(293, 49);
            lName.Tag = classModel;
            LS1D.Font = labelFont;
            LS1D.Text = classModel.SessionOneDayName;
            LS1D.Location = new System.Drawing.Point(8, 82);
            LS1D.Size = new Size(280, 29);
            LS1D.Tag = classModel;
            LS2D.Font = labelFont;
            LS2D.Text = classModel.SessionTwoDayName;
            LS2D.Location = new System.Drawing.Point(8, 111);
            LS2D.Size = new Size(280, 29);
            LS2D.Tag = classModel;
            LTN.Font = labelFont;
            LTN.Text = classModel.TrainerModel.Name;
            LTN.Location = new System.Drawing.Point(8, 140);
            LTN.Size = new Size(280, 29);
            LTN.Tag = classModel;
            LP.Font = labelFont;
            LP.Text = classModel.Price + "$";
            LP.Location = new System.Drawing.Point(8, 169);
            LP.Size = new Size(280, 29);
            LP.Tag = classModel;
            panelClass.Controls.Add(panel);
            panel.Click += new System.EventHandler(panalClass_Click);
            lName.Click += new System.EventHandler(panalClass_Click);
            LS1D.Click += new System.EventHandler(panalClass_Click);
            LS2D.Click += new System.EventHandler(panalClass_Click);
            LTN.Click += new System.EventHandler(panalClass_Click);
            LP.Click += new System.EventHandler(panalClass_Click);
        }

        private void customTrainerPanel(int x, int y, TrainerModel trainerModel)
        {
            Bunifu.UI.WinForms.BunifuGradientPanel panel = new Bunifu.UI.WinForms.BunifuGradientPanel();
            Label lName = new Label();
            Label LSD = new Label();
            Label LPD = new Label();
            panel.Controls.Add(lName);
            panel.Controls.Add(LSD);
            panel.Controls.Add(LPD);
            Font labelFontNP = new Font(new FontFamily("Gilroy-SemiBold"), 34, FontStyle.Bold, GraphicsUnit.Pixel);
            Font labelFont = new Font(new FontFamily("Gilroy-SemiBold"), 12, FontStyle.Bold, GraphicsUnit.Point);
            panel.BorderRadius = 50;
            panel.Size = new System.Drawing.Size(367, 199);
            panel.Location = new System.Drawing.Point(x, y);
            panel.Tag = trainerModel;
            lName.Font = labelFontNP;
            lName.Text = trainerModel.Name;
            lName.Location = new System.Drawing.Point(2, 68);
            lName.Size = new Size(293, 49);
            lName.Tag = trainerModel;
            LSD.Font = labelFont;
            LSD.Text = trainerModel.Specialization;
            LSD.Location = new System.Drawing.Point(8, 117);
            LSD.Size = new Size(280, 29);
            LSD.Tag = trainerModel;
            LPD.Font = labelFont;
            LPD.Text = trainerModel.PrivateLessonPrice + "$";
            LPD.Location = new System.Drawing.Point(8, 146);
            LPD.Size = new Size(280, 29);
            LPD.Tag = trainerModel;
            panelTrainer.Controls.Add(panel);
            panel.Click += new System.EventHandler(panalTrainer_Click);
            lName.Click += new System.EventHandler(panalTrainer_Click);
            LSD.Click += new System.EventHandler(panalTrainer_Click);
            LPD.Click += new System.EventHandler(panalTrainer_Click);
        }

        private void panalPackge_Click(object sender, System.EventArgs e)
        {
            if (sender is Control control)
            {
                if ((control.Parent is Bunifu.UI.WinForms.BunifuGradientPanel panel && panel.Tag is PackgeModel packgeModel))
                {
                    MessageBox.Show($"Clicked on {packgeModel.Name}");
                    return;
                }
                if (control.Tag is PackgeModel packgeModel1)
                {
                    MessageBox.Show($"Clicked on {packgeModel1.Name}");
                }
            }
        }

        private void panalMonth_Click(object sender, System.EventArgs e)
        {
            if (sender is Control control)
            {
                if ((control.Parent is Bunifu.UI.WinForms.BunifuGradientPanel panel && panel.Tag is MonthOfferModel monthOfferModel))
                {
                    MessageBox.Show($"Clicked on {monthOfferModel.Price}");
                    return;
                }
                if (control.Tag is MonthOfferModel monthOfferModel1)
                {
                    MessageBox.Show($"Clicked on {monthOfferModel1.Price}");
                }
            }
        }

        private void panalClass_Click(object sender, System.EventArgs e)
        {
            if (sender is Control control)
            {
                if ((control.Parent is Bunifu.UI.WinForms.BunifuGradientPanel panel && panel.Tag is ClassModel classModel))
                {
                    MessageBox.Show($"Clicked on {classModel.Price}");
                    return;
                }
                if (control.Tag is ClassModel classModel1)
                {
                    MessageBox.Show($"Clicked on {classModel1.Price}");
                }
            }
        }

        private void panalTrainer_Click(object sender, System.EventArgs e)
        {
            if (sender is Control control)
            {
                if ((control.Parent is Bunifu.UI.WinForms.BunifuGradientPanel panel && panel.Tag is TrainerModel trainerModel))
                {
                    MessageBox.Show($"Clicked on {trainerModel.Name}");
                    return;
                }
                if (control.Tag is TrainerModel trainerModel1)
                {
                    MessageBox.Show($"Clicked on {trainerModel1.Name}");
                }
            }
        }

        private void loadClass()
        {
            classModels = Global.classService.GetAllClasses(true,true);
        }

        private void loadPackage()
        {
            packgeModels = Global.packgeService.GetAllPackages(true);
        }

        private void loadMonth()
        {
            monthOfferModels = Global.monthOfferService.GetAllMonthOffers();
        }

        private void loadTrainer()
        {
            trainersModels = Global.trainerService.getAllTrainer(true,false);
        }

        private void updateLabel(Label p, string text)
        {
            if (labeld1c1.InvokeRequired)
            {
                labeld1c1.Invoke((MethodInvoker)delegate {
                    p.Text = text;
                });
            }
            else
            {
                p.Text = text;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                loadClass();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Error! from connection: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error! from connection: {ex.Message}");
            }
            int Sat = 0, Sun = 0, Mon = 0, Tue = 0, Wed = 0, Thu = 0, Fri = 0;
            if (classModels != null)
            {
                foreach (ClassModel classModel in classModels)
                {
                    int count = 0;
                    if (classModel.SessionOneDayName == "Saterday" || classModel.SessionTwoDayName == "Saterday")
                    {
                        if (count == 2)
                        {
                            continue;
                        }
                        if (Sat == 0)
                        {
                            updateLabel(labeld1c1, classModel.Name);
                        }
                        else if (Sat == 1)
                        {
                            updateLabel(labeld1c2, classModel.Name);
                        }
                        else if (Sat == 2)
                        {
                            updateLabel(labeld1c2, classModel.Name);
                        }
                        else
                        {
                            Console.WriteLine("Error! Get From Data");
                            continue;
                        }
                        count++;
                        Sat++;
                    }
                    if (classModel.SessionOneDayName == "Sunday" || classModel.SessionTwoDayName == "Sunday")
                    {
                        if (count == 2)
                        {
                            continue;
                        }
                        if (Sun == 0)
                        {
                            updateLabel(labeld2c1, classModel.Name);
                        }
                        else if (Sun == 1)
                        {
                            updateLabel(labeld2c2, classModel.Name);
                        }
                        else if (Sun == 2)
                        {
                            updateLabel(labeld2c3, classModel.Name);
                        }
                        else
                        {
                            Console.WriteLine("Error! Get From Data");
                            continue;
                        }
                        count++;
                        Sun++;
                    }
                    if (classModel.SessionOneDayName == "Monday" || classModel.SessionTwoDayName == "Monday")
                    {
                        if (count == 2)
                        {
                            continue;
                        }
                        if (Mon == 0)
                        {
                            updateLabel(labeld3c1, classModel.Name);
                        }
                        else if (Mon == 1)
                        {
                            updateLabel(labeld3c2, classModel.Name);
                        }
                        else if (Mon == 2)
                        {
                            updateLabel(labeld3c3, classModel.Name);
                        }
                        else
                        {
                            Console.WriteLine("Error! Get From Data");
                            continue;
                        }
                        count++;
                        Mon++;
                    }
                    if (classModel.SessionOneDayName == "Tuesday" || classModel.SessionTwoDayName == "Tuesday")
                    {
                        if (count == 2)
                        {
                            continue;
                        }
                        if (Tue == 0)
                        {
                            updateLabel(labeld4c1, classModel.Name);
                        }
                        else if (Tue == 1)
                        {
                            updateLabel(labeld4c2, classModel.Name);
                        }
                        else if (Tue == 2)
                        {
                            updateLabel(labeld4c3, classModel.Name);
                        }
                        else
                        {
                            Console.WriteLine("Error! Get From Data");
                            continue;
                        }
                        count++;
                        Tue++;
                    }
                    if (classModel.SessionOneDayName == "Wensday" || classModel.SessionTwoDayName == "Wensday")
                    {
                        if (count == 2)
                        {
                            continue;
                        }
                        if (Wed == 0)
                        {
                            updateLabel(labeld5c1, classModel.Name);
                        }
                        else if (Wed == 1)
                        {
                            updateLabel(labeld5c2, classModel.Name);
                        }
                        else if (Wed == 2)
                        {
                            updateLabel(labeld5c3, classModel.Name);
                        }
                        else
                        {
                            Console.WriteLine("Error! Get From Data");
                            continue;
                        }
                        count++;
                        Wed++;
                    }
                    if (classModel.SessionOneDayName == "Thuresday" || classModel.SessionTwoDayName == "Thuresday")
                    {
                        if (count == 2)
                        {
                            continue;
                        }
                        if (Thu == 0)
                        {
                            updateLabel(labeld6c1, classModel.Name);
                        }
                        else if (Thu == 1)
                        {
                            updateLabel(labeld6c2, classModel.Name);
                        }
                        else if (Thu == 2)
                        {
                            updateLabel(labeld6c3, classModel.Name);
                        }
                        else
                        {
                            Console.WriteLine("Error! Get From Data");
                            continue;
                        }
                        count++;
                        Thu++;
                    }
                    if (classModel.SessionOneDayName == "Friday" || classModel.SessionTwoDayName == "Friday")
                    {
                        if (count == 2)
                        {
                            continue;
                        }
                        if (Fri == 0)
                        {
                            updateLabel(labeld7c1, classModel.Name);
                        }
                        else if (Fri == 1)
                        {
                            updateLabel(labeld7c2, classModel.Name);
                        }
                        else if (Fri == 2)
                        {
                            updateLabel(labeld7c3, classModel.Name);
                        }
                        else
                        {
                            Console.WriteLine("Error! Get From Data");
                            continue;
                        }
                        count++;
                        Fri++;
                    }
                }
            }
            if (firstGetData)
            {
                for(int i =0; i < 7; i++)
                {
                    switch (i)
                    {
                        case 0:
                        {
                            if (Sat == 3)
                            {
                                continue;
                            }
                            if (Sat == 0)
                            {
                                updateLabel(labeld1c1, "");
                                updateLabel(labeld1c2, "");
                                updateLabel(labeld1c3, "");
                            }
                            else if (Sat == 2)
                            {
                                updateLabel(labeld1c3, "");
                            }
                            else if (Sat == 1)
                            {
                                updateLabel(labeld1c2, "");
                                updateLabel(labeld1c3, "");
                            }
                            break;
                        }   
                        case 1:
                        {
                            if (Sun == 3)
                            {
                                continue;
                            }
                            if (Sun == 0)
                            {
                                updateLabel(labeld2c1, "");
                                updateLabel(labeld2c2, "");
                                updateLabel(labeld2c3, "");
                            }
                            else if (Sun == 2)
                            {
                                updateLabel(labeld2c3, "");
                            }
                            else if (Sun == 1)
                            {
                                updateLabel(labeld2c2, "");
                                updateLabel(labeld2c3, "");
                            }
                            break;
                        }
                        case 2:
                        {
                            if (Mon == 3)
                            {
                                continue;
                            }
                            if (Mon == 0)
                            {
                                updateLabel(labeld3c1, "");
                                updateLabel(labeld3c2, "");
                                updateLabel(labeld3c3, "");
                            }
                            else if (Mon == 2)
                            {
                                updateLabel(labeld3c3, "");
                            }
                            else if (Mon == 1)
                            {
                                updateLabel(labeld3c2, "");
                                updateLabel(labeld3c3, "");
                            }
                            break;
                        }
                        case 3:
                        {
                            if (Tue == 3)
                            {
                                continue;
                            }
                            if (Tue == 0)
                            {
                                updateLabel(labeld4c1, "");
                                updateLabel(labeld4c2, "");
                                updateLabel(labeld4c3, "");
                            }
                            else if (Tue == 2)
                            {
                                updateLabel(labeld4c3, "");
                            }
                            else if (Tue == 1)
                            {
                                updateLabel(labeld4c2, "");
                                updateLabel(labeld4c3, "");
                            }
                            break;
                        }
                        case 4:
                        {
                            if (Wed == 3)
                            {
                                continue;
                            }
                            if (Wed == 0)
                            {
                                updateLabel(labeld5c1, "");
                                updateLabel(labeld5c2, "");
                                updateLabel(labeld5c3, "");
                            }
                            else if (Wed == 2)
                            {
                                updateLabel(labeld5c3, "");
                            }
                            else if (Wed == 1)
                            {
                                updateLabel(labeld5c2, "");
                                updateLabel(labeld5c3, "");
                            }
                            break;
                        }
                        case 5:
                        {
                            if (Thu == 3)
                            {
                                continue;
                            }
                            if (Thu == 0)
                            {
                                updateLabel(labeld6c1, "");
                                updateLabel(labeld6c2, "");
                                updateLabel(labeld6c3, "");
                            }
                            else if (Thu == 2)
                            {
                                updateLabel(labeld6c3, "");
                            }
                            else if (Thu == 1)
                            {
                                updateLabel(labeld6c2, "");
                                updateLabel(labeld6c3, "");
                            }
                            break;
                        }
                        case 6:
                        {
                            if (Fri == 3)
                            {
                                continue;
                            }
                            if (Fri == 0)
                            {
                                updateLabel(labeld7c1, "");
                                updateLabel(labeld7c2, "");
                                updateLabel(labeld7c3, "");
                            }
                            else if (Fri == 2)
                            {
                                updateLabel(labeld7c3, "");
                            }
                            else if (Fri == 1)
                            {
                                updateLabel(labeld7c2, "");
                                updateLabel(labeld7c3, "");
                            }
                            break;
                        }
                    }
                    
                }
            }
            firstGetData = true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(classModels == null)
            {
                panelloading.Visible = false;
                panelschdata.Visible = false;
                panelconnectionError.Visible = true;
                return;
            }
            panelloading.Visible = false;
            panelschdata.Visible = true;
            panelconnectionError.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerclassSch.RunWorkerAsync();
                panelloading.Visible = true;
                panelschdata.Visible = false;
                panelconnectionError.Visible = false;
            }catch (Exception ex)
            {
                Console.WriteLine($"Error! from background worker: {ex.Message}");
            }
        }

        private void timerScheduleRef_Tick(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerclassSch.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! from background worker: {ex.Message}");
            }
        }

        private void backgroundWorkerpackages_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                loadPackage();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Error! from connection: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error! from connection: {ex.Message}");
            }

        }

        private void backgroundWorkerpackages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int x = 10;
            if(packgeModels != null)
            {
                foreach (PackgeModel model in packgeModels)
                {
                    customPackgePanel(x, 32, model);
                    x += 400;
                }
                panelloadingpackge.Visible = false;
                panelPackage.Visible = true;
                panelconnectionerrorpackage.Visible = false;
            }
            else
            {
                panelloadingpackge.Visible = false;
                panelPackage.Visible = false;
                panelconnectionerrorpackage.Visible = true;
            }
            
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerpackages.RunWorkerAsync();
                panelloadingpackge.Visible = true;
                panelPackage.Visible = false;
                panelconnectionerrorpackage.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! from background worker: {ex.Message}");
            }
        }

        private void backgroundWorkerMonth_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                loadMonth();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Error! from connection: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error! from connection: {ex.Message}");
            }
        }

        private void backgroundWorkerMonth_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int x = 10;
            if (monthOfferModels != null)
            {
                foreach (MonthOfferModel model in monthOfferModels)
                {
                    customMonthPanel(x, 32, model);
                    x += 400;
                }
                panelloadingmonth.Visible = false;
                panelMonth.Visible = true;
                panelconnectionerrormonth.Visible = false;
            }
            else
            {
                panelloadingmonth.Visible = false;
                panelMonth.Visible = false;
                panelconnectionerrormonth.Visible = true;
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerMonth.RunWorkerAsync();
                panelloadingmonth.Visible = true;
                panelMonth.Visible = false;
                panelconnectionerrormonth.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! from background worker: {ex.Message}");
            }
        }

        private void backgroundWorkerClsss_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                loadClass();
            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"Error! from background worker: {ex.Message}"); 
            }
            
        }

        private void backgroundWorkerClsss_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int x = 10;
            if (classModels != null)
            {
                foreach (ClassModel model in classModels)
                {
                    customClassPanel(x, 32, model);
                    x += 400;
                }
                panelloadingclass.Visible = false;
                panelClass.Visible = true;
                panelconnectionerrorclass.Visible = false;
            }
            else
            {
                panelloadingclass.Visible = false;
                panelClass.Visible = false;
                panelconnectionerrorclass.Visible = true;
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerClsss.RunWorkerAsync();
                panelloadingclass.Visible = true;
                panelClass.Visible = false;
                panelconnectionerrorclass.Visible = false;
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Error! from connection: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error! from connection: {ex.Message}");
            }
        }

        private void backgroundWorkertrainer_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                loadTrainer();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Error! from connection: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error! from connection: {ex.Message}");
            }
        }

        private void backgroundWorkertrainer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int x = 10;
            if (trainersModels != null)
            {
                foreach (TrainerModel model in trainersModels)
                {
                    customTrainerPanel(x, 32, model);
                    x += 400;
                }
                panelloadingtrainer.Visible = false;
                panelTrainer.Visible = true;
                panelconnectionerrortrainer.Visible = false;
            }
            else
            {
                panelloadingtrainer.Visible = false;
                panelTrainer.Visible = false;
                panelconnectionerrortrainer.Visible = true;
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerClsss.RunWorkerAsync();
                panelloadingtrainer.Visible = true;
                panelTrainer.Visible = false;
                panelconnectionerrortrainer.Visible = false;
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Error! from connection: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error! from connection: {ex.Message}");
            }
        }
    }
}
