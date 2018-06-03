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
        private PictureBox[,] picturebox;
        private int layoutNum = 0;
        public Form1()
        {
            InitializeComponent();
            DrawBoard(null);
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

        private void DrawBoard(Element.ChessBoard chessBoard)
        {
            tableLayoutPanel1.Controls.Clear();
            picturebox = new PictureBox[8, 8];
            bool isBoxDark = false;
            for (int i = 0; i < picturebox.GetLength(0); i++, isBoxDark = !isBoxDark)
            {
                for (int j = 0; j < picturebox.GetLength(1); j++, isBoxDark = !isBoxDark)
                {
                    picturebox[i, j] = getDarkBox(isBoxDark);
                    if (chessBoard != null)
                    {
                        WriteTextOnPictureBox(picturebox[i, j], chessBoard.Board[i, j].Order);
                    }
                    tableLayoutPanel1.Controls.Add(picturebox[i, j], i, j);
                }
            }
            
            label7.Text = string.Format("{0}", layoutNum + 1);
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
            layoutNum = 0;
            int tries = (int)numberOfTries.Value;
            string algorithmType = radioButton1.Checked ? "dumb" : "smart";
            string temp1 = radioButton3.Checked ? "-1,-1" : numericUpDown1.Value + "," + numericUpDown2.Value;
            String[] substrings = temp1.Split(',');
            int[] initalPostion = { Int32.Parse(substrings[0]), Int32.Parse(substrings[1]) };
            Console.WriteLine("{0},{1}, {2},{3}", tries, algorithmType, initalPostion[0], initalPostion[1]);
            games = new Game[tries]; //aray of games
            List<int> results = new List<int>(); //list of # of moves in each game


            for (int i = 0; i < games.Length; i++)
            {
                games[i] = new Game(algorithmType, initalPostion[0], initalPostion[1]);
                results.Add(games[i].play());
            }

            double average = results.Average();
            double sumOfSquaresOfDifferences = results.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / results.Count);
            Console.WriteLine("{2} \n Average: {0}   S.D: {1}\n", average, sd, String.Join(", ", results.ToArray()));
            updateStats(results);


        }

        void updateStats(List<int> results)
        {
            double average = results.Average();
            double sumOfSquaresOfDifferences = results.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / results.Count);

            //show Labels
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
            this.label5.Visible = true;
            this.label6.Visible = true;
            this.label7.Visible = true;

            //update values
            label4.Text = string.Format("{0:N2}", average);
            label5.Text = string.Format("{0:N2}", sd);

            //show buttons
            this.button2.Visible = true;
            this.button3.Visible = true;

            DrawBoard(games[0].chessBoard);

        }


        private void WriteTextOnPictureBox(PictureBox PB, int order)
        {
            if (order == 0)
            {
                PB.Dock = System.Windows.Forms.DockStyle.Fill;
                // PB.BackColor = System.Drawing.Color.Transparent;
                PB.Image = global::KnightsTour.Properties.Resources.sweden;
                PB.Location = new System.Drawing.Point(3, 251);
                PB.Size = new System.Drawing.Size(62, 56);
                PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            }
            else
            {
                PB.Paint += new PaintEventHandler((sender, e) =>
                {
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    string text = order + "";

                    SizeF textSize = e.Graphics.MeasureString(text, Font);
                    PointF locationToDraw = new PointF();
                    locationToDraw.X = (PB.Width / 2) - (textSize.Width / 2);
                    locationToDraw.Y = (PB.Height / 2) - (textSize.Height / 2);

                    e.Graphics.DrawString(text, Font, Brushes.Black, locationToDraw);
                });
            }
            //refresh picture box
            PB.Invalidate();
            PB.Update();
            PB.Refresh();
        }
        //previous btn
        private void button2_Click(object sender, EventArgs e)
        {
            if (layoutNum <= 0)
            {
                return;
            }
            layoutNum--;
            label7.Text = string.Format("{0}", layoutNum + 1);
            DrawBoard(games[layoutNum].chessBoard);

        }
        //next button
        private void button3_Click(object sender, EventArgs e)
        {
            if (layoutNum >= games.Length - 1)
            {
                return;
            }
            layoutNum++;
            label7.Text = string.Format("{0}", layoutNum + 1);
            DrawBoard(games[layoutNum].chessBoard);
        }


    }
}
