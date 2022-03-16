namespace Курсовая_работа
{
    partial class fm_students
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_students));
            this.dgv_students = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speciality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.course_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_change = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_delete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_students)).BeginInit();
            this.CMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_students
            // 
            this.dgv_students.AllowUserToAddRows = false;
            this.dgv_students.AllowUserToDeleteRows = false;
            this.dgv_students.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_students.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_students.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.surname,
            this.name,
            this.patronymic,
            this.speciality,
            this.course_number,
            this.group});
            this.dgv_students.Location = new System.Drawing.Point(11, 12);
            this.dgv_students.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgv_students.Name = "dgv_students";
            this.dgv_students.ReadOnly = true;
            this.dgv_students.RowHeadersWidth = 51;
            this.dgv_students.RowTemplate.Height = 24;
            this.dgv_students.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_students.Size = new System.Drawing.Size(960, 424);
            this.dgv_students.TabIndex = 0;
            this.dgv_students.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_students_CellDoubleClick);
            this.dgv_students.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgv_students_MouseDown);
            // 
            // ID
            // 
            this.ID.HeaderText = "Номер зачетной книжки";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // surname
            // 
            this.surname.HeaderText = "Фамилия";
            this.surname.MinimumWidth = 6;
            this.surname.Name = "surname";
            this.surname.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Имя";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // patronymic
            // 
            this.patronymic.HeaderText = "Отчество";
            this.patronymic.MinimumWidth = 6;
            this.patronymic.Name = "patronymic";
            this.patronymic.ReadOnly = true;
            // 
            // speciality
            // 
            this.speciality.HeaderText = "Специальность";
            this.speciality.MinimumWidth = 6;
            this.speciality.Name = "speciality";
            this.speciality.ReadOnly = true;
            // 
            // course_number
            // 
            this.course_number.HeaderText = "Курс";
            this.course_number.MinimumWidth = 6;
            this.course_number.Name = "course_number";
            this.course_number.ReadOnly = true;
            // 
            // group
            // 
            this.group.HeaderText = "Группа";
            this.group.MinimumWidth = 6;
            this.group.Name = "group";
            this.group.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 467);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Зачислить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(651, 467);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Отчислить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CMS
            // 
            this.CMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_change,
            this.cms_delete});
            this.CMS.Name = "CMS";
            this.CMS.Size = new System.Drawing.Size(151, 52);
            // 
            // cms_change
            // 
            this.cms_change.Name = "cms_change";
            this.cms_change.Size = new System.Drawing.Size(150, 24);
            this.cms_change.Text = "Изменить";
            this.cms_change.Click += new System.EventHandler(this.cms_change_Click);
            // 
            // cms_delete
            // 
            this.cms_delete.Name = "cms_delete";
            this.cms_delete.Size = new System.Drawing.Size(150, 24);
            this.cms_delete.Text = "Отчислить";
            this.cms_delete.Click += new System.EventHandler(this.cms_delete_Click);
            // 
            // fm_students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 508);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_students);
            this.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "fm_students";
            this.Text = "Студенты";
            this.Load += new System.EventHandler(this.fm_students_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_students)).EndInit();
            this.CMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_students;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciality;
        private System.Windows.Forms.DataGridViewTextBoxColumn course_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn group;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem cms_change;
        private System.Windows.Forms.ToolStripMenuItem cms_delete;
    }
}