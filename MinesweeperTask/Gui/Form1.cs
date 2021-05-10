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
            MineField mineField = new MineField(9, 9);

            for (int y = 0; y < mineField.Height; y++)
            {
                for (int x = 0; x < mineField.Width; x++)
                {            
                    Cell cell = mineField.GetCell(x, y);

                    cell.Dock = DockStyle.Fill;
                    cell.Margin = new Padding(0);

                    tableLayoutPanel1.Controls.Add(cell);
                }
            }
        }
    }
}
