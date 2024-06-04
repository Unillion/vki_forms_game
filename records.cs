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
            InitializeDataGridView(dataGridView1);
            InitializeDataGridView(dataGridView2);
            InitializeDataGridView(dataGridView3);

            ShowTopThreeScores(data.ReadStringArray("data.txt"));
        }

        private void InitializeDataGridView(DataGridView grid)
        {
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.HeaderText = "Name";
            DataGridViewTextBoxColumn scoreColumn = new DataGridViewTextBoxColumn();
            scoreColumn.HeaderText = "Score";
            grid.Columns.Add(nameColumn);
            grid.Columns.Add(scoreColumn);
        }

        private void ShowTopThreeScores(List<string> data)
        {
            var levelScores = new Dictionary<int, List<Tuple<string, int>>>();

            foreach (string entry in data)
            {
                string[] parts = entry.Split(':');
                if (parts.Length >= 2)
                {
                    string name = parts[0].Trim();
                    string[] scoreLevel = parts[1].Trim().Split(' ');
                    if (scoreLevel.Length == 2)
                    {
                        if (int.TryParse(scoreLevel[0], out int score) && int.TryParse(scoreLevel[1], out int level))
                        {
                            if (!levelScores.ContainsKey(level))
                            {
                                levelScores[level] = new List<Tuple<string, int>>();
                            }
                            levelScores[level].Add(new Tuple<string, int>(name, score));
                        }
                        else
                        {
                            MessageBox.Show($"Ошибка преобразования оценки или уровня в число для строки: {entry}");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Некорректный формат строки: {entry}");
                    }
                }
                else
                {
                    MessageBox.Show($"Отсутствует символ разделителя в строке: {entry}");
                }
            }

            ShowTopScoresForLevel(dataGridView1, levelScores, 1);
            ShowTopScoresForLevel(dataGridView2, levelScores, 2);
            ShowTopScoresForLevel(dataGridView3, levelScores, 3);
        }

        private void ShowTopScoresForLevel(DataGridView dataGridView, Dictionary<int, List<Tuple<string, int>>> levelScores, int level)
        {
            dataGridView.Rows.Clear();
            if (levelScores.ContainsKey(level))
            {
                var topScores = levelScores[level].OrderByDescending(x => x.Item2).Take(3);
                foreach (var score in topScores)
                {
                    dataGridView.Rows.Add(score.Item1, score.Item2);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
