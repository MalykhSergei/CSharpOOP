using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private MineField mineField;
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
            mineField = new MineField(14, 14);

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

                    tablePanel.Controls.Add(cell);
                }
            }

            ClientSize = new Size(cell.Width * mineField.Width, cell.Height * mineField.Height + flowPanel.Height);
        }
    }
}
