namespace Курсовая_работа
{
    partial class StartForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.студентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.студентыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.группыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дисциплиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_add_task = new System.Windows.Forms.Button();
            this.btn_create_lesson = new System.Windows.Forms.Button();
            this.btn_edit_progress = new System.Windows.Forms.Button();
            this.btn_show_excellent = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_set_marks = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЗанятиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_close = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.CMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.студентыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1116, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // студентыToolStripMenuItem
            // 
            this.студентыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.студентыToolStripMenuItem1,
            this.группыToolStripMenuItem,
            this.дисциплиныToolStripMenuItem});
            this.студентыToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.студентыToolStripMenuItem.Name = "студентыToolStripMenuItem";
            this.студентыToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.студентыToolStripMenuItem.Text = "Справочники";
            // 
            // студентыToolStripMenuItem1
            // 
            this.студентыToolStripMenuItem1.Name = "студентыToolStripMenuItem1";
            this.студентыToolStripMenuItem1.Size = new System.Drawing.Size(153, 26);
            this.студентыToolStripMenuItem1.Text = "Студенты";
            this.студентыToolStripMenuItem1.Click += new System.EventHandler(this.студентыToolStripMenuItem1_Click);
            // 
            // группыToolStripMenuItem
            // 
            this.группыToolStripMenuItem.Name = "группыToolStripMenuItem";
            this.группыToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.группыToolStripMenuItem.Text = "Группы";
            this.группыToolStripMenuItem.Click += new System.EventHandler(this.группыToolStripMenuItem_Click);
            // 
            // дисциплиныToolStripMenuItem
            // 
            this.дисциплиныToolStripMenuItem.Name = "дисциплиныToolStripMenuItem";
            this.дисциплиныToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.дисциплиныToolStripMenuItem.Text = "Дисциплины";
            this.дисциплиныToolStripMenuItem.Click += new System.EventHandler(this.дисциплиныToolStripMenuItem_Click);
            // 
            // btn_add_task
            // 
            this.btn_add_task.Location = new System.Drawing.Point(12, 153);
            this.btn_add_task.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_add_task.Name = "btn_add_task";
            this.btn_add_task.Size = new System.Drawing.Size(188, 51);
            this.btn_add_task.TabIndex = 1;
            this.btn_add_task.Text = "Выданные задания";
            this.btn_add_task.UseVisualStyleBackColor = true;
            this.btn_add_task.Click += new System.EventHandler(this.btn_add_task_Click);
            // 
            // btn_create_lesson
            // 
            this.btn_create_lesson.Location = new System.Drawing.Point(12, 95);
            this.btn_create_lesson.Name = "btn_create_lesson";
            this.btn_create_lesson.Size = new System.Drawing.Size(188, 51);
            this.btn_create_lesson.TabIndex = 2;
            this.btn_create_lesson.Text = "Создать занятие";
            this.btn_create_lesson.UseVisualStyleBackColor = true;
            this.btn_create_lesson.Click += new System.EventHandler(this.btn_create_lesson_Click);
            // 
            // btn_edit_progress
            // 
            this.btn_edit_progress.Location = new System.Drawing.Point(12, 211);
            this.btn_edit_progress.Name = "btn_edit_progress";
            this.btn_edit_progress.Size = new System.Drawing.Size(188, 51);
            this.btn_edit_progress.TabIndex = 3;
            this.btn_edit_progress.Text = "Успеваемость студентов";
            this.btn_edit_progress.UseVisualStyleBackColor = true;
            this.btn_edit_progress.Click += new System.EventHandler(this.btn_edit_progress_Click);
            // 
            // btn_show_excellent
            // 
            this.btn_show_excellent.Location = new System.Drawing.Point(12, 268);
            this.btn_show_excellent.Name = "btn_show_excellent";
            this.btn_show_excellent.Size = new System.Drawing.Size(188, 51);
            this.btn_show_excellent.TabIndex = 4;
            this.btn_show_excellent.Text = "Наиболее успевающие студенты";
            this.btn_show_excellent.UseVisualStyleBackColor = true;
            this.btn_show_excellent.Click += new System.EventHandler(this.btn_show_excellent_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(892, 390);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ID";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Вид";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Дисциплина";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Дата проведения";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Дополнительные сведения";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(206, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.85411F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.14589F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(898, 464);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(892, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "Предстоящие занятия";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CMS
            // 
            this.CMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_set_marks,
            this.удалитьЗанятиеToolStripMenuItem});
            this.CMS.Name = "CMS";
            this.CMS.Size = new System.Drawing.Size(284, 52);
            // 
            // cms_set_marks
            // 
            this.cms_set_marks.Name = "cms_set_marks";
            this.cms_set_marks.Size = new System.Drawing.Size(283, 24);
            this.cms_set_marks.Text = "Выставить оценки за занятие";
            this.cms_set_marks.Click += new System.EventHandler(this.cms_set_marks_Click);
            // 
            // удалитьЗанятиеToolStripMenuItem
            // 
            this.удалитьЗанятиеToolStripMenuItem.Name = "удалитьЗанятиеToolStripMenuItem";
            this.удалитьЗанятиеToolStripMenuItem.Size = new System.Drawing.Size(283, 24);
            this.удалитьЗанятиеToolStripMenuItem.Text = "Удалить занятие";
            this.удалитьЗанятиеToolStripMenuItem.Click += new System.EventHandler(this.удалитьЗанятиеToolStripMenuItem_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(12, 325);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(188, 51);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "Завершить работу";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 488);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_show_excellent);
            this.Controls.Add(this.btn_edit_progress);
            this.Controls.Add(this.btn_create_lesson);
            this.Controls.Add(this.btn_add_task);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StartForm";
            this.Text = "Успеваемость студентов";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.CMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem студентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem студентыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem группыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дисциплиныToolStripMenuItem;
        private System.Windows.Forms.Button btn_add_task;
        private System.Windows.Forms.Button btn_create_lesson;
        private System.Windows.Forms.Button btn_edit_progress;
        private System.Windows.Forms.Button btn_show_excellent;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem cms_set_marks;
        private System.Windows.Forms.ToolStripMenuItem удалитьЗанятиеToolStripMenuItem;
        private System.Windows.Forms.Button btn_close;
    }
}

