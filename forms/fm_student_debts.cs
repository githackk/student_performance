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
    public partial class fm_student_debts : Form
    {
        Student student;
        Additional_Lesson additional_Lesson;
        Manager_Student_Progress manager_Student_Progress;
        List<Student_Progress> marks_datasource;
        public fm_student_debts()
        {
            InitializeComponent();
        }

        public fm_student_debts(Student student, Additional_Lesson additional_Lesson, Manager_Student_Progress manager_Student_Progress)
        {
            InitializeComponent();
            this.student = student;
            this.additional_Lesson = additional_Lesson;
            this.manager_Student_Progress = manager_Student_Progress;
            this.marks_datasource = manager_Student_Progress.list_student_debts_time(student, additional_Lesson.Discipline);
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void fm_student_debts_Load(object sender, EventArgs e)
        {
            sort(dataGridView1);//может выдать ошибку!!!!
            show_list_debts_time();
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void show_list_debts_time()//передача в dgv долгов студента, у которых истек срок сдачи
        {
            dataGridView1.RowCount = marks_datasource.Count;
            for (int i = 0; i < marks_datasource.Count; i++)
            {
                Student_Progress debt = marks_datasource[i];
                dataGridView1[0, i].Value = debt.Task.Serial_Number_of_Theme;
                dataGridView1[1, i].Value = debt.Task.Name;
                dataGridView1[2, i].Value = debt.Variant;
                dataGridView1[3, i].Value = debt.Task.Term;
                dataGridView1[4, i].Value = debt.Amount_of_Attemps;
                if (debt.Completed == true)
                    dataGridView1[5, i].Value = "Сдано";
                else
                    dataGridView1[5, i].Value = "Не сдано";
                dataGridView1[6, i].Value = debt.Mark;
                dataGridView1[7, i].Value = debt.Task.Max_Mark;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            Manager_Tasks manager_Tasks = new Manager_Tasks();
            Student_Progress mark = manager_Student_Progress.search_by_student_task(student, manager_Tasks.search_by_serial_number(Convert.ToInt32(dataGridView1[0, index].Value), additional_Lesson.Discipline));

            fm_set_mark fm_Set_Mark = new fm_set_mark(mark, additional_Lesson, manager_Student_Progress);
            fm_Set_Mark.ShowDialog();

            //обновляем список
            sort(dataGridView1);
            show_list_debts_time();
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
                    if (marks_datasource[i].Task.Term > marks_datasource[j].Task.Term)
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
            Student_Progress mark = manager_Student_Progress.SearchByID(Convert.ToInt32(dataGridView1[0, index].Value));

            fm_set_mark fm_Set_Mark = new fm_set_mark(mark, additional_Lesson, manager_Student_Progress);
            fm_Set_Mark.ShowDialog();

            //обновляем список
            sort(dataGridView1);
            show_list_debts_time();
        }
    }
}
