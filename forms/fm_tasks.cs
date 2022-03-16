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
    public partial class fm_tasks : Form
    {
        List<classes.Task> tasks_datasource;
        Manager_Tasks Manager_Tasks;
        Manager_Disciplines Manager_Disciplines;
        public fm_tasks()
        {
            InitializeComponent();
            this.Manager_Disciplines = new Manager_Disciplines();
            this.Manager_Tasks = new Manager_Tasks();
            this.dgv_tasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void fm_tasks_Load(object sender, EventArgs e)
        {
            this.tasks_datasource = Manager_Tasks.Tasks;
            for (int i = 0; i < Manager_Disciplines.Disciplines.Count; i++)
            {
                comboBox1.Items.Add(Manager_Disciplines.Disciplines[i].Name + " (" + Manager_Disciplines.Disciplines[i].Group.Name + ")");
            }
            this.dgv_tasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void show_tasks(Discipline discipline)//вывод всех заданий по определенной дисциплине в dgv
        {
            if (discipline == null)
                return;
            List<classes.Task> tasks_by_discipline = Manager_Tasks.SearchByDiscipline(discipline);
            dgv_tasks.RowCount = tasks_by_discipline.Count;
            for (int i = 0; i < tasks_by_discipline.Count; i++)
            {
                dgv_tasks[0, i].Value = tasks_by_discipline[i].Serial_Number_of_Theme;
                dgv_tasks[1, i].Value = tasks_by_discipline[i].Name;
                dgv_tasks[2, i].Value = tasks_by_discipline[i].Term;
                dgv_tasks[3, i].Value = tasks_by_discipline[i].Type_of_Lesson;
                dgv_tasks[4, i].Value = tasks_by_discipline[i].Theme_of_Lesson;
                dgv_tasks[5, i].Value = tasks_by_discipline[i].Max_Mark;
            }
            this.dgv_tasks.Sort(this.dgv_tasks.Columns[0], ListSortDirection.Ascending);
        }

        public fm_tasks(Discipline discipline, Manager_Tasks manager_Tasks)
        {
            InitializeComponent();
            this.Manager_Tasks = new Manager_Tasks();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fm_add_task fm_add_Task = new fm_add_task(Manager_Tasks);
            fm_add_Task.ShowDialog();
            this.tasks_datasource = this.Manager_Tasks.Tasks;
            show_tasks(Manager_Disciplines.SearchByName(comboBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Результаты и занятия по данному заданию будут удалены! Вы действительно хотите удалить данное задание?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                //передаем из dgv в Task элемент списка
                int index = dgv_tasks.SelectedRows[0].Index;
                classes.Task task = Manager_Tasks.search_by_serial_number(Convert.ToInt32(dgv_tasks[0, index].Value), Manager_Disciplines.SearchByName(comboBox1.Text));
                //удаляем все связанные с этим заданием результаты
                Manager_Student_Progress manager_Student_Progress = new Manager_Student_Progress();
                manager_Student_Progress.delete_by_task(task);
                manager_Student_Progress.save();
                //удаляем все связанные с ним занятия
                Manager_Lessons manager_Lessons = new Manager_Lessons();
                manager_Lessons.delete_by_task(task);
                manager_Lessons.save();
                //удаляем само задание
                this.Manager_Tasks.delete_by_id(task.Id);
                this.Manager_Tasks.save();
                this.tasks_datasource = this.Manager_Tasks.Tasks;
                show_tasks(Manager_Disciplines.SearchByName(comboBox1.Text));

                
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            dgv_tasks.RowCount = 0;
            show_tasks(Manager_Disciplines.SearchByName(comboBox1.Text));
        }

        private void dgv_tasks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_tasks.SelectedRows[0].Index;
            classes.Task task = Manager_Tasks.search_by_serial_number(Convert.ToInt32(dgv_tasks[0, index].Value), Manager_Disciplines.SearchByName(comboBox1.Text));
            fm_add_task fm_Add_Task = new fm_add_task(task, Manager_Tasks);
            fm_Add_Task.ShowDialog();
            this.tasks_datasource = this.Manager_Tasks.Tasks;
            show_tasks(Manager_Disciplines.SearchByName(comboBox1.Text));
        }


        private void dgv_tasks_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgv_tasks.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgv_tasks.ClearSelection();
                    dgv_tasks.Rows[hit.RowIndex].Selected = true;
                    contextMenuStrip1.Show(dgv_tasks, e.Location);
                }
            }
        }

        private void change_Click(object sender, EventArgs e)
        {
            int index = dgv_tasks.SelectedRows[0].Index;
            classes.Task task = Manager_Tasks.search_by_serial_number(Convert.ToInt32(dgv_tasks[0, index].Value), Manager_Disciplines.SearchByName(comboBox1.Text));
            fm_add_task fm_Add_Task = new fm_add_task(task, Manager_Tasks);
            fm_Add_Task.ShowDialog();
            this.tasks_datasource = this.Manager_Tasks.Tasks;
            show_tasks(Manager_Disciplines.SearchByName(comboBox1.Text));
        }

        private void delete_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Результаты и занятия по данному заданию будут удалены! Вы действительно хотите удалить данное задание?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                //передаем из dgv в Task элемент списка
                int index = dgv_tasks.SelectedRows[0].Index;
                classes.Task task = Manager_Tasks.search_by_serial_number(Convert.ToInt32(dgv_tasks[0, index].Value), Manager_Disciplines.SearchByName(comboBox1.Text));
                //удаляем все связанные с этим заданием результаты
                Manager_Student_Progress manager_Student_Progress = new Manager_Student_Progress();
                manager_Student_Progress.delete_by_task(task);
                manager_Student_Progress.save();
                //удаляем все связанные с ним занятия
                Manager_Lessons manager_Lessons = new Manager_Lessons();
                manager_Lessons.delete_by_task(task);
                manager_Lessons.save();
                //удаляем само задание
                this.Manager_Tasks.delete_by_id(task.Id);
                this.Manager_Tasks.save();
                this.tasks_datasource = this.Manager_Tasks.Tasks;
                show_tasks(Manager_Disciplines.SearchByName(comboBox1.Text));
            }
        }
    }
}
