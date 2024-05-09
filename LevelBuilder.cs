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
    }
}
