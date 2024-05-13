using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game1
{
    public partial class Menu : Form
    {
        private List<string> excluded_names = new List<string>();

        public Menu()
        {
            InitializeComponent();
            lockBlockedLevels();
            fillExcludedNames();

            foreach (RadioButton radio in groupBox1.Controls)
            {
                radio.Click += radio_Click;
            }
        }

        private void fillExcludedNames()
        {
            excluded_names.Add(" ");
            excluded_names.Add("");
            excluded_names.Add("введите ник");
            excluded_names.Add("Введите нмк");
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void start_button_Click(object sender, EventArgs e)
        {
            if (excluded_names.Contains(textBox1.Text)) return;
            string ID = textBox1.Text;
            int lvl = chooseLvl();
            Form1 game = new Form1(lvl, ID);

            game.ShowDialog();  
            this.Close();
        }

        private void lockBlockedLevels()
        {
            DataBasse data = new DataBasse();
            string score = "lvl.txt";
            int lvl = (int)data.ReadSingleDigit(score);

            switch (lvl)
            {
                case 1:
                    level2.Enabled = false;
                    level3.Enabled = false;
                    break;
                case 2:
                    level3.Enabled = false;
                    level2.Enabled = true;
                    level1.Enabled = true;
                    break;
                case 3:
                    level1.Enabled = true;
                    level2.Enabled = true;
                    level3.Enabled = true;
                    break;
            }
        }

        private int chooseLvl()
        {
            int lvl = 1;
            
            foreach (RadioButton radio in groupBox1.Controls)
            {
                if (radio.Checked)
                {
                    lvl = int.Parse((string)radio.Tag);
                }
            }
            return lvl;
        }

        private void radio_Click(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            foreach (RadioButton radioButton in groupBox1.Controls)
            {
                if (radioButton == radio) continue;
                radioButton.Checked = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
