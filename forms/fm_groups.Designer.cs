namespace Курсовая_работа
{
    partial class fm_groups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_groups));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgv_groups = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Speciality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Faculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_change = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_delete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_groups)).BeginInit();
            this.CMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 455);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 455);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgv_groups
            // 
            this.dgv_groups.AllowUserToAddRows = false;
            this.dgv_groups.AllowUserToDeleteRows = false;
            this.dgv_groups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_groups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_groups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.name,
            this.Speciality,
            this.Course,
            this.Faculty});
            this.dgv_groups.Location = new System.Drawing.Point(11, 12);
            this.dgv_groups.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgv_groups.MultiSelect = false;
            this.dgv_groups.Name = "dgv_groups";
            this.dgv_groups.ReadOnly = true;
            this.dgv_groups.RowHeadersWidth = 51;
            this.dgv_groups.RowTemplate.Height = 24;
            this.dgv_groups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_groups.Size = new System.Drawing.Size(629, 380);
            this.dgv_groups.TabIndex = 4;
            this.dgv_groups.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_groups_CellDoubleClick);
            this.dgv_groups.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgv_groups_MouseDown);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Название";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Speciality
            // 
            this.Speciality.HeaderText = "Специальность";
            this.Speciality.MinimumWidth = 6;
            this.Speciality.Name = "Speciality";
            this.Speciality.ReadOnly = true;
            // 
            // Course
            // 
            this.Course.HeaderText = "Курс";
            this.Course.MinimumWidth = 6;
            this.Course.Name = "Course";
            this.Course.ReadOnly = true;
            // 
            // Faculty
            // 
            this.Faculty.HeaderText = "Факультет";
            this.Faculty.MinimumWidth = 6;
            this.Faculty.Name = "Faculty";
            this.Faculty.ReadOnly = true;
            // 
            // CMS
            // 
            this.CMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_change,
            this.cms_delete});
            this.CMS.Name = "CMS";
            this.CMS.Size = new System.Drawing.Size(148, 52);
            // 
            // cms_change
            // 
            this.cms_change.Name = "cms_change";
            this.cms_change.Size = new System.Drawing.Size(147, 24);
            this.cms_change.Text = "Изменить";
            this.cms_change.Click += new System.EventHandler(this.cms_change_Click);
            // 
            // cms_delete
            // 
            this.cms_delete.Name = "cms_delete";
            this.cms_delete.Size = new System.Drawing.Size(147, 24);
            this.cms_delete.Text = "Удалить";
            this.cms_delete.Click += new System.EventHandler(this.cms_delete_Click);
            // 
            // fm_groups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 498);
            this.Controls.Add(this.dgv_groups);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "fm_groups";
            this.Text = "Группы";
            this.Load += new System.EventHandler(this.fm_groups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_groups)).EndInit();
            this.CMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgv_groups;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speciality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn Faculty;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem cms_change;
        private System.Windows.Forms.ToolStripMenuItem cms_delete;
    }
}