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
    public partial class fm_add_discipline : Form
    {
        Discipline discipline;
        Manager_Disciplines manager;
        Manager_Groups manager_groups;
        public fm_add_discipline(Manager_Disciplines manager_Disciplines)
        {
            InitializeComponent();
            this.manager = manager_Disciplines;
            this.discipline = new Discipline();
            this.manager_groups = new Manager_Groups();
            button1.Visible = true;
            button3.Visible = false;
            this.Text = "Добавление дисциплины";
        }

        public fm_add_discipline(Discipline discipline, Manager_Disciplines manager_Disciplines)
        {
            InitializeComponent();
            this.discipline = discipline;
            this.manager = manager_Disciplines;
            this.manager_groups = new Manager_Groups();

            button1.Visible = false;
            button3.Visible = true;
            textBox1.Text = discipline.Name;
            this.Text = "Изменение параметров дисциплины";
        }

        private void fm_add_discipline_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < manager_groups.Groups.Count; i++)
            {
                comboBox1.Items.Add(manager_groups.Groups[i].Name);
            }
            if (discipline.Group != null)
            {
                comboBox1.Text = discipline.Group.Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //проверка корректности введенных данных
            if (textBox1.Text == "" || comboBox1.Text == "") 
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            discipline.Name = textBox1.Text;
            discipline.Group = manager_groups.SearchByName(comboBox1.Text);
            this.manager.add(discipline);
            this.manager.save();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (discipline.Group.Name != comboBox1.Text)
            {
                var message = MessageBox.Show("Вся информация, связанная с предыдущей группой будет удалена! Изменить у дисциплины группу?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (message == DialogResult.Yes)
                {
                    //удаляем все занятия относящиеся к данной дисциплине
                    Manager_Lessons manager_Lessons = new Manager_Lessons();
                    manager_Lessons.delete_by_discipline(discipline);
                    manager_Lessons.save();

                    //удаляем все задания и оценки по данной дисциплине
                    Manager_Tasks manager_Tasks = new Manager_Tasks();
                    manager_Tasks.delete_by_discipline(discipline);
                    manager_Tasks.save();

                    discipline.Name = textBox1.Text;
                    discipline.Group = manager_groups.SearchByName(comboBox1.Text);

                    this.manager.save();
                }
                else
                {
                    return;
                }
            }
            else
            {
                discipline.Name = textBox1.Text;
                this.manager.save();
            }
            this.Close();
        }
    }
}
