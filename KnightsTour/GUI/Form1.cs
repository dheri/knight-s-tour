using Element;
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
        private bool firstTime = true;
        private Game[] games;
        List<int> results;
        private PictureBox[,] picturebox;
        private int layoutNum = 0;
        public Form1()
        {
            InitializeComponent();
            DrawBoard(null);
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
                        label7.Text = "" + (layoutNum + 1);
                        label9.Text = "" + results[layoutNum];
                    }
                    tableLayoutPanel1.Controls.Add(picturebox[i, j], i, j);
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



        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            layoutNum = 0;
            int tries = (int)numberOfTries.Value;
            string algorithmType = radioButton1.Checked ? "dumb" : "smart";
            string filename = "ParteekDheri" + (radioButton1.Checked ? "NonIntelligentMethod.txt" : "HeuristicsMethod.txt");
            string temp1 = radioButton3.Checked ? "-1,-1" : numericUpDown1.Value + "," + numericUpDown2.Value;
            String[] initalPostion_strings = temp1.Split(',');
            int[] initalPostion = { Int32.Parse(initalPostion_strings[0]), Int32.Parse(initalPostion_strings[1]) };
            games = new Game[tries]; //aray of games
            results = new List<int>(); //list of # of moves in each game


            for (int i = 0; i < games.Length; i++)
            {
                games[i] = new Game(algorithmType, initalPostion[0], initalPostion[1]);
                int moves = games[i].play();
                sb.AppendFormat("Trial {0}: The knight was able to successfully touch {1} squares.{2}", i + 1, moves, Environment.NewLine);
                results.Add(moves);
            }

            double average = results.Average();
            double sumOfSquaresOfDifferences = results.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / results.Count);
            sb.AppendFormat("Average: {0} {2}S.D: {1}{2}", average, sd, Environment.NewLine);
            if (firstTime)
            {
                showHiddenControls();
            }
            updateStats();
            Utils.WriteToFile(filename, sb.ToString());

        }

        void updateStats()
        {
            double average = results.Average();
            double sumOfSquaresOfDifferences = results.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / results.Count);

            //update values
            label4.Text = string.Format("{0:N2}", average);
            label5.Text = string.Format("{0:N2}", sd);

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
            label7.Text = "" + (layoutNum + 1);
            label9.Text = "" + results[layoutNum];
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
            label7.Text = "" + (layoutNum + 1);
            label9.Text = "" + results[layoutNum];
            DrawBoard(games[layoutNum].chessBoard);
        }

        private void showHiddenControls()
        {
            //show Labels
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
            this.label5.Visible = true;
            this.label6.Visible = true;
            this.label7.Visible = true;
            this.label8.Visible = true;
            this.label9.Visible = true;

            //show buttons
            this.button2.Visible = true;
            this.button3.Visible = true;
        }
    }
}
