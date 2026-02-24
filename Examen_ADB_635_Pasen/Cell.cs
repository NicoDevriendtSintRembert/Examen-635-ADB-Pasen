using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_ADB_635_Pasen
{
    enum statusCell
    {
        Raak,
        Mis,
        Boot,
        Empty
    }
    internal class Cell
    {
        public statusCell Status { get; set; }

        public Cell()
        {
            Status = statusCell.Empty;
        }
        public Cell(statusCell status)
        {
            Status = status;
        }
    }
}
