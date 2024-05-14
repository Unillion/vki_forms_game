using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace game1
{
    public partial class Form1 : Form
    {
        public Dictionary<int, LevelBuilder> levels = new Dictionary<int, LevelBuilder>();

        public int[,] map;
        public Label[,] labels;
        public PictureBox[,] pics;
        LevelBuilder level;
        int size;

        int score = 0;
        int score2 = 0;
        string nick;
        bool isWin = false;

        public Form1(int lvl, string nick)
        {
            InitializeComponent();
            initLevels();

            LevelBuilder chosenLevel = levels[lvl];
            level = chosenLevel;
            map = new int[level.getSize(), level.getSize()];
            labels = new Label[level.getSize(), level.getSize()];
            pics = new PictureBox[level.getSize(), level.getSize()];
            size = level.getSize();

            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            map[0, 0] = 1;
            map[0, 1] = 1;

            initHint(level);
            createMap(level);
            CreatePics(level);
            level.GenerateNewPic(map, pics, labels, this);
            this.nick = nick;
            label5.Text = 0.ToString();
        }

        private void initHint(LevelBuilder level)
        {
            label2.Text = level.getHint().ToString();
        }

        private void initLevels()
        {
            levels.Add(1, new LevelBuilder(4, 2048, 50, 1));
            levels.Add(2, new LevelBuilder(6, 4096, 50, 2));
            levels.Add(3, new LevelBuilder(8, 8192, 30, 3));
        }


        private void createMap(LevelBuilder level)
        {
            for (int i = 0; i < level.getSize(); i++)
            {
                for (int j = 0; j < level.getSize(); j++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Location = new Point(12 + 56 * j, 73 + 56 * i);
                    pic.Size = new Size(50, 50);
                    pic.BackColor = Color.Gray;
                    this.Controls.Add(pic);

                }
            }
        }



        private void CreatePics(LevelBuilder level)
        {
            level.CreatePic(0, 0, 12, 73,pics, labels, this);
            level.CreatePic(0, 1, 68, 73, pics, labels, this);
        }

        private void ChangeColor(int sum, int k, int j)
        {
            Color[] colors = { Color.Green, Color.Maroon, Color.Cyan, Color.Coral, Color.Brown, Color.Blue, Color.DarkViolet, Color.Red, Color.Pink };
            int[] divisors = { 1, 8, 16, 32, 64, 128, 256, 512, 1024 };

            for (int i = divisors.Length - 1; i >= 0; i--)
            {
                if (sum % divisors[i] == 0)
                {
                    pics[k, j].BackColor = colors[i];
                    return;
                }
            }
            pics[k, j].BackColor = Color.Green;
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            if (isWin) return;

            bool ifPicWasMoved = false;

            int[,] directions = {
                { 0, 1 },
                { 0, -1 },
                { 1, 0 },
                { -1, 0 }
            };

            int directionIndex = -1;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    directionIndex = 0;
                    break;
                case Keys.Left:
                    directionIndex = 1;
                    break;
                case Keys.Down:
                    directionIndex = 2;
                    break;
                case Keys.Up:
                    directionIndex = 3;
                    break;
            }

            if (directionIndex != -1)
            {
                for (int k = 0; k < size; k++)
                {
                    for (int l = 0; l < size; l++)
                    {
                        if (map[k, l] == 1)
                        {
                            int nextK = k + directions[directionIndex, 0];
                            int nextL = l + directions[directionIndex, 1];

                            while (nextK >= 0 && nextK < size && nextL >= 0 && nextL < size)
                            {
                                if (map[nextK, nextL] == 0)
                                {
                                    ifPicWasMoved = true;
                                    MoveTile(k, l, nextK, nextL);
                                    k = nextK;
                                    l = nextL;
                                    nextK += directions[directionIndex, 0];
                                    nextL += directions[directionIndex, 1];
                                }
                                else
                                {
                                    int a = int.Parse(labels[nextK, nextL].Text);
                                    int b = int.Parse(labels[k, l].Text);
                                    if (a == b)
                                    {
                                        ifPicWasMoved = true;
                                        MergeTiles(k, l, nextK, nextL, a + b);
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (score >= level.getHint()) isWin = true;
            if (isWin) 
                level.showWin(this, nick, score2);

            if (IsGameOver()) level.showLose(this, nick, score2);
            if (ifPicWasMoved)
                level.GenerateNewPic(map, pics, labels, this);
        }


        private void MoveTile(int fromK, int fromL, int toK, int toL)
        {
            map[toK, toL] = 1;
            map[fromK, fromL] = 0;
            pics[toK, toL] = pics[fromK, fromL];
            pics[fromK, fromL] = null;
            labels[toK, toL] = labels[fromK, fromL];
            labels[fromK, fromL] = null;

            int directionX = (toL - fromL) * 56;
            int directionY = (toK - fromK) * 56;
            pics[toK, toL].Location = new Point(pics[toK, toL].Location.X + directionX, pics[toK, toL].Location.Y + directionY);
        }

        private void MergeTiles(int fromK, int fromL, int toK, int toL, int value)
        {
            map[toK, toL] = 1;
            map[fromK, fromL] = 0;

            labels[toK, toL].Text = value.ToString();
            
            if (value >= score)
                score = value;
            score2 += value;

            ChangeColor(value, toK, toL);

            count.Text = score2.ToString();
            label5.Text = score.ToString();

            this.Controls.Remove(pics[fromK, fromL]);
            this.Controls.Remove(labels[fromK, fromL]);
            pics[fromK, fromL] = null;
            labels[fromK, fromL] = null;
        }

        private bool IsGameOver()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (map[i, j] == 0)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int currentTileValue = int.Parse(labels[i, j].Text);
                    if ((i < size - 1 && int.Parse(labels[i + 1, j].Text) == currentTileValue) ||
                        (j < size - 1 && int.Parse(labels[i, j + 1].Text) == currentTileValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

}
