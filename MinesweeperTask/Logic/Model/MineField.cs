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

        public MineField(int width, int height, int minesCount)
        {
            if (width <= 0)
            {
                throw new ArgumentException(nameof(width), "width must be > 0");
            }

            if (height <= 0)
            {
                throw new ArgumentException(nameof(height), "height must be > 0");
            }

            if (minesCount < 1)
            {
                throw new ArgumentException(nameof(minesCount), "Count of mines must be > 1");
            }

            if (minesCount > width * height)
            {
                throw new ArgumentException(nameof(minesCount), "Count of mines must be less than the count of cells");
            }

            cells = new Cell[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[y, x] = new Cell(x,y);
                }
            }

            PlaceMines(minesCount);
        }

        private void PlaceMines(int minesCount)
        {
            Random random = new Random();

            int minesLeft = minesCount;

            while (minesLeft > 0)
            {
                int x = random.Next(Width);
                int y = random.Next(Height);

                Cell cell = GetCell(x, y);

                if (!cell.IsMine)
                {
                    PlaceMine(cell, x, y);
                    minesLeft--;
                }
            }
        }

        private void PlaceMine(Cell cell, int x, int y)
        {
            cell.IsMine = true;

            foreach (Cell c in GetNeighbours(x, y))
            {
                if (!c.IsMine)
                {
                    c.NeighborsWithMineCount++;
                }
            }
        }

        public List<Cell> GetNeighbours(int x, int y)
        {
            List<Cell> cells = new List<Cell>();

            for (int dy = -1; dy <= 1; dy++)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    int currentX = x + dx;
                    int currentY = y + dy;

                    if (currentX < 0 || currentX >= Width || currentY < 0 || currentY >= Height)
                    {
                        continue;
                    }

                    cells.Add(GetCell(currentX, currentY));
                }
            }

            return cells;
        }

        public void SetAllCellsOpened()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Cell c = GetCell(x, y);
                    c.IsOpened = true;
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return cells[y, x];
        }
    }
}
