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
    public partial class Home : Form
    {
        private List<ClassModel> classModels;
        public Home()
        {
            InitializeComponent();
            loadSchedule();
        }

        private void loadSchedule()
        {
            int Sat = 0, Sun = 0, Mon = 0, Tue = 0, Wed = 0, Thu = 0, Fri = 0;
            classModels = Global.classService.GetAllClasses();
            foreach (ClassModel classModel in classModels)
            {
                if(classModel.SessionOneDayName == "Saterday")
                {
                    if(Sat == 0)
                    {
                        labeld1c1.Text = classModel.Name;
                    }else if(Sat == 1)
                    {
                        labeld1c2.Text = classModel.Name;
                    }
                    else if(Sat == 2)
                    {
                        labeld1c3.Text = classModel.Name;
                    }
                    else
                    {
                        Console.WriteLine("Error! Get From Data");
                        continue;
                    }
                    Sat ++;
                }
                else if (classModel.SessionOneDayName == "Sunday")
                {
                    if (Sun == 0)
                    {
                        labeld2c1.Text = classModel.Name;
                    }
                    else if (Sun == 1)
                    {
                        labeld2c2.Text = classModel.Name;
                    }
                    else if (Sun == 2)
                    {
                        labeld2c3.Text = classModel.Name;
                    }
                    else
                    {
                        Console.WriteLine("Error! Get From Data");
                        continue;
                    }
                    Sun++;
                }
                else if (classModel.SessionOneDayName == "Monday")
                {
                    if (Mon == 0)
                    {
                        labeld2c1.Text = classModel.Name;
                    }
                    else if (Mon == 1)
                    {
                        labeld2c2.Text = classModel.Name;
                    }
                    else if (Mon == 2)
                    {
                        labeld2c3.Text = classModel.Name;
                    }
                    else
                    {
                        Console.WriteLine("Error! Get From Data");
                        continue;
                    }
                    Mon++;
                }
                else if (classModel.SessionOneDayName == "Tuesday")
                {
                    if (Tue == 0)
                    {
                        labeld3c1.Text = classModel.Name;
                    }
                    else if (Tue == 1)
                    {
                        labeld3c2.Text = classModel.Name;
                    }
                    else if (Tue == 2)
                    {
                        labeld3c3.Text = classModel.Name;
                    }
                    else
                    {
                        Console.WriteLine("Error! Get From Data");
                        continue;
                    }
                    Tue++;
                }
                else if (classModel.SessionOneDayName == "Wensday")
                {
                    if (Wed == 0)
                    {
                        labeld4c1.Text = classModel.Name;
                    }
                    else if (Wed == 1)
                    {
                        labeld4c2.Text = classModel.Name;
                    }
                    else if (Wed == 2)
                    {
                        labeld4c3.Text = classModel.Name;
                    }
                    else
                    {
                        Console.WriteLine("Error! Get From Data");
                        continue;
                    }
                    Wed++;
                }
                else if (classModel.SessionOneDayName == "Wensday")
                {
                    if (Wed == 0)
                    {
                        labeld5c1.Text = classModel.Name;
                    }
                    else if (Wed == 1)
                    {
                        labeld5c2.Text = classModel.Name;
                    }
                    else if (Wed == 2)
                    {
                        labeld5c3.Text = classModel.Name;
                    }
                    else
                    {
                        Console.WriteLine("Error! Get From Data");
                        continue;
                    }
                    Wed++;
                }
                else if (classModel.SessionOneDayName == "Thuresday")
                {
                    if (Thu == 0)
                    {
                        labeld6c1.Text = classModel.Name;
                    }
                    else if (Thu == 1)
                    {
                        labeld6c2.Text = classModel.Name;
                    }
                    else if (Thu == 2)
                    {
                        labeld6c3.Text = classModel.Name;
                    }
                    else
                    {
                        Console.WriteLine("Error! Get From Data");
                        continue;
                    }
                    Thu++;
                }
                else if (classModel.SessionOneDayName == "Friday")
                {
                    if (Fri == 0)
                    {
                        labeld7c1.Text = classModel.Name;
                    }
                    else if (Fri == 1)
                    {
                        labeld7c2.Text = classModel.Name;
                    }
                    else if (Fri == 2)
                    {
                        labeld7c3.Text = classModel.Name;
                    }
                    else
                    {
                        Console.WriteLine("Error! Get From Data");
                        continue;
                    }
                    Fri++;
                }
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            loadSchedule();
        }
    }
}
