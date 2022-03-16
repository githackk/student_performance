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
    public partial class fm_disciplines : Form
    {
        List<Discipline> disciplines_datasource;
        Manager_Disciplines manager_disciplines;
        public fm_disciplines()
        {
            InitializeComponent();
            this.manager_disciplines = new Manager_Disciplines();
            this.dgv_disciplines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void show_disciplines()//вывод всех дисциплин в dgv
        {
            dgv_disciplines.RowCount = disciplines_datasource.Count;
            for (int i = 0; i < disciplines_datasource.Count; i++)
            {
                dgv_disciplines[0, i].Value = disciplines_datasource[i].Id;
                dgv_disciplines[1, i].Value = disciplines_datasource[i].Name;
                dgv_disciplines[2, i].Value = disciplines_datasource[i].Group.Name;
            }
        }

        private void fm_disciplines_Load(object sender, EventArgs e)
        {
            this.dgv_disciplines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.disciplines_datasource = manager_disciplines.Disciplines;
            show_disciplines();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fm_add_discipline fm_Add_Discipline = new fm_add_discipline(this.manager_disciplines);
            fm_Add_Discipline.ShowDialog();
            this.disciplines_datasource = this.manager_disciplines.Disciplines;
            show_disciplines();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Все задания дисциплины и оценки по ним будут удалены! Вы действительно хотите удалить выделенную дисциплину?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                int index = dgv_disciplines.SelectedRows[0].Index;
                Discipline discipline = this.disciplines_datasource[index] as Discipline;

                //удаляем все занятия относящиеся к данной дисциплине
                Manager_Lessons manager_Lessons = new Manager_Lessons();
                manager_Lessons.delete_by_discipline(discipline);
                manager_Lessons.save();

                //удаляем все задания и оценки по данной дисциплине
                Manager_Tasks manager_Tasks = new Manager_Tasks();
                manager_Tasks.delete_by_discipline(discipline);
                manager_Tasks.save();

                //удаляем саму дисциплину
                this.manager_disciplines.delete(discipline.Id);
                this.manager_disciplines.save();
                this.disciplines_datasource = this.manager_disciplines.Disciplines;

                show_disciplines();
            }
        }

        private void dgv_disciplines_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_disciplines.SelectedRows[0].Index;
            Discipline discipline = this.disciplines_datasource[index] as Discipline;
            fm_add_discipline fm_Add_Discipline = new fm_add_discipline(discipline, manager_disciplines);
            fm_Add_Discipline.ShowDialog();
            this.disciplines_datasource = this.manager_disciplines.Disciplines;
            show_disciplines();
        }

        private void dgv_disciplines_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgv_disciplines.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgv_disciplines.ClearSelection();
                    dgv_disciplines.Rows[hit.RowIndex].Selected = true;
                    CMS.Show(dgv_disciplines, e.Location);
                }
            }
        }

        private void cms_change_Click(object sender, EventArgs e)
        {
            int index = dgv_disciplines.SelectedRows[0].Index;
            Discipline discipline = this.disciplines_datasource[index] as Discipline;
            fm_add_discipline fm_Add_Discipline = new fm_add_discipline(discipline, manager_disciplines);
            fm_Add_Discipline.ShowDialog();
            this.disciplines_datasource = this.manager_disciplines.Disciplines;
            show_disciplines();
        }

        private void cms_delete_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Все задания дисциплины и оценки по ним будут удалены! Вы действительно хотите удалить выделенную дисциплину?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                int index = dgv_disciplines.SelectedRows[0].Index;
                Discipline discipline = this.disciplines_datasource[index] as Discipline;

                //удаляем все занятия относящиеся к данной дисциплине
                Manager_Lessons manager_Lessons = new Manager_Lessons();
                manager_Lessons.delete_by_discipline(discipline);
                manager_Lessons.save();

                //удаляем все задания и оценки по данной дисциплине
                Manager_Tasks manager_Tasks = new Manager_Tasks();
                manager_Tasks.delete_by_discipline(discipline);
                manager_Tasks.save();

                //удаляем саму дисциплину
                this.manager_disciplines.delete(discipline.Id);
                this.manager_disciplines.save();
                this.disciplines_datasource = this.manager_disciplines.Disciplines;

                show_disciplines();
            }
        }

        
    }
}
