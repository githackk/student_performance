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
    public partial class fm_add_group : Form
    {
        Group group;
        Manager_Groups manager_Groups;
        public fm_add_group(Manager_Groups manager)
        {
            InitializeComponent();
            this.manager_Groups = manager;
            this.group = new Group();
            button1.Visible = true;
            button3.Visible = false;
            this.Text = "Добавление группы";
        }

        public fm_add_group(Group group, Manager_Groups manager)
        {
            InitializeComponent();
            this.group = group;//зачем здесь равенство, почему так определяется
            this.manager_Groups = manager;
            button1.Visible = false;
            button3.Visible = true;
            textBox1.Text = group.Name;
            textBox2.Text = group.Speciality;
            textBox3.Text = Convert.ToString(group.Course);
            textBox4.Text = group.Faculty;
            this.Text = "Изменение параметров группы";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //проверка корректности введенных данных
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (manager_Groups.check_same_name(textBox1.Text) == true)
            {
                MessageBox.Show("Группа с таким названием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            group.Name = textBox1.Text;
            group.Speciality = textBox2.Text;
            group.Course = Convert.ToInt32(textBox3.Text);
            group.Faculty = textBox4.Text;
            this.manager_Groups.add(group);
            this.manager_Groups.save();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (manager_Groups.check_same_name(textBox1.Text) == true && group.Name != textBox1.Text) 
            {
                MessageBox.Show("Группа с таким наименованием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            group.Name = textBox1.Text;
            group.Speciality = textBox2.Text;
            group.Course = Convert.ToInt32(textBox3.Text);
            group.Faculty = textBox4.Text;
            this.manager_Groups.save();
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox3.TextLength > 0 && !(Char.IsControl(e.KeyChar)))//максимум - 1 цифра
            {
                e.Handled = true;
            }
            else if (!Char.IsDigit(e.KeyChar)&&!(Char.IsControl(e.KeyChar)))//только цифры
            {
                e.Handled = true;
            }
        }

        private void fm_add_group_Load(object sender, EventArgs e)
        {

        }
    }
}
