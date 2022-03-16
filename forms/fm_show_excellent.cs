using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Курсовая_работа.classes;

namespace Курсовая_работа.forms
{
    public partial class fm_show_excellent : Form
    {
        Manager_Groups manager_Groups;
        Manager_Disciplines manager_Disciplines;
        Manager_Student_Progress manager_Student_Progress;
        List<Student> best_students;
        public fm_show_excellent()
        {
            InitializeComponent();
            this.manager_Groups = new Manager_Groups();
            this.manager_Disciplines = new Manager_Disciplines();
            this.manager_Student_Progress = new Manager_Student_Progress();
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void fm_show_excellent_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < manager_Groups.Groups.Count; i++)
            {
                comboBox1.Items.Add(manager_Groups.Groups[i].Name);
            }
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void show_best_students()
        {
            dataGridView1.RowCount = best_students.Count;
            for (int i = 0; i < best_students.Count; i++)
            {
                dataGridView1[0, i].Value = best_students[i].Id;
                dataGridView1[1, i].Value = best_students[i].Surname + " " + best_students[i].Name.Substring(0, 1) +
                    "." + best_students[i].Patronymic.Substring(0, 1) + ".";
                dataGridView1[2, i].Value = manager_Student_Progress.sum_mark(best_students[i], manager_Disciplines.SearchByName(comboBox2.Text));

                Manager_Tasks manager_Tasks = new Manager_Tasks();
                double completed_procent= (Convert.ToDouble(dataGridView1[2, i].Value) / (double)manager_Tasks.sum_max_mark(manager_Disciplines.SearchByName(comboBox2.Text)))*100;
                dataGridView1[3, i].Value = Math.Round(completed_procent, 2);
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            dataGridView1.RowCount = 0;
            List<Discipline> disciplines_by_group = manager_Disciplines.SearchByGroup(manager_Groups.SearchByName(comboBox1.Text));
            for (int i = 0; i < disciplines_by_group.Count; i++)
            {
                comboBox2.Items.Add(disciplines_by_group[i].Name + " (" + disciplines_by_group[i].Group.Name + ")");
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Manager_Students manager_Students = new Manager_Students();
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                best_students = manager_Students.best_students_of_group(manager_Disciplines.SearchByName(comboBox2.Text));
                show_best_students();
            }
            sort(dataGridView1);
        }

        private void sort(DataGridView dgv)
        {
            if (best_students.Count < 2)
                return;
            int i = 0;
            while (i != best_students.Count - 1)
            {
                int j = i + 1;
                while (j != best_students.Count)
                {
                    if (Convert.ToInt32(dgv[2, i].Value) < Convert.ToInt32(dgv[2, j].Value))
                    {
                        swap(dataGridView1, i, j);
                    }
                    j++;
                }
                i++;
            }
        }

        private void swap(DataGridView dgv, int row1, int row2)
        {
            string[] temp_row = new string[dgv.ColumnCount];
            for (int i = 0; i < temp_row.Length; i++)
            {
                temp_row[i] = Convert.ToString(dgv[i, row1].Value);
            }
            for (int i = 0; i < temp_row.Length; i++)
            {
                dgv[i, row1].Value = dgv[i, row2].Value;
                dgv[i, row2].Value = temp_row[i];
            }
            Student temp_student = best_students[row1];
            best_students[row1] = best_students[row2];
            best_students[row2] = temp_student;
        }
    }
}
