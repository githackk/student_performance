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
    public partial class fm_students : Form
    {
        List<Student> students_datasource;
        Manager_Students manager_students;
        public fm_students()
        {
            InitializeComponent();
            this.dgv_students.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.manager_students = new Manager_Students();
        }

        private void show_students()
        {
            dgv_students.RowCount = students_datasource.Count;
            for (int i = 0; i < students_datasource.Count; i++)
            {
                dgv_students[0, i].Value = students_datasource[i].Id;
                dgv_students[1, i].Value = students_datasource[i].Surname;
                dgv_students[2, i].Value = students_datasource[i].Name;
                dgv_students[3, i].Value = students_datasource[i].Patronymic;
                dgv_students[4, i].Value = students_datasource[i].Group.Speciality;
                dgv_students[5, i].Value = students_datasource[i].Group.Course;
                dgv_students[6, i].Value = students_datasource[i].Group.Name;
            }
        }

        private void fm_students_Load(object sender, EventArgs e)
        {
            this.dgv_students.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.students_datasource = manager_students.Students;
            show_students();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fm_add_student fm_Add_Student = new fm_add_student(manager_students);
            fm_Add_Student.ShowDialog();
            this.students_datasource = this.manager_students.Students;
            show_students();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Вы действительно хотите отчислить данного студента?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                int index = dgv_students.SelectedRows[0].Index;
                Student student = this.students_datasource[index] as Student;

                //удаляем все оценки данного студента
                Manager_Student_Progress manager_Student_Progress = new Manager_Student_Progress();
                manager_Student_Progress.delete_by_student(student);
                manager_Student_Progress.save();

                //удаляем все занятия данного студента
                Manager_Lessons manager_Lessons = new Manager_Lessons();
                manager_Lessons.delete_by_student(student);
                manager_Lessons.save();

                //удаляем самого студента
                this.manager_students.delete(student.Id);
                this.manager_students.save();
                this.students_datasource = this.manager_students.Students;
                show_students();
            }
        }

        private void dgv_students_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_students.SelectedRows[0].Index;
            Student student = this.students_datasource[index] as Student;
            fm_add_student fm_Add_Student = new fm_add_student(student, manager_students);
            fm_Add_Student.ShowDialog();
            
            this.students_datasource = this.manager_students.Students;
            show_students();
        }

        private void dgv_students_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgv_students.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgv_students.ClearSelection();
                    dgv_students.Rows[hit.RowIndex].Selected = true;
                    CMS.Show(dgv_students, e.Location);
                }
            }
        }

        private void cms_change_Click(object sender, EventArgs e)
        {
            int index = dgv_students.SelectedRows[0].Index;
            Student student = this.students_datasource[index] as Student;
            fm_add_student fm_Add_Student = new fm_add_student(student, manager_students);
            fm_Add_Student.ShowDialog();

            this.students_datasource = this.manager_students.Students;
            show_students();
        }

        private void cms_delete_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Вы действительно хотите отчислить данного студента?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                int index = dgv_students.SelectedRows[0].Index;
                Student student = this.students_datasource[index] as Student;

                //удаляем все оценки данного студента
                Manager_Student_Progress manager_Student_Progress = new Manager_Student_Progress();
                manager_Student_Progress.delete_by_student(student);
                manager_Student_Progress.save();

                //удаляем все занятия данного студента
                Manager_Lessons manager_Lessons = new Manager_Lessons();
                manager_Lessons.delete_by_student(student);
                manager_Lessons.save();

                //удаляем самого студента
                this.manager_students.delete(student.Id);
                this.manager_students.save();
                this.students_datasource = this.manager_students.Students;
                show_students();
            }
        }
    }
}
