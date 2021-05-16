using System.Windows.Forms;

namespace MinesweeperTask.Logic.Model
{
    class Cell : Button
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public bool IsMine { get; set; }

        public int NeighborsWithMineCount { get; set; }

        public bool HasFlag { get; set; }

        public bool HasQuestion { get; set; }

        public bool IsOpened { get; set; } = false;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
