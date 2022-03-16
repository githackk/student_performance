using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Курсовая_работа.classes;

namespace Курсовая_работа.forms
{
    public partial class fm_add_student : Form
    {
        Student student;
        Manager_Students manager;
        Manager_Groups manager_groups;
        public fm_add_student(Manager_Students manager_Students)
        {
            InitializeComponent();
            this.student = new Student();
            this.manager = manager_Students;
            this.manager_groups = new Manager_Groups();
            button1.Visible = true;
            button3.Visible = false;
            this.Text = "Добавление студента";
        }

        public fm_add_student(Student student, Manager_Students manager_Students)
        {
            InitializeComponent();
            this.student = student;
            this.manager = manager_Students;
            this.manager_groups = new Manager_Groups();
            button1.Visible = false;
            button3.Visible = true;
            textBox1.Text = student.Surname;
            textBox2.Text = student.Name;
            textBox3.Text = student.Patronymic;
            this.Text = "Изменение параметров студента";
        }

        private void fm_add_student_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < manager_groups.Groups.Count; i++)
            {
                comboBox1.Items.Add(manager_groups.Groups[i].Name);
            }
            if (student.Group != null)
            {
                comboBox1.Text = student.Group.Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //проверка корректности введенных данных
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "") 
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            student.Surname = textBox1.Text;
            student.Name = textBox2.Text;
            student.Patronymic = textBox3.Text;
            student.Group = manager_groups.SearchByName(comboBox1.Text);
            this.manager.add(student);
            this.manager.save();

            //присваем студенту нули по всем заданиям, к которым он причастен
            Manager_Student_Progress manager_Student_Progress = new Manager_Student_Progress();
            manager_Student_Progress.assign_null_mark_student(student);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (student.Group.Name != comboBox1.Text)
            {
                var message = MessageBox.Show("Вся информация, связанная с предыдущей группой будет удалена! Перевести студента в другую группу?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (message == DialogResult.Yes)
                {
                    //удаляем все оценки данного студента
                    Manager_Student_Progress manager_Student_Progress = new Manager_Student_Progress();
                    manager_Student_Progress.delete_by_student(student);
                    manager_Student_Progress.save();

                    //удаляем все занятия данного студента
                    Manager_Lessons manager_Lessons = new Manager_Lessons();
                    manager_Lessons.delete_by_student(student);
                    manager_Lessons.save();

                    student.Surname = textBox1.Text;
                    student.Name = textBox2.Text;
                    student.Patronymic = textBox3.Text;
                    student.Group = manager_groups.SearchByName(comboBox1.Text);

                    manager_Student_Progress.assign_null_mark_student(student);

                    this.manager.save();
                }
                else
                {
                    return;
                }
            }
            else
            {
                student.Surname = textBox1.Text;
                student.Name = textBox2.Text;
                student.Patronymic = textBox3.Text;
                this.manager.save();
            }
            this.Close();
        }
    }
}
