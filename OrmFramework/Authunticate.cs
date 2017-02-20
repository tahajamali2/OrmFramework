using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace OrmFramework
{
    public partial class Authunticate : Form
    {
        public Authunticate()
        {
            InitializeComponent();
            authuntication_metroComboBox.SelectedIndex = 0;
        }

        private void Authunticate_Load(object sender, EventArgs e)
        {

        }

        private void authuntication_metroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (authuntication_metroComboBox.SelectedIndex == 1)
            {
                username_textBox.Enabled = password_textBox.Enabled  = true;
                return;
            }

            username_textBox.Enabled = password_textBox.Enabled  = false;
        }

        private async void connect_button_Click(object sender, EventArgs e)
        {
            try
            {
                if ((username_textBox.Text.Trim().Equals("") && authuntication_metroComboBox.SelectedIndex == 1) || servername_textBox.Text.Trim().Equals("") || databasename_textBox.Text.Trim().Equals(""))
                    throw new Exception("Invalid Attempt ! Required Additional Information ?");

                string _connString = authuntication_metroComboBox.SelectedIndex == 0 ? "Server=" + servername_textBox.Text + ";Database=" + databasename_textBox.Text + ";Trusted_Connection=True;" : "Server=" + servername_textBox.Text + ";Database=" + databasename_textBox.Text + ";User Id=" + username_textBox.Text + ";Password=" + password_textBox.Text + ";";

                SqlConnection con = new SqlConnection(_connString);
                connection_progressBar.Enabled = connection_progressBar.Visible = true; connect_button.Enabled = false;
                this.Height = 425;
               await Task.Run(() =>con.Open());
               
               connection_progressBar.Enabled = connection_progressBar.Visible = false; connect_button.Enabled = true;
               this.Height = 389;
                con.Close();
                MiscClass.ConnectionString = _connString;
                MiscClass.DBName = databasename_textBox.Text;
                

                this.Hide();
                new MainView().Show();
                
            }

            catch (Exception ex)
            {
                connection_progressBar.Enabled = connection_progressBar.Visible = false; connect_button.Enabled = true;
                this.Height = 389;
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }

}