using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinesweeperTask.Logic.Model;

namespace MinesweeperTask
{
    public partial class Form1 : Form
    {
        private readonly MineField mineField = new MineField(9, 9, 10);
        private Cell cell;

        public Form1()
        {
            InitializeComponent();

            PrintField();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PrintField()
        {
            tablePanel.ColumnCount = mineField.Width;
            tablePanel.RowCount = mineField.Height;

            for (int y = 0; y < mineField.Height; y++)
            {
                for (int x = 0; x < mineField.Width; x++)
                {
                    cell = mineField.GetCell(x, y);

                    cell.Height = 35;
                    cell.Width = 35;
                    cell.Dock = DockStyle.Fill;
                    cell.Margin = new Padding(0);

                    cell.MouseUp += new MouseEventHandler(FieldButtonClick);

                    tablePanel.Controls.Add(cell);
                }
            }

            ClientSize = new Size(cell.Width * mineField.Width, cell.Height * mineField.Height + flowPanel.Height);
        }

        void FieldButtonClick(object sender, MouseEventArgs e)
        {
            Cell cell = (Cell)sender;
            cell.Dock = DockStyle.Fill;
            cell.Margin = new Padding(0);
            cell.Size = new Size(cell.Width, cell.Height);

            if (e.Button == MouseButtons.Left)
            {
                if (cell.IsMine)
                {
                    cell.Text = "*";
                    MessageBox.Show("You lose!");

                    Close();
                }
                else
                {
                    if (cell.NeighborsWithMineCount == 0)
                    {
                        Queue<Cell> queue = new Queue<Cell>();
                        queue.Enqueue(cell);

                        while (queue.Count > 0)
                        {
                            Cell currentCell = queue.Dequeue();
                            currentCell.IsOpened = true;

                            if (currentCell.NeighborsWithMineCount == 0)
                            {
                                foreach (Cell c in mineField.GetNeighbours(currentCell.X, currentCell.Y))
                                {
                                    if (!c.IsOpened)
                                    {
                                        queue.Enqueue(c);
                                        c.Text = c.NeighborsWithMineCount.ToString();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        cell.Text = cell.NeighborsWithMineCount.ToString();
                    }
                }
            }
        }
    }
}
