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
    public partial class records : Form
    {
        public records()
        {
            InitializeComponent();

            DataBasse data = new DataBasse();
            InitializeDataGridView();
            ShowTopThreeScores(data.ReadStringArray("data.txt"));
        }

        private void InitializeDataGridView()
        {
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.HeaderText = "Name";
            DataGridViewTextBoxColumn scoreColumn = new DataGridViewTextBoxColumn();
            scoreColumn.HeaderText = "Score";
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(scoreColumn);
        }

        private void ShowTopThreeScores(List<string> data)
        {
            List<Tuple<string, int>> scores = new List<Tuple<string, int>>();
            foreach (string entry in data)
            {
                string[] parts = entry.Split(':');
                if (parts.Length >= 2)
                {
                    string name = parts[0].Trim();
                    int score;
                    if (int.TryParse(parts[1].Trim(), out score))
                    {
                        scores.Add(new Tuple<string, int>(name, score));
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка преобразования оценки в число для строки: {entry}");
                    }
                }
                else
                {
                    MessageBox.Show($"Отсутствует символ разделителя в строке: {entry}");
                }
            }

            scores.Sort((x, y) => y.Item2.CompareTo(x.Item2));

            dataGridView1.Rows.Clear();

            foreach (var score in scores.Take(3))
            {
                dataGridView1.Rows.Add(score.Item1, score.Item2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
