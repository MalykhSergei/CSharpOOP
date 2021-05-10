using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperTask.Logic.Model
{
    class Cell : Button
    {
        public bool IsMine { get; set; }

        public int NeighborsWithMineCount { get; set; }

        public bool HasFlag { get; set; }

        public bool HasQuestion { get; set; }

        public bool IsVisible { get; set; }
    }
}
