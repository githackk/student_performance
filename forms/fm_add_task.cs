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
    public partial class fm_add_task : Form
    {
        classes.Task task;
        Manager_Tasks Manager_Tasks;
        Manager_Disciplines Manager_Disciplines;
        public fm_add_task(Manager_Tasks manager_Tasks)//для добавления
        {
            InitializeComponent();
            this.Manager_Tasks = manager_Tasks;
            this.task = new classes.Task();
            this.Manager_Disciplines = new Manager_Disciplines();
            button1.Visible = true;
            button3.Visible = false;
            this.Text = "Добавление задания";
        }

        public fm_add_task(classes.Task task, Manager_Tasks manager_Tasks)//для изменения
        {
            InitializeComponent();
            this.task = task;
            this.Manager_Tasks = manager_Tasks;
            this.Manager_Disciplines = new Manager_Disciplines();
            comboBox1.Enabled = false;
            textBox4.Enabled = false;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            button1.Visible = false;
            button3.Visible = true;
            textBox1.Text = task.Name;
            dt_term.Value = task.Term;
            textBox3.Text = task.Theme_of_Lesson;
            textBox4.Text = Convert.ToString(task.Serial_Number_of_Theme);
            textBox2.Text = Convert.ToString(task.Max_Mark);
            this.Text = "Изменение параметров задания";
        }

        private void fm_add_task_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Manager_Disciplines.Disciplines.Count; i++)
            {
                comboBox1.Items.Add(Manager_Disciplines.Disciplines[i].Name + " (" + Manager_Disciplines.Disciplines[i].Group.Name + ")");
            }
            if (task.Discipline != null && task.Type_of_Lesson != "")
            {
                comboBox1.Text = task.Discipline.Name + " (" + task.Discipline.Group.Name + ")";
                comboBox2.Text = task.Type_of_Lesson;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 3, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            //проверка корректности введенных данных
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (dt_term.Value < DateTime.Today)
            {
                MessageBox.Show("Дата и время должны быть установлены позже даты и времени в настоящее время!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Convert.ToInt32(textBox2.Text) > 100)
            {
                MessageBox.Show("Максимальный балл должен быть не больше 100!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Convert.ToInt32(textBox2.Text) < 5)
            {
                MessageBox.Show("Максимальный балл за выполнение задания должен быть не меньше 5!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (dt_term.Value < dateTime) 
            {
                MessageBox.Show("Минимальный срок выполнения задания - 3 дня!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Manager_Tasks.checking_serial_number(Convert.ToInt32(textBox4.Text), Manager_Disciplines.SearchByName(comboBox1.Text)) == true)
            {
                MessageBox.Show("Задание с таким порядковым номером уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            task.Name = textBox1.Text;
            task.Discipline = Manager_Disciplines.SearchByName(comboBox1.Text);
            task.Term = dt_term.Value;
            task.Type_of_Lesson = comboBox2.Text;
            task.Theme_of_Lesson = textBox3.Text;
            task.Serial_Number_of_Theme = Convert.ToInt32(textBox4.Text);
            task.Max_Mark = Convert.ToInt32(textBox2.Text);
            this.Manager_Tasks.add(task);
            this.Manager_Tasks.save();

            //всем, кто причастен к этому заданию, присваиваем нуль оценку
            Manager_Student_Progress manager_Student_Progress = new Manager_Student_Progress();
            manager_Student_Progress.assign_null_marks(task);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 3, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            //проверка корректности введенных данных
            if (textBox1.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox2.Text == "") 
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (dt_term.Value < DateTime.Now)
            {
                MessageBox.Show("Дата и время должны быть установлены позже даты и времени в настоящее время!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Convert.ToInt32(textBox2.Text) > 100)
            {
                MessageBox.Show("Максимальный балл должен быть не больше 100!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Convert.ToInt32(textBox2.Text) < 5)
            {
                MessageBox.Show("Максимальный балл за выполнение задания должен быть не меньше 5!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (dt_term.Value < dateTime)
            {
                MessageBox.Show("Минимальный срок выполнения задания - 3 дня!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            task.Name = textBox1.Text;
            task.Discipline = Manager_Disciplines.SearchByName(comboBox1.Text);
            task.Term = dt_term.Value;
            task.Type_of_Lesson = comboBox2.Text;
            task.Theme_of_Lesson = textBox3.Text;
            task.Max_Mark = Convert.ToInt32(textBox2.Text);
            this.Manager_Tasks.add(task);
            this.Manager_Tasks.save();
            this.Close();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.TextLength > 1 && !(Char.IsControl(e.KeyChar)))//максимум - 2 цифры
            {
                e.Handled = true;
            }
            else if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))//только цифры
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.TextLength > 2 && !(Char.IsControl(e.KeyChar)))//максимум - 3 цифры
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
