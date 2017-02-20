namespace OrmFramework
{
    partial class MainView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.groupBox_choosefolder = new System.Windows.Forms.GroupBox();
            this.label_folderpath = new System.Windows.Forms.Label();
            this.choosefolder_btn = new System.Windows.Forms.Button();
            this.folderBrowserDialog_csprojectfolder = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox_databaseobjects = new System.Windows.Forms.GroupBox();
            this.button_create_sp = new System.Windows.Forms.Button();
            this.button_createview = new System.Windows.Forms.Button();
            this.button_createtype = new System.Windows.Forms.Button();
            this.dataGridView_storedprocedures = new System.Windows.Forms.DataGridView();
            this.dataGridView_view = new System.Windows.Forms.DataGridView();
            this.dataGridView_table = new System.Windows.Forms.DataGridView();
            this.btn_map = new System.Windows.Forms.Button();
            this.writeclass_progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox_choosefolder.SuspendLayout();
            this.groupBox_databaseobjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_storedprocedures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_table)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_choosefolder
            // 
            this.groupBox_choosefolder.Controls.Add(this.label_folderpath);
            this.groupBox_choosefolder.Controls.Add(this.choosefolder_btn);
            this.groupBox_choosefolder.Location = new System.Drawing.Point(12, 12);
            this.groupBox_choosefolder.Name = "groupBox_choosefolder";
            this.groupBox_choosefolder.Size = new System.Drawing.Size(1072, 57);
            this.groupBox_choosefolder.TabIndex = 0;
            this.groupBox_choosefolder.TabStop = false;
            this.groupBox_choosefolder.Text = "Folder Path";
            // 
            // label_folderpath
            // 
            this.label_folderpath.AutoEllipsis = true;
            this.label_folderpath.Location = new System.Drawing.Point(143, 26);
            this.label_folderpath.Name = "label_folderpath";
            this.label_folderpath.Size = new System.Drawing.Size(904, 18);
            this.label_folderpath.TabIndex = 1;
            this.label_folderpath.Text = "No Folder Selected";
            // 
            // choosefolder_btn
            // 
            this.choosefolder_btn.Location = new System.Drawing.Point(25, 21);
            this.choosefolder_btn.Name = "choosefolder_btn";
            this.choosefolder_btn.Size = new System.Drawing.Size(92, 23);
            this.choosefolder_btn.TabIndex = 0;
            this.choosefolder_btn.Text = "Choose Folder";
            this.choosefolder_btn.UseVisualStyleBackColor = true;
            this.choosefolder_btn.Click += new System.EventHandler(this.choosefolder_btn_Click);
            // 
            // groupBox_databaseobjects
            // 
            this.groupBox_databaseobjects.Controls.Add(this.button_create_sp);
            this.groupBox_databaseobjects.Controls.Add(this.button_createview);
            this.groupBox_databaseobjects.Controls.Add(this.button_createtype);
            this.groupBox_databaseobjects.Controls.Add(this.dataGridView_storedprocedures);
            this.groupBox_databaseobjects.Controls.Add(this.dataGridView_view);
            this.groupBox_databaseobjects.Controls.Add(this.dataGridView_table);
            this.groupBox_databaseobjects.Location = new System.Drawing.Point(12, 99);
            this.groupBox_databaseobjects.Name = "groupBox_databaseobjects";
            this.groupBox_databaseobjects.Size = new System.Drawing.Size(1072, 333);
            this.groupBox_databaseobjects.TabIndex = 1;
            this.groupBox_databaseobjects.TabStop = false;
            this.groupBox_databaseobjects.Text = "Database Objects";
            // 
            // button_create_sp
            // 
            this.button_create_sp.Enabled = false;
            this.button_create_sp.Location = new System.Drawing.Point(229, 15);
            this.button_create_sp.Name = "button_create_sp";
            this.button_create_sp.Size = new System.Drawing.Size(104, 23);
            this.button_create_sp.TabIndex = 5;
            this.button_create_sp.Text = "Create Basic SP";
            this.button_create_sp.UseVisualStyleBackColor = true;
            this.button_create_sp.Click += new System.EventHandler(this.button_create_sp_Click);
            // 
            // button_createview
            // 
            this.button_createview.Enabled = false;
            this.button_createview.Location = new System.Drawing.Point(111, 15);
            this.button_createview.Name = "button_createview";
            this.button_createview.Size = new System.Drawing.Size(110, 23);
            this.button_createview.TabIndex = 4;
            this.button_createview.Text = "Create Basic View";
            this.button_createview.UseVisualStyleBackColor = true;
            this.button_createview.Click += new System.EventHandler(this.button_createview_Click);
            // 
            // button_createtype
            // 
            this.button_createtype.Enabled = false;
            this.button_createtype.Location = new System.Drawing.Point(24, 15);
            this.button_createtype.Name = "button_createtype";
            this.button_createtype.Size = new System.Drawing.Size(81, 23);
            this.button_createtype.TabIndex = 3;
            this.button_createtype.Text = "Create Type";
            this.button_createtype.UseVisualStyleBackColor = true;
            this.button_createtype.Click += new System.EventHandler(this.button_createtype_Click);
            // 
            // dataGridView_storedprocedures
            // 
            this.dataGridView_storedprocedures.AllowUserToAddRows = false;
            this.dataGridView_storedprocedures.AllowUserToDeleteRows = false;
            this.dataGridView_storedprocedures.AllowUserToResizeColumns = false;
            this.dataGridView_storedprocedures.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_storedprocedures.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_storedprocedures.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_storedprocedures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_storedprocedures.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_storedprocedures.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_storedprocedures.ColumnHeadersHeight = 40;
            this.dataGridView_storedprocedures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_storedprocedures.EnableHeadersVisualStyles = false;
            this.dataGridView_storedprocedures.Location = new System.Drawing.Point(723, 40);
            this.dataGridView_storedprocedures.Name = "dataGridView_storedprocedures";
            this.dataGridView_storedprocedures.RowHeadersVisible = false;
            this.dataGridView_storedprocedures.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_storedprocedures.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_storedprocedures.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView_storedprocedures.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_storedprocedures.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_storedprocedures.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.dataGridView_storedprocedures.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_storedprocedures.RowTemplate.Height = 40;
            this.dataGridView_storedprocedures.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_storedprocedures.Size = new System.Drawing.Size(324, 264);
            this.dataGridView_storedprocedures.TabIndex = 2;
            // 
            // dataGridView_view
            // 
            this.dataGridView_view.AllowUserToAddRows = false;
            this.dataGridView_view.AllowUserToDeleteRows = false;
            this.dataGridView_view.AllowUserToResizeColumns = false;
            this.dataGridView_view.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_view.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_view.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_view.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_view.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_view.ColumnHeadersHeight = 40;
            this.dataGridView_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_view.EnableHeadersVisualStyles = false;
            this.dataGridView_view.Location = new System.Drawing.Point(374, 40);
            this.dataGridView_view.Name = "dataGridView_view";
            this.dataGridView_view.RowHeadersVisible = false;
            this.dataGridView_view.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_view.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_view.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView_view.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_view.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_view.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.dataGridView_view.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_view.RowTemplate.Height = 40;
            this.dataGridView_view.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_view.Size = new System.Drawing.Size(324, 264);
            this.dataGridView_view.TabIndex = 1;
            // 
            // dataGridView_table
            // 
            this.dataGridView_table.AllowUserToAddRows = false;
            this.dataGridView_table.AllowUserToDeleteRows = false;
            this.dataGridView_table.AllowUserToResizeColumns = false;
            this.dataGridView_table.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_table.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_table.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_table.ColumnHeadersHeight = 40;
            this.dataGridView_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_table.EnableHeadersVisualStyles = false;
            this.dataGridView_table.Location = new System.Drawing.Point(25, 40);
            this.dataGridView_table.Name = "dataGridView_table";
            this.dataGridView_table.RowHeadersVisible = false;
            this.dataGridView_table.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_table.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_table.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView_table.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_table.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_table.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.dataGridView_table.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_table.RowTemplate.Height = 40;
            this.dataGridView_table.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_table.Size = new System.Drawing.Size(324, 264);
            this.dataGridView_table.TabIndex = 0;
            this.dataGridView_table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_table_CellContentClick);
            // 
            // btn_map
            // 
            this.btn_map.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_map.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_map.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btn_map.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_map.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_map.ForeColor = System.Drawing.Color.White;
            this.btn_map.Location = new System.Drawing.Point(516, 453);
            this.btn_map.Name = "btn_map";
            this.btn_map.Size = new System.Drawing.Size(80, 34);
            this.btn_map.TabIndex = 2;
            this.btn_map.Text = "Map";
            this.btn_map.UseVisualStyleBackColor = false;
            this.btn_map.Click += new System.EventHandler(this.btn_map_Click);
            // 
            // writeclass_progressBar
            // 
            this.writeclass_progressBar.Enabled = false;
            this.writeclass_progressBar.Location = new System.Drawing.Point(12, 505);
            this.writeclass_progressBar.MarqueeAnimationSpeed = 10;
            this.writeclass_progressBar.Name = "writeclass_progressBar";
            this.writeclass_progressBar.Size = new System.Drawing.Size(1072, 23);
            this.writeclass_progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.writeclass_progressBar.TabIndex = 23;
            this.writeclass_progressBar.Visible = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 503);
            this.Controls.Add(this.writeclass_progressBar);
            this.Controls.Add(this.btn_map);
            this.Controls.Add(this.groupBox_databaseobjects);
            this.Controls.Add(this.groupBox_choosefolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainView";
            this.Text = "Orm Tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_choosefolder.ResumeLayout(false);
            this.groupBox_databaseobjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_storedprocedures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_choosefolder;
        private System.Windows.Forms.Button choosefolder_btn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_csprojectfolder;
        private System.Windows.Forms.GroupBox groupBox_databaseobjects;
        private System.Windows.Forms.DataGridView dataGridView_storedprocedures;
        private System.Windows.Forms.DataGridView dataGridView_view;
        private System.Windows.Forms.DataGridView dataGridView_table;
        private System.Windows.Forms.Button btn_map;
        private System.Windows.Forms.ProgressBar writeclass_progressBar;
        private System.Windows.Forms.Label label_folderpath;
        private System.Windows.Forms.Button button_create_sp;
        private System.Windows.Forms.Button button_createview;
        private System.Windows.Forms.Button button_createtype;

    }
}

