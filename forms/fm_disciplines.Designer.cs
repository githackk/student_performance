namespace Курсовая_работа
{
    partial class fm_disciplines
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_disciplines));
            this.dgv_disciplines = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_change = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_delete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_disciplines)).BeginInit();
            this.CMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_disciplines
            // 
            this.dgv_disciplines.AllowUserToAddRows = false;
            this.dgv_disciplines.AllowUserToDeleteRows = false;
            this.dgv_disciplines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_disciplines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_disciplines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.group});
            this.dgv_disciplines.Location = new System.Drawing.Point(10, 13);
            this.dgv_disciplines.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_disciplines.MultiSelect = false;
            this.dgv_disciplines.Name = "dgv_disciplines";
            this.dgv_disciplines.ReadOnly = true;
            this.dgv_disciplines.RowHeadersWidth = 51;
            this.dgv_disciplines.RowTemplate.Height = 24;
            this.dgv_disciplines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_disciplines.Size = new System.Drawing.Size(496, 296);
            this.dgv_disciplines.TabIndex = 0;
            this.dgv_disciplines.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_disciplines_CellDoubleClick);
            this.dgv_disciplines.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgv_disciplines_MouseDown);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Название";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
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
            this.button1.Location = new System.Drawing.Point(45, 357);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 357);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "Удалить";
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
            // fm_disciplines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 407);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_disciplines);
            this.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fm_disciplines";
            this.Text = "Дисциплины";
            this.Load += new System.EventHandler(this.fm_disciplines_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_disciplines)).EndInit();
            this.CMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_disciplines;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn group;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem cms_change;
        private System.Windows.Forms.ToolStripMenuItem cms_delete;
    }
}