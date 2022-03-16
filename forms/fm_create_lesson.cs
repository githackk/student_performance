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
    public partial class fm_create_lesson : Form
    {
        Manager_Disciplines manager_Disciplines;
        Manager_Groups manager_Groups;
        Manager_Lessons manager_Lessons;
        Manager_Students manager_Students;
        Manager_Tasks manager_Tasks;
        public fm_create_lesson(Manager_Lessons manager_Lessons)
        {
            InitializeComponent();
            this.manager_Lessons = manager_Lessons;
            this.manager_Disciplines = new Manager_Disciplines();
            this.manager_Groups = new Manager_Groups();
            this.manager_Students = new Manager_Students();
            this.manager_Tasks = new Manager_Tasks();
        }

        private void fm_create_lesson_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < manager_Groups.Groups.Count; i++)
            {
                cb_group.Items.Add(manager_Groups.Groups[i].Name);
            }
        }

        private void cb_lesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            tb_audience_number.Visible = false;
            tb_confID.Visible = false;
            tb_pass_confID.Visible = false;
            cb_students.Visible = false;
            cb_tasks.Visible = false;
            if (cb_lesson.Text == "Текущее занятие")
            {
                label5.Text = "Номер аудитории:";
                label5.Visible = true;
                tb_audience_number.Visible = true;

                label6.Text = "Задание:";
                label6.Visible = true;
                cb_tasks.Visible = true;
                //формирование списка заданий
            }
            else if (cb_lesson.Text == "Дополнительное занятие")
            {
                label5.Text = "Номер аудитории:";
                label5.Visible = true;
                tb_audience_number.Visible = true;
            }
            else if (cb_lesson.Text=="Дистанционное занятие")
            {
                label5.Text = "Студент";
                label5.Visible = true;
                cb_students.Visible = true;
                //сгенерировать список в cb
                label6.Text = "ID конференции:";
                label6.Visible = true;
                tb_confID.Visible = true;
                label7.Text = "Пароль конференции:";
                label7.Visible = true;
                tb_pass_confID.Visible = true;
            }    

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb_lesson.Text == "Дополнительное занятие")
            {
                //проверка корректности введенных данных
                if (cb_discipline.Text == "" || cb_group.Text == "" || tb_audience_number.Text == "")
                {
                    MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dt_lesson.Value < DateTime.Now)
                {
                    MessageBox.Show("Дата и время должны быть установлены позже даты и времени в настоящее время!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Additional_Lesson additional_Lesson = new Additional_Lesson();
                additional_Lesson.Discipline = manager_Disciplines.SearchByName(cb_discipline.Text);
                additional_Lesson.Group = manager_Groups.SearchByName(cb_group.Text);
                additional_Lesson.Audience_Number = tb_audience_number.Text;
                additional_Lesson.Date_of_Lesson = dt_lesson.Value;

                this.manager_Lessons.add_AdLe(additional_Lesson);
                this.manager_Lessons.save();
                this.Close();
            }
            else if (cb_lesson.Text == "Текущее занятие")
            {
                //проверка корректности введенных данных
                if (cb_discipline.Text == "" || cb_group.Text == "" || tb_audience_number.Text == "" || cb_tasks.Text == "") 
                {
                    MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dt_lesson.Value < DateTime.Today)
                {
                    MessageBox.Show("Дата и время должны быть установлены позже даты и времени в настоящее время!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dt_lesson.Value > manager_Tasks.SearchByName(cb_tasks.Text).Term)
                {
                    MessageBox.Show("Дата текущего занятия стоит позже срока задания! Срок задания: " + manager_Tasks.SearchByName(cb_tasks.Text).Term, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Current_Lesson current_Lesson = new Current_Lesson();
                current_Lesson.Discipline = manager_Disciplines.SearchByName(cb_discipline.Text);
                current_Lesson.Group = manager_Groups.SearchByName(cb_group.Text);
                current_Lesson.Audience_Number = tb_audience_number.Text;
                current_Lesson.Date_of_Lesson = dt_lesson.Value;
                current_Lesson.Task = manager_Tasks.SearchByName(cb_tasks.Text);

                this.manager_Lessons.add_CuLe(current_Lesson);
                this.manager_Lessons.save();
                this.Close();
            }
            else if (cb_lesson.Text == "Дистанционное занятие")
            {
                //проверка корректности введенных данных
                if (cb_discipline.Text == "" || cb_group.Text == "" || tb_confID.Text == "" || tb_pass_confID.Text == "" || cb_students.Text == "") 
                {
                    MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dt_lesson.Value < DateTime.Today)
                {
                    MessageBox.Show("Дата и время должны быть установлены позже даты и времени в настоящее время!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Distance_Lesson distance_Lesson = new Distance_Lesson();
                distance_Lesson.Discipline = manager_Disciplines.SearchByName(cb_discipline.Text);
                distance_Lesson.Group = manager_Groups.SearchByName(cb_group.Text);
                distance_Lesson.Date_of_Lesson = dt_lesson.Value;
                distance_Lesson.Conference_Id = tb_confID.Text;
                distance_Lesson.Conference_Password = tb_pass_confID.Text;
                distance_Lesson.Student = manager_Students.SearchByName(cb_students.Text);

                this.manager_Lessons.add_DiLe(distance_Lesson);
                this.manager_Lessons.save();
                this.Close();
            }
            else
            {
                MessageBox.Show("Поле вида занятия не заполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_discipline_TextChanged(object sender, EventArgs e)
        {
            cb_tasks.Items.Clear();
            List<classes.Task> tasks_by_discipline = manager_Tasks.SearchByDiscipline(manager_Disciplines.SearchByName(cb_discipline.Text));
            for (int i = 0; i < tasks_by_discipline.Count; i++)
            {
                cb_tasks.Items.Add(tasks_by_discipline[i].Name);
            }
        }

        private void cb_group_TextChanged(object sender, EventArgs e)
        {
            cb_students.Items.Clear();
            List<Student> students_by_group = manager_Students.SearchByGroup(manager_Groups.SearchByName(cb_group.Text));
            /*for (int i = 0; i < students_by_group.Count; i++)
            {
                cb_students.Items.Add(students_by_group[i]);
            }*/
            
            for (int i = 0; i < students_by_group.Count; i++)
            {
                cb_students.Items.Add("(" + students_by_group[i].Id+") " + students_by_group[i].Surname + " " + students_by_group[i].Name.Substring(0, 1) +
                    "." + students_by_group[i].Patronymic.Substring(0, 1) + ".");
            }
            cb_discipline.Items.Clear();
            List<Discipline> disciplines_by_group = manager_Disciplines.SearchByGroup(manager_Groups.SearchByName(cb_group.Text));
            /*for (int i = 0; i < disciplines_by_group.Count; i++)
            {
                cb_discipline.Items.Add(disciplines_by_group[i]);
            }*/
            for (int i = 0; i < disciplines_by_group.Count; i++)
            {
                cb_discipline.Items.Add(disciplines_by_group[i].Name + " (" + disciplines_by_group[i].Group.Name + ")");
            }
        }

        private void tb_confID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))//только цифры
            {
                e.Handled = true;
            }
        }
    }
}
