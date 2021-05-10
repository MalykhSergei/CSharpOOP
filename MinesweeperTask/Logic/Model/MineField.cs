using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperTask.Logic.Model
{
    class MineField
    {
        private readonly Cell[,] cells;

        public int Width => cells.GetLength(0);

        public int Height => cells.GetLength(1);

        public MineField(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentException(nameof(width), "width must be > 0");
            }

            if (height <= 0)
            {
                throw new ArgumentException(nameof(height), "height must be > 0");
            }

            cells = new Cell[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[y, x] = new Cell();
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return cells[y, x];
        }
    }
}
