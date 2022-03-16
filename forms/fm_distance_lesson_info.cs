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
    public partial class fm_distance_lesson_info : Form
    {
        Distance_Lesson distance_Lesson;
        Manager_Lessons manager_Lessons;
        Manager_Students manager_Students;
        Manager_Student_Progress manager_Student_Progress;
        List<Student_Progress> marks_datasource;
        public fm_distance_lesson_info()
        {
            InitializeComponent();
        }

        public fm_distance_lesson_info(Distance_Lesson distance_Lesson, Manager_Lessons manager_Lessons)
        {
            InitializeComponent();
            this.distance_Lesson = distance_Lesson;
            this.manager_Lessons = manager_Lessons;
            this.manager_Students = new Manager_Students();
            this.manager_Student_Progress = new Manager_Student_Progress();
            this.marks_datasource = manager_Student_Progress.list_student_debts(distance_Lesson.Student, distance_Lesson.Discipline);
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            textBox1.Text = "Дистанционное занятие";
            textBox2.Text = "(" + distance_Lesson.Student.Id + ") " + distance_Lesson.Student.Surname + " " + 
                distance_Lesson.Student.Name.Substring(0, 1) + "." + distance_Lesson.Student.Patronymic.Substring(0, 1) + ".";
            textBox3.Text = distance_Lesson.Group.Name;
            textBox4.Text = distance_Lesson.Discipline.Name;
            textBox5.Text = Convert.ToString(distance_Lesson.Date_of_Lesson);
            textBox6.Text = distance_Lesson.Conference_Id;
            textBox7.Text = distance_Lesson.Conference_Password;
        }
        private void fm_distance_lesson_info_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            show_list();
        }
        private void show_list()
        {
            dataGridView1.RowCount = marks_datasource.Count;
            for (int i = 0; i < marks_datasource.Count; i++)
            {
                Student_Progress mark = marks_datasource[i];
                dataGridView1[0, i].Value = mark.Task.Serial_Number_of_Theme;
                dataGridView1[1, i].Value = mark.Task.Name;
                dataGridView1[2, i].Value = mark.Variant;
                dataGridView1[3, i].Value = mark.Amount_of_Attemps;
                dataGridView1[4, i].Value = mark.Task.Term;
                dataGridView1[5, i].Value = mark.Task.Max_Mark;
                dataGridView1[6, i].Value = mark.Mark;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Вы действительно хотите удалить данное занятие?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                this.manager_Lessons.delete_by_id(distance_Lesson.Id);
                this.manager_Lessons.save();
                this.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            Manager_Tasks manager_Tasks = new Manager_Tasks();
            Student_Progress mark = manager_Student_Progress.search_by_student_task(distance_Lesson.Student, manager_Tasks.search_by_serial_number(Convert.ToInt32(dataGridView1[0, index].Value), distance_Lesson.Discipline));

            fm_set_mark fm_Set_Mark = new fm_set_mark(mark, distance_Lesson, manager_Student_Progress);
            fm_Set_Mark.ShowDialog();

            sort(dataGridView1);
            show_list();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sort(dataGridView1);
            show_list();
        }

        private void sort(DataGridView dgv)
        {
            if (marks_datasource.Count < 2)
                return;
            int i = 0;
            while (i != marks_datasource.Count - 1)
            {
                int j = i + 1;
                while (j != marks_datasource.Count)
                {
                    if (marks_datasource[i].Task.Term>marks_datasource[j].Task.Term)
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
            Student_Progress temp_mark = marks_datasource[row1];
            marks_datasource[row1] = marks_datasource[row2];
            marks_datasource[row2] = temp_mark;
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView1.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hit.RowIndex].Selected = true;
                    CMS.Show(dataGridView1, e.Location);
                }
            }
        }

        private void cms_set_mark_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            Manager_Tasks manager_Tasks = new Manager_Tasks();
            Student_Progress mark = manager_Student_Progress.search_by_student_task(distance_Lesson.Student, manager_Tasks.search_by_serial_number(Convert.ToInt32(dataGridView1[0, index].Value), distance_Lesson.Discipline));

            fm_set_mark fm_Set_Mark = new fm_set_mark(mark, distance_Lesson, manager_Student_Progress);
            fm_Set_Mark.ShowDialog();

            sort(dataGridView1);
            show_list();
        }
    }
}
