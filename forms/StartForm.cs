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
using Курсовая_работа.forms;

namespace Курсовая_работа
{
    public partial class StartForm : Form
    {
        List<Additional_Lesson> additional_lessons_datasource;
        List<Current_Lesson> current_lessons_datasource;
        List<Distance_Lesson> distance_lessons_datasource;
        Manager_Lessons Manager_Lessons;
        public StartForm()
        {
            InitializeComponent();
            this.Manager_Lessons = new Manager_Lessons();
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            this.additional_lessons_datasource = Manager_Lessons.Additional_Lessons;
            this.current_lessons_datasource = Manager_Lessons.Current_Lessons;
            this.distance_lessons_datasource = Manager_Lessons.Distance_Lessons;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            show_lessons();
        }

        private void show_lessons()
        {
            dataGridView1.RowCount = additional_lessons_datasource.Count + current_lessons_datasource.Count + distance_lessons_datasource.Count;
            int count1 = 0;
            int count2 = 0;
            while (count1 < current_lessons_datasource.Count) 
            {
                dataGridView1[0, count1].Value = current_lessons_datasource[count2].Id;
                dataGridView1[1, count1].Value = "Текущее занятие";
                dataGridView1[2, count1].Value = current_lessons_datasource[count2].Discipline.Name;
                dataGridView1[3, count1].Value = current_lessons_datasource[count2].Date_of_Lesson;
                dataGridView1[4, count1].Value = "Номер аудитории: " + current_lessons_datasource[count2].Audience_Number +
                    ", Группа: " + current_lessons_datasource[count2].Group.Name;
                count1++;
                count2++;
            }
            count2 = 0;
            while (count1 < additional_lessons_datasource.Count + current_lessons_datasource.Count) 
            {
                dataGridView1[0, count1].Value = additional_lessons_datasource[count2].Id;
                dataGridView1[1, count1].Value = "Дополнительное занятие";
                dataGridView1[2, count1].Value = additional_lessons_datasource[count2].Discipline.Name;
                dataGridView1[3, count1].Value = additional_lessons_datasource[count2].Date_of_Lesson;
                dataGridView1[4, count1].Value = "Номер аудитории: " + additional_lessons_datasource[count2].Audience_Number +
                    ", Группа: " + additional_lessons_datasource[count2].Group.Name;
                count1++;
                count2++;
            }
            count2 = 0;
            while (count1 < distance_lessons_datasource.Count + additional_lessons_datasource.Count + current_lessons_datasource.Count)
            {
                dataGridView1[0, count1].Value = distance_lessons_datasource[count2].Id;
                dataGridView1[1, count1].Value = "Дистанционное занятие";
                dataGridView1[2, count1].Value = distance_lessons_datasource[count2].Discipline.Name;
                dataGridView1[3, count1].Value = distance_lessons_datasource[count2].Date_of_Lesson;
                dataGridView1[4, count1].Value = "ID конференции: " + distance_lessons_datasource[count2].Conference_Id +
                    ", Пароль конференции: " + distance_lessons_datasource[count2].Conference_Password;
                count1++;
                count2++;
            }
            this.dataGridView1.Sort(this.dataGridView1.Columns[3], ListSortDirection.Ascending);
        }

        private void студентыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fm_students students = new fm_students();
            students.ShowDialog();

            //обновляем список занятий
            Manager_Lessons = new Manager_Lessons();
            this.current_lessons_datasource = Manager_Lessons.Current_Lessons;
            this.additional_lessons_datasource = Manager_Lessons.Additional_Lessons;
            this.distance_lessons_datasource = Manager_Lessons.Distance_Lessons;
            show_lessons();
        }

        private void группыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm_groups groups = new fm_groups();
            groups.ShowDialog();

