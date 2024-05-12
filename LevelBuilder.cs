using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game1
{
    public class LevelBuilder
    {
        private int size;
        private int elementXY;
        private int maxHint;
        private PictureBox[,] pictureBox;
        public LevelBuilder(int size, int maxHint, int elementXY)
        {
            this.size = size;
            this.maxHint = maxHint;
            this.elementXY = elementXY;

            pictureBox = new PictureBox[size, size];
        }

        public PictureBox[,] GetBoxes()
        {
            return pictureBox;
        }

        public void fillBoxes(PictureBox boxes, int i, int j)
        {
            this.pictureBox[i,j] = boxes;
        }

        public int getSize()
        {
            return this.size;
        }

        public int getHint() 
        {
            return this.maxHint;
        }

        public int getElementXY()
        {
            return this.elementXY;
        }

        public void CreatePic(int row, int col, int posX, int posY, PictureBox[,] pics, Label[,] labels, Form1 form)
        {
            pics[row, col] = new PictureBox();
            labels[row, col] = new Label();
            labels[row, col].Text = "2";
            labels[row, col].Size = new Size(50, 50);
            labels[row, col].TextAlign = ContentAlignment.MiddleCenter;
            labels[row, col].Font = new Font(new FontFamily("Microsoft Sans Serif"), 15);
            pics[row, col].Controls.Add(labels[row, col]);
            pics[row, col].Location = new Point(posX, posY);
            pics[row, col].Size = new Size(50, 50);
            pics[row, col].BackColor = Color.Yellow;
            form.Controls.Add(pics[row, col]);
            pics[row, col].BringToFront();
        }

        public void GenerateNewPic(int[,] map ,PictureBox[,] pics, Label[,] labels, Form1 form)
        {
            Random rnd = new Random();
            int gridSize = this.getSize();
            int cellSize = 50;
            int spacing = 56;

            int a, b;
            do
            {
                a = rnd.Next(gridSize);
                b = rnd.Next(gridSize);
            } while (pics[a, b] != null);

            map[a, b] = 1;

            PictureBox pic = new PictureBox();
            Label label = new Label();
            label.Text = "2";
            label.Size = new Size(cellSize, cellSize);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = new Font("Microsoft Sans Serif", 15);

            pic.Controls.Add(label);
            pic.Location = new Point(12 + b * spacing, 73 + a * spacing);
            pic.Size = new Size(cellSize, cellSize);
            pic.BackColor = Color.Yellow;

            form.Controls.Add(pic);
            pic.BringToFront();

            pics[a, b] = pic;
            labels[a, b] = label;
        }

        public void showWin(Form1 form, string nick, int rec)
        {
            DataBasse data = new DataBasse();
            data.write(nick, rec);
            DialogResult result = DialogResult.None;
            result = result = MessageBox.Show("Ваш рекорд записан",
                                "Победа!", MessageBoxButtons.OK);

            if (result == DialogResult.OK)
                form.Close();
        }
        public bool CanMoveBlocks(int[,] map, Label[,] labels)
        {
            int[,] directions = {
                { 0, 1 },
                { 0, -1 }, 
                { 1, 0 }, 
                { -1, 0 } 
            };

            for (int directionIndex = 0; directionIndex < 4; directionIndex++)
            {
                for (int k = 0; k < 4; k++)
                {
                    for (int l = 0; l < 4; l++)
                    {
                        if (map[k, l] == 1)
                        {
                            int nextK = k + directions[directionIndex, 0];
                            int nextL = l + directions[directionIndex, 1];

                            if (nextK >= 0 && nextK < 4 && nextL >= 0 && nextL < 4)
                            {
                                if (map[nextK, nextL] == 0)
                                {
                                    return true;
                                }
                                else if (labels[nextK, nextL].Text == labels[k, l].Text)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }


    }
}
