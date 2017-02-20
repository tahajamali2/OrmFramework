namespace OrmFramework
{
    partial class Authunticate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authunticate));
            this.servername_textBox = new System.Windows.Forms.TextBox();
            this.authuntication_metroComboBox = new MetroFramework.Controls.MetroComboBox();
            this.servername_label = new System.Windows.Forms.Label();
            this.connect_button = new System.Windows.Forms.Button();
            this.username_label = new System.Windows.Forms.Label();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.authuntication_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.databasename_label = new System.Windows.Forms.Label();
            this.databasename_textBox = new System.Windows.Forms.TextBox();
            this.divider_panel = new System.Windows.Forms.Panel();
            this.cover_pictureBox = new System.Windows.Forms.PictureBox();
            this.connection_progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.cover_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // servername_textBox
            // 
            this.servername_textBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.servername_textBox.Location = new System.Drawing.Point(169, 71);
            this.servername_textBox.Multiline = true;
            this.servername_textBox.Name = "servername_textBox";
            this.servername_textBox.Size = new System.Drawing.Size(258, 28);
            this.servername_textBox.TabIndex = 3;
            // 
            // authuntication_metroComboBox
            // 
            this.authuntication_metroComboBox.FormattingEnabled = true;
            this.authuntication_metroComboBox.ItemHeight = 23;
            this.authuntication_metroComboBox.Items.AddRange(new object[] {
            "Windows Authuntication",
            "Sql Server Authuntication"});
            this.authuntication_metroComboBox.Location = new System.Drawing.Point(169, 113);
            this.authuntication_metroComboBox.Name = "authuntication_metroComboBox";
            this.authuntication_metroComboBox.Size = new System.Drawing.Size(258, 29);
            this.authuntication_metroComboBox.TabIndex = 4;
            this.authuntication_metroComboBox.UseSelectable = true;
            this.authuntication_metroComboBox.SelectedIndexChanged += new System.EventHandler(this.authuntication_metroComboBox_SelectedIndexChanged);
            // 
            // servername_label
            // 
            this.servername_label.AutoSize = true;
            this.servername_label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.servername_label.Location = new System.Drawing.Point(25, 75);
            this.servername_label.Name = "servername_label";
            this.servername_label.Size = new System.Drawing.Size(88, 17);
            this.servername_label.TabIndex = 6;
            this.servername_label.Text = "Server name :";
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(353, 322);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(75, 23);
            this.connect_button.TabIndex = 11;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_label.Location = new System.Drawing.Point(63, 157);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(78, 17);
            this.username_label.TabIndex = 14;
            this.username_label.Text = "User name :";
            // 
            // username_textBox
            // 
            this.username_textBox.Enabled = false;
            this.username_textBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_textBox.Location = new System.Drawing.Point(200, 156);
            this.username_textBox.Multiline = true;
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(227, 28);
            this.username_textBox.TabIndex = 13;
            // 
            // authuntication_label
            // 
            this.authuntication_label.AutoSize = true;
            this.authuntication_label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authuntication_label.Location = new System.Drawing.Point(25, 116);
            this.authuntication_label.Name = "authuntication_label";
            this.authuntication_label.Size = new System.Drawing.Size(97, 17);
            this.authuntication_label.TabIndex = 15;
            this.authuntication_label.Text = "Authuntication :";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_label.Location = new System.Drawing.Point(63, 199);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(71, 17);
            this.password_label.TabIndex = 17;
            this.password_label.Text = "Password :";
            // 
            // password_textBox
            // 
            this.password_textBox.Enabled = false;
            this.password_textBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_textBox.Location = new System.Drawing.Point(200, 198);
            this.password_textBox.Multiline = true;
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.PasswordChar = '*';
            this.password_textBox.Size = new System.Drawing.Size(227, 28);
            this.password_textBox.TabIndex = 16;
            // 
            // databasename_label
            // 
            this.databasename_label.AutoSize = true;
            this.databasename_label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databasename_label.Location = new System.Drawing.Point(25, 246);
            this.databasename_label.Name = "databasename_label";
            this.databasename_label.Size = new System.Drawing.Size(106, 17);
            this.databasename_label.TabIndex = 19;
            this.databasename_label.Text = "Database name :";
            // 
            // databasename_textBox
            // 
            this.databasename_textBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databasename_textBox.Location = new System.Drawing.Point(169, 241);
            this.databasename_textBox.Multiline = true;
            this.databasename_textBox.Name = "databasename_textBox";
            this.databasename_textBox.Size = new System.Drawing.Size(258, 28);
            this.databasename_textBox.TabIndex = 18;
            // 
            // divider_panel
            // 
            this.divider_panel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.divider_panel.Location = new System.Drawing.Point(28, 302);
            this.divider_panel.Name = "divider_panel";
            this.divider_panel.Size = new System.Drawing.Size(399, 3);
            this.divider_panel.TabIndex = 20;
            // 
            // cover_pictureBox
            // 
            this.cover_pictureBox.Image = global::OrmFramework.Properties.Resources.authcover;
            this.cover_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.cover_pictureBox.Name = "cover_pictureBox";
            this.cover_pictureBox.Size = new System.Drawing.Size(454, 65);
            this.cover_pictureBox.TabIndex = 21;
            this.cover_pictureBox.TabStop = false;
            // 
            // connection_progressBar
            // 
            this.connection_progressBar.Enabled = false;
            this.connection_progressBar.Location = new System.Drawing.Point(28, 356);
            this.connection_progressBar.MarqueeAnimationSpeed = 10;
            this.connection_progressBar.Name = "connection_progressBar";
            this.connection_progressBar.Size = new System.Drawing.Size(399, 23);
            this.connection_progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.connection_progressBar.TabIndex = 22;
            this.connection_progressBar.Visible = false;
            // 
            // Authunticate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 350);
            this.Controls.Add(this.connection_progressBar);
            this.Controls.Add(this.cover_pictureBox);
            this.Controls.Add(this.divider_panel);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.databasename_label);
            this.Controls.Add(this.databasename_textBox);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.authuntication_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.servername_label);
            this.Controls.Add(this.authuntication_metroComboBox);
            this.Controls.Add(this.servername_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Authunticate";
            this.Text = "Connect to Server ";
            this.Load += new System.EventHandler(this.Authunticate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cover_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox servername_textBox;
        private MetroFramework.Controls.MetroComboBox authuntication_metroComboBox;
        private System.Windows.Forms.Label servername_label;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.Label authuntication_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Label databasename_label;
        private System.Windows.Forms.TextBox databasename_textBox;
        private System.Windows.Forms.Panel divider_panel;
        private System.Windows.Forms.PictureBox cover_pictureBox;
        private System.Windows.Forms.ProgressBar connection_progressBar;
    }
}