            //обновляем список занятий
            Manager_Lessons = new Manager_Lessons();
            this.current_lessons_datasource = Manager_Lessons.Current_Lessons;
            this.additional_lessons_datasource = Manager_Lessons.Additional_Lessons;
            this.distance_lessons_datasource = Manager_Lessons.Distance_Lessons;
            show_lessons();
        }

        private void дисциплиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm_disciplines disciplines = new fm_disciplines();
            disciplines.ShowDialog();

            //обновляем список занятий
            Manager_Lessons = new Manager_Lessons();
            this.current_lessons_datasource = Manager_Lessons.Current_Lessons;
            this.additional_lessons_datasource = Manager_Lessons.Additional_Lessons;
            this.distance_lessons_datasource = Manager_Lessons.Distance_Lessons;
            show_lessons();
        }

        private void btn_create_lesson_Click(object sender, EventArgs e)
        {
            fm_create_lesson create_Lesson = new fm_create_lesson(Manager_Lessons);
            create_Lesson.ShowDialog();
            this.additional_lessons_datasource = Manager_Lessons.Additional_Lessons;
            this.current_lessons_datasource = Manager_Lessons.Current_Lessons;
            this.distance_lessons_datasource = Manager_Lessons.Distance_Lessons;
            show_lessons();
        }

        private void btn_add_task_Click(object sender, EventArgs e)
        {
            fm_tasks fm_Tasks = new fm_tasks();
            fm_Tasks.ShowDialog();
            Manager_Lessons = new Manager_Lessons();
            this.current_lessons_datasource = Manager_Lessons.Current_Lessons;
            show_lessons();
        }

        private void btn_edit_progress_Click(object sender, EventArgs e)
        {
            fm_edit_progress fm_Edit_Progress = new fm_edit_progress();
            fm_Edit_Progress.ShowDialog();
        }

        private void btn_show_excellent_Click(object sender, EventArgs e)
        {
            fm_show_excellent fm_Show_Excellent = new fm_show_excellent();
            fm_Show_Excellent.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            string id = Convert.ToString(dataGridView1[0, index].Value);
            if (id.Substring(0, 2) == "AL")
            {
                Additional_Lesson additional_Lesson = Manager_Lessons.SearchByIdAL(id);
                fm_additional_lesson_info fm_Additional_Lesson_Info = new fm_additional_lesson_info(additional_Lesson, Manager_Lessons);
                fm_Additional_Lesson_Info.ShowDialog();

                //обновляем список занятий
                Manager_Lessons = new Manager_Lessons();
                this.current_lessons_datasource = Manager_Lessons.Current_Lessons;
                this.additional_lessons_datasource = Manager_Lessons.Additional_Lessons;
                this.distance_lessons_datasource = Manager_Lessons.Distance_Lessons;
                show_lessons();
            }
            else if (id.Substring(0, 2) == "CL")
            {
                Current_Lesson current_Lesson = Manager_Lessons.SearchByIdCL(id);
                fm_current_lesson_info fm_Current_Lesson_Info = new fm_current_lesson_info(current_Lesson, Manager_Lessons);
                fm_Current_Lesson_Info.ShowDialog();

                //обновляем список занятий
                Manager_Lessons = new Manager_Lessons();
                this.current_lessons_datasource = Manager_Lessons.Current_Lessons;
                this.additional_lessons_datasource = Manager_Lessons.Additional_Lessons;
                this.distance_lessons_datasource = Manager_Lessons.Distance_Lessons;
                show_lessons();
            }
            else if (id.Substring(0, 2) == "DL")
            {
                Distance_Lesson distance_Lesson = Manager_Lessons.SearchByIdDL(id);
                fm_distance_lesson_info fm_Distance_Lesson_Info = new fm_distance_lesson_info(distance_Lesson, Manager_Lessons);
                fm_Distance_Lesson_Info.ShowDialog();

                //обновляем список занятий
                Manager_Lessons = new Manager_Lessons();
                this.current_lessons_datasource = Manager_Lessons.Current_Lessons;
                this.additional_lessons_datasource = Manager_Lessons.Additional_Lessons;
                this.distance_lessons_datasource = Manager_Lessons.Distance_Lessons;
                show_lessons();
            }
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

        private void cms_set_marks_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            string id = Convert.ToString(dataGridView1[0, index].Value);
            if (id.Substring(0, 2) == "AL")
            {
                Additional_Lesson additional_Lesson = Manager_Lessons.SearchByIdAL(id);
                fm_additional_lesson_info fm_Additional_Lesson_Info = new fm_additional_lesson_info(additional_Lesson, Manager_Lessons);
                fm_Additional_Lesson_Info.ShowDialog();

                //обновляем список занятий
                Manager_Lessons = new Manager_Lessons();
                this.current_lessons_datasource = Manager_Lessons.Current_Lessons;
                this.additional_lessons_datasource = Manager_Lessons.Additional_Lessons;
                this.distance_lessons_datasource = Manager_Lessons.Distance_Lessons;
                show_lessons();
            }
            else if (id.Substring(0, 2) == "CL")
            {
                Current_Lesson current_Lesson = Manager_Lessons.SearchByIdCL(id);
                fm_current_lesson_info fm_Current_Lesson_Info = new fm_current_lesson_info(current_Lesson, Manager_Lessons);
                fm_Current_Lesson_Info.ShowDialog();

                //обновляем список занятий
                Manager_Lessons = new Manager_Lessons();
                this.current_lessons_datasource = Manager_Lessons.Current_Lessons;
                this.additional_lessons_datasource = Manager_Lessons.Additional_Lessons;
                this.distance_lessons_datasource = Manager_Lessons.Distance_Lessons;
                show_lessons();
            }
            else if (id.Substring(0, 2) == "DL")
            {
                Distance_Lesson distance_Lesson = Manager_Lessons.SearchByIdDL(id);
                fm_distance_lesson_info fm_Distance_Lesson_Info = new fm_distance_lesson_info(distance_Lesson, Manager_Lessons);
                fm_Distance_Lesson_Info.ShowDialog();

                //обновляем список занятий
                Manager_Lessons = new Manager_Lessons();
                this.current_lessons_datasource = Manager_Lessons.Current_Lessons;
                this.additional_lessons_datasource = Manager_Lessons.Additional_Lessons;
                this.distance_lessons_datasource = Manager_Lessons.Distance_Lessons;
                show_lessons();
            }
        }

        private void удалитьЗанятиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Вы действительно хотите удалить данное занятие?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                this.Manager_Lessons.delete_by_id(Convert.ToString(dataGridView1[0, Convert.ToInt32(dataGridView1.SelectedRows[0].Index)].Value));
                this.Manager_Lessons.save();
                show_lessons();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
