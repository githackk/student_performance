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
    public partial class fm_set_mark : Form
    {
        Student_Progress mark;
        Manager_Student_Progress manager_Student_Progress;
        Additional_Lesson additional_Lesson;
        Current_Lesson current_Lesson;
        Distance_Lesson distance_Lesson;
        public fm_set_mark()
        {
            InitializeComponent();
        }

        private void fm_set_mark_Load(object sender, EventArgs e)
        {
            show_mark_parameters();
            if (mark.Completed == true)
                button2.Enabled = false;
        }

        public fm_set_mark(Student_Progress mark, Additional_Lesson additional_Lesson, Manager_Student_Progress manager_Student_Progress)
        {
            InitializeComponent();
            this.mark = mark;
            this.additional_Lesson = additional_Lesson;
            this.manager_Student_Progress = manager_Student_Progress;
        }

        public fm_set_mark(Student_Progress mark, Current_Lesson current_Lesson, Manager_Student_Progress manager_Student_Progress)
        {
            InitializeComponent();
            this.mark = mark;
            this.current_Lesson = current_Lesson;
            this.manager_Student_Progress = manager_Student_Progress;
        }

        public fm_set_mark(Student_Progress mark, Manager_Student_Progress manager_Student_Progress)
        {
            InitializeComponent();
            this.mark = mark;
            this.manager_Student_Progress = manager_Student_Progress;
        }

        public fm_set_mark(Student_Progress mark, Distance_Lesson distance_Lesson, Manager_Student_Progress manager_Student_Progress)
        {
            InitializeComponent();
            this.mark = mark;
            this.distance_Lesson = distance_Lesson;
            this.manager_Student_Progress = manager_Student_Progress;
        }

        private void show_mark_parameters()
        {
            textBox1.Text = "(" + mark.Student.Id + ") " + mark.Student.Surname + " " + 
                mark.Student.Name.Substring(0, 1) + "." + mark.Student.Patronymic.Substring(0, 1) + ".";
            textBox2.Text = mark.Task.Discipline.Name;
            textBox3.Text = mark.Task.Name;
            textBox4.Text = Convert.ToString(mark.Amount_of_Attemps);
            textBox5.Text = Convert.ToString(mark.Task.Max_Mark);
            if (additional_Lesson != null)
                textBox7.Text = Convert.ToString(additional_Lesson.Date_of_Lesson);
            else if (current_Lesson != null)
                textBox7.Text = Convert.ToString(current_Lesson.Date_of_Lesson);
            else if (distance_Lesson != null)
                textBox7.Text = Convert.ToString(distance_Lesson.Date_of_Lesson);
            else
                textBox7.Text = Convert.ToString(DateTime.Now);
            textBox6.Text = Convert.ToString(mark.Mark);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Поле оценки пустое!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Convert.ToInt32(textBox6.Text) > mark.Task.Max_Mark)
            {
                MessageBox.Show("Оценка превышает максимальную оценку, которую можно получить за задание!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (((double)Convert.ToInt32(textBox6.Text) / (double)mark.Task.Max_Mark) < 0.6)
            {
                var message = MessageBox.Show("Студент набрал меньше 60% баллов! Будем считать, что студент завалил задание?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.Yes)
                {
                    mark.Amount_of_Attemps++;

                    if (distance_Lesson != null)
                        mark.Completed_Date = distance_Lesson.Date_of_Lesson;
                    else if (additional_Lesson != null)
                        mark.Completed_Date = additional_Lesson.Date_of_Lesson;
                    else if (current_Lesson != null)
                        mark.Completed_Date = current_Lesson.Date_of_Lesson;

                    mark.Completed = false;
                    mark.Mark = Convert.ToInt32(textBox6.Text);
                }
                else
                    return;
            }
            else if (distance_Lesson != null || additional_Lesson != null || current_Lesson != null) 
            {
                mark.Amount_of_Attemps++;

                if (distance_Lesson != null)
                    mark.Completed_Date = distance_Lesson.Date_of_Lesson;
                else if (additional_Lesson != null)
                    mark.Completed_Date = additional_Lesson.Date_of_Lesson;
                else if (current_Lesson != null)
                    mark.Completed_Date = current_Lesson.Date_of_Lesson;

                mark.Mark = Convert.ToInt32(textBox6.Text);
                mark.Completed = true;
            }
            else
            {
                mark.Amount_of_Attemps++;

                mark.Completed_Date = DateTime.Now;
                mark.Mark = Convert.ToInt32(textBox6.Text);
                mark.Completed = true;
            }

            this.manager_Student_Progress.save();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mark.Amount_of_Attemps++;
            this.manager_Student_Progress.save();
            this.Close();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox6.TextLength > 2 && !(Char.IsControl(e.KeyChar)))//максимум - 3 цифры
            {
                e.Handled = true;
            }
            else if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))//только цифры
            {
                e.Handled = true;
            }
        }
    }
}
