using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightsTour
{
    public partial class Form1 : Form
    {
        private Game[] games;
        private PictureBox[,] picturbox = new PictureBox[8, 8];
        public Form1()
        {
            InitializeComponent();
            InitializePicArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void InitializePicArray()
        {
            PictureBox[,] picturbox = new PictureBox[8, 8];
            bool isBoxDark = false;
            for (int i = 0; i < picturbox.GetLength(0); i++, isBoxDark = !isBoxDark)
            {
                for (int j = 0; j < picturbox.GetLength(1); j++, isBoxDark = !isBoxDark)
                {
                    tableLayoutPanel1.Controls.Add(getDarkBox(isBoxDark), i, j);
                }
            }
        }
        private PictureBox getDarkBox(bool seriously)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackColor = seriously ? Color.SaddleBrown : Color.BlanchedAlmond;
            pictureBox.Anchor = AnchorStyles.Top;
            pictureBox.Anchor = AnchorStyles.Right;
            pictureBox.Anchor = AnchorStyles.Bottom;
            pictureBox.Anchor = AnchorStyles.Left;
            pictureBox.Dock = DockStyle.Fill;
            return pictureBox;

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tries = (int)numberOfTries.Value;
            string algorithmType = radioButton1.Checked ? "dumb" : "smart";
            string temp1 = radioButton3.Checked ? "-1,-1" : numericUpDown1.Value + "," + numericUpDown2.Value;
            String[] substrings = temp1.Split(',');
            int[] initalPostion = { Int32.Parse(substrings[0]), Int32.Parse(substrings[1]) };
            Console.WriteLine("{0},{1}, {2},{3}" , tries, algorithmType, initalPostion[0], initalPostion[1]);
            games = new Game[tries];


            for (int i =0; i < games.Length; i++)
            {
                games[i] = new Game(algorithmType, initalPostion[0], initalPostion[1]);
                games[i].play();
            }
             //**   game =
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
