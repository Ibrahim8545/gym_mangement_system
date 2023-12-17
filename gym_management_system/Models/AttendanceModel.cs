using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public abstract class AttendanceModel
    {
        protected int id;
        protected DateTime date;

        protected AttendanceModel(int id = 0, DateTime date = default)
        {
            Id = id;
            Date = date;
        }

        public DateTime Date { get => date; set => date = value; }
        public int Id { get => id; set => id = value; }
    }
}
