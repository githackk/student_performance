namespace Курсовая_работа.forms
{
    partial class fm_create_lesson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_create_lesson));
            this.cb_lesson = new System.Windows.Forms.ComboBox();
            this.dt_lesson = new System.Windows.Forms.DateTimePicker();
            this.cb_discipline = new System.Windows.Forms.ComboBox();
            this.cb_group = new System.Windows.Forms.ComboBox();
            this.tb_audience_number = new System.Windows.Forms.TextBox();
            this.cb_students = new System.Windows.Forms.ComboBox();
            this.cb_tasks = new System.Windows.Forms.ComboBox();
            this.tb_confID = new System.Windows.Forms.TextBox();
            this.tb_pass_confID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_lesson
            // 
            this.cb_lesson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_lesson.FormattingEnabled = true;
            this.cb_lesson.Items.AddRange(new object[] {
            "Текущее занятие",
            "Дополнительное занятие",
            "Дистанционное занятие"});
            this.cb_lesson.Location = new System.Drawing.Point(246, 82);
            this.cb_lesson.Name = "cb_lesson";
            this.cb_lesson.Size = new System.Drawing.Size(299, 29);
            this.cb_lesson.TabIndex = 0;
            this.cb_lesson.SelectedIndexChanged += new System.EventHandler(this.cb_lesson_SelectedIndexChanged);
            // 
            // dt_lesson
            // 
            this.dt_lesson.CustomFormat = "d.MM.yyyy HH:m";
            this.dt_lesson.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dt_lesson.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_lesson.Location = new System.Drawing.Point(246, 117);
            this.dt_lesson.Name = "dt_lesson";
            this.dt_lesson.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dt_lesson.ShowUpDown = true;
            this.dt_lesson.Size = new System.Drawing.Size(299, 32);
            this.dt_lesson.TabIndex = 1;
            // 
            // cb_discipline
            // 
            this.cb_discipline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_discipline.FormattingEnabled = true;
            this.cb_discipline.Location = new System.Drawing.Point(246, 190);
            this.cb_discipline.Name = "cb_discipline";
            this.cb_discipline.Size = new System.Drawing.Size(299, 29);
            this.cb_discipline.TabIndex = 2;
            this.cb_discipline.TextChanged += new System.EventHandler(this.cb_discipline_TextChanged);
            // 
            // cb_group
            // 
            this.cb_group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_group.FormattingEnabled = true;
            this.cb_group.Location = new System.Drawing.Point(246, 155);
            this.cb_group.Name = "cb_group";
            this.cb_group.Size = new System.Drawing.Size(299, 29);
            this.cb_group.TabIndex = 3;
            this.cb_group.TextChanged += new System.EventHandler(this.cb_group_TextChanged);
            // 
            // tb_audience_number
            // 
            this.tb_audience_number.Location = new System.Drawing.Point(246, 226);
            this.tb_audience_number.Name = "tb_audience_number";
            this.tb_audience_number.Size = new System.Drawing.Size(299, 28);
            this.tb_audience_number.TabIndex = 4;
            this.tb_audience_number.Visible = false;
            // 
            // cb_students
            // 
            this.cb_students.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_students.FormattingEnabled = true;
            this.cb_students.Location = new System.Drawing.Point(246, 225);
            this.cb_students.Name = "cb_students";
            this.cb_students.Size = new System.Drawing.Size(299, 29);
            this.cb_students.TabIndex = 5;
            this.cb_students.Visible = false;
            // 
            // cb_tasks
            // 
            this.cb_tasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tasks.FormattingEnabled = true;
            this.cb_tasks.Location = new System.Drawing.Point(246, 259);
            this.cb_tasks.Name = "cb_tasks";
            this.cb_tasks.Size = new System.Drawing.Size(299, 29);
            this.cb_tasks.TabIndex = 6;
            this.cb_tasks.Visible = false;
            // 
            // tb_confID
            // 
            this.tb_confID.Location = new System.Drawing.Point(246, 260);
            this.tb_confID.Name = "tb_confID";
            this.tb_confID.Size = new System.Drawing.Size(299, 28);
            this.tb_confID.TabIndex = 7;
            this.tb_confID.Visible = false;
            this.tb_confID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_confID_KeyPress);
            // 
            // tb_pass_confID
            // 
            this.tb_pass_confID.Location = new System.Drawing.Point(246, 293);
            this.tb_pass_confID.Name = "tb_pass_confID";
            this.tb_pass_confID.Size = new System.Drawing.Size(299, 28);
            this.tb_pass_confID.TabIndex = 8;
            this.tb_pass_confID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Вид занятия:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Дата и время занятия:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Дисциплина:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Группа:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 21);
            this.label6.TabIndex = 14;
            this.label6.Text = "label6";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(92, 296);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 31);
            this.button1.TabIndex = 16;
            this.button1.Text = "Ок";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(404, 368);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 31);
            this.button2.TabIndex = 17;
            this.button2.Text = "Отменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fm_create_lesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 411);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_pass_confID);
            this.Controls.Add(this.tb_confID);
            this.Controls.Add(this.cb_tasks);
            this.Controls.Add(this.cb_students);
            this.Controls.Add(this.tb_audience_number);
            this.Controls.Add(this.cb_group);
            this.Controls.Add(this.cb_discipline);
            this.Controls.Add(this.dt_lesson);
            this.Controls.Add(this.cb_lesson);
            this.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fm_create_lesson";
            this.Text = "Создать занятие";
            this.Load += new System.EventHandler(this.fm_create_lesson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_lesson;
        private System.Windows.Forms.DateTimePicker dt_lesson;
        private System.Windows.Forms.ComboBox cb_discipline;
        private System.Windows.Forms.ComboBox cb_group;
        private System.Windows.Forms.TextBox tb_audience_number;
        private System.Windows.Forms.ComboBox cb_students;
        private System.Windows.Forms.ComboBox cb_tasks;
        private System.Windows.Forms.TextBox tb_confID;
        private System.Windows.Forms.TextBox tb_pass_confID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}