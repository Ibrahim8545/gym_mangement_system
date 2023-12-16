using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class AnnoucementModl
    {
        private int id;
        private string title, content, base64Image;
        private DateTime date;
        private Image picture;
        private EmployeeModel employeeModel;

        public AnnoucementModl(int id = 0, string title = null, string content = null, Image picture = null, string base64Image = null, DateTime date = default, EmployeeModel employeeModel = null)
        {
            Id = id;
            Title = title;
            Date = date;
            Picture = picture;
            Content = content;
            Base64Image = base64Image;
            EmployeeModel = employeeModel;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Content { get { return content; } set { content = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public Image Picture { get { return picture; } set { picture = value; } }
        public string Base64Image { get { return base64Image; } set { base64Image = value; } }
        public EmployeeModel EmployeeModel { get { return employeeModel; } set { employeeModel = value; } }

    }
}
