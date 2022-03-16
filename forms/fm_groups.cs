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
    public partial class fm_groups : Form
    {
        List<Group> groups_datasource;
        Manager_Groups manager_Groups;
        public fm_groups()
        {
            InitializeComponent();
            this.dgv_groups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            manager_Groups = new Manager_Groups();
        }

        private void show_groups()//выводит на экран то, что находится на данный момент в groups_datasource (текущий список групп)
        {
            dgv_groups.RowCount = groups_datasource.Count;
            for (int i = 0; i < groups_datasource.Count; i++)
            {
                dgv_groups[0, i].Value = groups_datasource[i].Id;
                dgv_groups[1, i].Value = groups_datasource[i].Name;
                dgv_groups[2, i].Value = groups_datasource[i].Speciality;
                dgv_groups[3, i].Value = groups_datasource[i].Course;
                dgv_groups[4, i].Value = groups_datasource[i].Faculty;
            }
            this.dgv_groups.Sort(this.dgv_groups.Columns[3], ListSortDirection.Ascending);
        }

        private void fm_groups_Load(object sender, EventArgs e)
        {
            this.dgv_groups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groups_datasource = this.manager_Groups.Groups;
            show_groups();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fm_add_group fm_Add_Group = new fm_add_group(this.manager_Groups);
            fm_Add_Group.ShowDialog();
            this.groups_datasource = this.manager_Groups.Groups;
            show_groups();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Все студенты и дисциплины группы будут удалены! Вы действительно хотите удалить выделенную группу?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                int index = dgv_groups.SelectedRows[0].Index;
                Group group = this.groups_datasource[index] as Group;

                //удаляем все дисциплины данной группы
                Manager_Disciplines manager_Disciplines = new Manager_Disciplines();
                manager_Disciplines.delete_by_group(group);
                manager_Disciplines.save();

                //удаляем всех студентов данной группы
                Manager_Students manager_Students = new Manager_Students();
                manager_Students.delete_by_group(group);
                manager_Students.save();

                //удаляем саму группу
                this.manager_Groups.delete_by_id(group.Id);
                this.manager_Groups.save();
                this.groups_datasource = this.manager_Groups.Groups;

                show_groups();
            }
        }

        private void dgv_groups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_groups.SelectedRows[0].Index;
            Group group = this.groups_datasource[index] as Group;
            fm_add_group fm_Add_Group = new fm_add_group(group, manager_Groups);
            fm_Add_Group.ShowDialog();
            this.groups_datasource = this.manager_Groups.Groups;
            show_groups();
        }

        private void dgv_groups_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgv_groups.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgv_groups.ClearSelection();
                    dgv_groups.Rows[hit.RowIndex].Selected = true;
                    CMS.Show(dgv_groups, e.Location);
                }
            }
        }

        private void cms_change_Click(object sender, EventArgs e)
        {
            int index = dgv_groups.SelectedRows[0].Index;
            Group group = this.groups_datasource[index] as Group;
            fm_add_group fm_Add_Group = new fm_add_group(group, manager_Groups);
            fm_Add_Group.ShowDialog();
            this.groups_datasource = this.manager_Groups.Groups;
            show_groups();
        }

        private void cms_delete_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Все студенты и дисциплины группы будут удалены! Вы действительно хотите удалить выделенную группу?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                int index = dgv_groups.SelectedRows[0].Index;
                Group group = this.groups_datasource[index] as Group;

                //удаляем все дисциплины данной группы
                Manager_Disciplines manager_Disciplines = new Manager_Disciplines();
                manager_Disciplines.delete_by_group(group);
                manager_Disciplines.save();

                //удаляем всех студентов данной группы
                Manager_Students manager_Students = new Manager_Students();
                manager_Students.delete_by_group(group);
                manager_Students.save();

                //удаляем саму группу
                this.manager_Groups.delete_by_id(group.Id);
                this.manager_Groups.save();
                this.groups_datasource = this.manager_Groups.Groups;

                show_groups();
            }
        }
    }
}
