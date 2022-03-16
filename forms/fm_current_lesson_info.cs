using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Курсовая_работа.classes;

namespace Курсовая_работа.forms
{
    public partial class fm_current_lesson_info : Form
    {
        Current_Lesson current_Lesson;
        Manager_Lessons manager_Lessons;
        Manager_Students manager_Students;
        Manager_Student_Progress manager_Student_Progress;
        List<Student_Progress> list_marks_group_task;
        public fm_current_lesson_info()
        {
            InitializeComponent();
        }

        public fm_current_lesson_info(Current_Lesson current_Lesson, Manager_Lessons manager_Lessons)
        {
            InitializeComponent();
            this.current_Lesson = current_Lesson;
            this.manager_Lessons = manager_Lessons;
            this.manager_Students = new Manager_Students();
            this.manager_Student_Progress = new Manager_Student_Progress();
            this.list_marks_group_task = manager_Student_Progress.list_marks_by_group_task(current_Lesson.Group, current_Lesson.Task);
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            textBox1.Text = "Текущее занятие";
            textBox2.Text = Convert.ToString(current_Lesson.Date_of_Lesson);
            textBox3.Text = current_Lesson.Group.Name;
            textBox4.Text = current_Lesson.Discipline.Name;
            textBox5.Text = current_Lesson.Task.Type_of_Lesson;
            textBox6.Text = current_Lesson.Task.Name;
            textBox7.Text = current_Lesson.Audience_Number;
        }

        private void fm_current_lesson_info_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            show_list();
        }

        private void show_list()
        {
            dataGridView1.RowCount = list_marks_group_task.Count;
            for (int i = 0; i < list_marks_group_task.Count; i++)
            {
                Student_Progress mark = list_marks_group_task[i];
                dataGridView1[0, i].Value = mark.Student.Id;
                dataGridView1[1, i].Value = mark.Student.Surname + " " + mark.Student.Name.Substring(0, 1) + "." + mark.Student.Patronymic.Substring(0, 1) + ".";
                dataGridView1[2, i].Value = mark.Variant;
                if (mark.Completed == true)
                {
                    dataGridView1[3, i].Value = "Сдал";
                }
                else
                {
                    dataGridView1[3, i].Value = "Не сдал";
                }
                dataGridView1[4, i].Value = mark.Mark;
                dataGridView1[5, i].Value = mark.Task.Max_Mark;
                dataGridView1[6, i].Value = mark.Amount_of_Attemps;
                dataGridView1[7, i].Value = manager_Student_Progress.count_debts_student(current_Lesson.Discipline, mark.Student);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Вы действительно хотите удалить данное занятие?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                this.manager_Lessons.delete_by_id(current_Lesson.Id);
                this.manager_Lessons.save();
                this.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (current_Lesson.Task.Term < DateTime.Now)
            {
                var message = MessageBox.Show("Срок задания истек! Удалить занятие?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.Yes)
                {
                    this.manager_Lessons.delete_by_id(current_Lesson.Id);
                    this.manager_Lessons.save();
                    this.Close();
                }
            }

            int index = dataGridView1.SelectedRows[0].Index;
            string id = Convert.ToString(dataGridView1[0, index].Value);
            Student_Progress mark = list_marks_group_task[index];
            
            fm_set_mark fm_Set_Mark = new fm_set_mark(mark, current_Lesson, manager_Student_Progress);
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
            if (list_marks_group_task.Count < 2)
                return;
            int i = 0;
            while (i != list_marks_group_task.Count - 1)
            {
                int j = i + 1;
                while (j != list_marks_group_task.Count)
                {
                    if (Convert.ToInt32(dgv[7, i].Value) > Convert.ToInt32(dgv[7, j].Value))
                    {
                        swap(dataGridView1, i, j);
                    }
                    else if (Convert.ToInt32(dgv[7, i].Value) == Convert.ToInt32(dgv[7, j].Value) && list_marks_group_task[i].Amount_of_Attemps > list_marks_group_task[j].Amount_of_Attemps)
                    {
                        swap(dataGridView1, i, j);
                    }
                    j++;
                }
                i++;
            }

            List<Student_Progress> task_completed = new List<Student_Progress>();
            for (int j = 0; j < list_marks_group_task.Count; j++)
            {
                Student_Progress mark = list_marks_group_task[j];
                if (mark.Completed == true)
                {
                    task_completed.Add(mark);
                    list_marks_group_task.RemoveAt(j);
                    j--;
                }
            }
            list_marks_group_task.AddRange(task_completed);
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
            Student_Progress temp_mark = list_marks_group_task[row1];
            list_marks_group_task[row1] = list_marks_group_task[row2];
            list_marks_group_task[row2] = temp_mark;
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
            string id = Convert.ToString(dataGridView1[0, index].Value);
            Student_Progress mark = list_marks_group_task[index];

            fm_set_mark fm_Set_Mark = new fm_set_mark(mark, current_Lesson, manager_Student_Progress);
            fm_Set_Mark.ShowDialog();

            sort(dataGridView1);
            show_list();
        }

        private void cms_student_absence_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Студент будет удален с занятия вследствие его отсуствтия?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                list_marks_group_task.RemoveAt(index);
                sort(dataGridView1);
                show_list();
            }
        }
    }
}
