using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Курсовая_работа.classes;

namespace Курсовая_работа.forms
{
    public partial class fm_edit_progress : Form
    {
        Manager_Groups manager_Groups;
        Manager_Disciplines manager_Disciplines;
        Manager_Students manager_Students;
        Manager_Student_Progress manager_Student_Progress;
        List<Student_Progress> student_marks;
        public fm_edit_progress()
        {
            InitializeComponent();
            this.manager_Groups = new Manager_Groups();
            this.manager_Disciplines = new Manager_Disciplines();
            this.manager_Students = new Manager_Students();
            this.manager_Student_Progress = new Manager_Student_Progress();
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void fm_edit_progress_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            for (int i = 0; i < manager_Groups.Groups.Count; i++)
            {
                comboBox1.Items.Add(manager_Groups.Groups[i].Name);
            }
        }

        private void show_student_marks(List<Student_Progress> marks)
        {
            dataGridView1.RowCount = marks.Count;
            for (int i = 0; i < marks.Count; i++)
            {
                dataGridView1[0, i].Value = marks[i].Task.Serial_Number_of_Theme;
                dataGridView1[1, i].Value = marks[i].Task.Name;
                dataGridView1[2, i].Value = marks[i].Variant;
                dataGridView1[3, i].Value = marks[i].Amount_of_Attemps;
                if (marks[i].Completed == true)
                    dataGridView1[4, i].Value = "Сдал";
                if (marks[i].Completed == false)
                    dataGridView1[4, i].Value = "Не сдал";
                dataGridView1[5, i].Value = marks[i].Completed_Date;
                dataGridView1[6, i].Value = marks[i].Mark;
                dataGridView1[7, i].Value = marks[i].Task.Max_Mark;
            }
            this.dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            dataGridView1.RowCount = 0;
            List<Discipline> disciplines_by_group = manager_Disciplines.SearchByGroup(manager_Groups.SearchByName(comboBox1.Text));
            for (int i = 0; i < disciplines_by_group.Count; i++)
            {
                comboBox2.Items.Add(disciplines_by_group[i].Name + " (" + disciplines_by_group[i].Group.Name + ")");
            }
            List<Student> students_by_group = manager_Students.SearchByGroup(manager_Groups.SearchByName(comboBox1.Text));
            for (int i = 0; i < students_by_group.Count; i++)
            {
                comboBox3.Items.Add("(" + students_by_group[i].Id + ") " + students_by_group[i].Surname + " " + students_by_group[i].Name.Substring(0, 1) +
                    "." + students_by_group[i].Patronymic.Substring(0, 1) + ".");
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                student_marks = manager_Student_Progress.list_student_marks(manager_Students.SearchByName(comboBox3.Text), manager_Disciplines.SearchByName(comboBox2.Text));
                show_student_marks(student_marks);
            }
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                student_marks = manager_Student_Progress.list_student_marks(manager_Students.SearchByName(comboBox3.Text), manager_Disciplines.SearchByName(comboBox2.Text));
                show_student_marks(student_marks);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            Manager_Tasks manager_Tasks = new Manager_Tasks();
            Student_Progress mark = manager_Student_Progress.search_by_student_task(manager_Students.SearchByName(comboBox3.Text), manager_Tasks.search_by_serial_number(Convert.ToInt32(dataGridView1[0, index].Value), manager_Disciplines.SearchByName(comboBox2.Text)));

            fm_set_mark fm_Set_Mark = new fm_set_mark(mark, manager_Student_Progress);
            fm_Set_Mark.ShowDialog();
            show_student_marks(manager_Student_Progress.list_student_marks(manager_Students.SearchByName(comboBox3.Text), manager_Disciplines.SearchByName(comboBox2.Text)));
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
            Student_Progress mark = manager_Student_Progress.search_by_student_task(manager_Students.SearchByName(comboBox3.Text), manager_Tasks.search_by_serial_number(Convert.ToInt32(dataGridView1[0, index].Value), manager_Disciplines.SearchByName(comboBox2.Text)));

            fm_set_mark fm_Set_Mark = new fm_set_mark(mark, manager_Student_Progress);
            fm_Set_Mark.ShowDialog();
            show_student_marks(manager_Student_Progress.list_student_marks(manager_Students.SearchByName(comboBox3.Text), manager_Disciplines.SearchByName(comboBox2.Text)));
        }
    }
}
