using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system.Manger
{
    public class MangeDataGrid
    {
        public void GridRefresh<T>(ref DataGridView dgv, List<T> data)
        {
            if (data != null)
            {
                dgv.DataSource = data;
                dgv.ClearSelection();
            }
        }
    }
}
