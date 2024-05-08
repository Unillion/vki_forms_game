using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace game1
{
    public partial class Form1 : Form
    {
        public Dictionary<int, LevelBuilder> levels = new Dictionary<int, LevelBuilder>();


        public Form1()
        {
            InitializeComponent();
            registerLevels();
            createGraphics(levels[3]);
            
        }

        public void registerLevels()
        {
            levels.Add(1, new LevelBuilder(4, 2048, 100));
            levels.Add(2, new LevelBuilder(6, 4096, 75));
            levels.Add(3, new LevelBuilder(8, 8192, 50));
        }

        public void createGraphics(LevelBuilder level)
        {
            int size = level.getSize();
            int elSize = level.getElementXY();
            int[,] arr = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    PictureBox picture = new PictureBox();
                    picture.Size = new Size(elSize, elSize);
                    picture.BackColor = Color.White;
                    picture.BorderStyle = BorderStyle.FixedSingle;
                    picture.Location = new Point(i * elSize, j * elSize);
                    Controls.Add(picture);

                    label2.Text = level.getHint().ToString();
                }
            }
        }
    }
}
