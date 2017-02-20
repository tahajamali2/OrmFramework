using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace OrmFramework
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            List<Table> listoftables = Table.GetTablesInfo();
            List<View> listofviews = View.GetViewsInfo();
            List<StoredProcedure> listofsps = StoredProcedure.GetStoredProceduresInfo();

            HelpingClass.PopulateDataGridView(listoftables, dataGridView_table);
            HelpingClass.PopulateDataGridView(listofviews, dataGridView_view);
            HelpingClass.PopulateDataGridView(listofsps, dataGridView_storedprocedures);

            FormatGridView(dataGridView_table);
            FormatGridView(dataGridView_view);
            FormatGridView(dataGridView_storedprocedures);

            btn_map.Enabled = false;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void choosefolder_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog_csprojectfolder.ShowDialog() == DialogResult.OK)
                {
                    string[] files = Directory.GetFiles(folderBrowserDialog_csprojectfolder.SelectedPath).Where(x => x.EndsWith(".csproj")).ToArray();

                    if (files.Length == 0)
                    {
                        throw new Exception("CS Project File Not Found");
                    }

                    if (files.Length > 1)
                    {
                        throw new Exception("Folder Contains Two CS Project File . Only One Allowed");
                    }

                    string Namespace = string.Empty;


                    using (var reader = XmlReader.Create(new StringReader(File.ReadAllText(files.FirstOrDefault()))))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement())
                            {

                                if (reader.ReadToDescendant("RootNamespace"))
                                    {
                                        reader.Read();
                                        Namespace = reader.Value; 
                                        break;
                                    }
                                
                            }
                        }
                    }


                    if (Namespace.Equals(""))
                    {
                        throw new Exception("CS Project Not Have Namespace Tag");
                    }

                    MiscClass.ProjectPath = folderBrowserDialog_csprojectfolder.SelectedPath;
                    MiscClass.ProjectFileName = files.FirstOrDefault();
                    MiscClass.Namespace = Namespace;

                    label_folderpath.Text = folderBrowserDialog_csprojectfolder.SelectedPath;
                    btn_map.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGridView(DataGridView datagridview)
        {
            if (datagridview.Columns.Count > 1)
            {
                datagridview.Columns[1].Visible = false;
            }

            DataGridViewCheckBoxColumn myCheckedColumn = new DataGridViewCheckBoxColumn()
            {
                Name = "",
                FalseValue = false,
                TrueValue = true,
                Visible = true
            };


            datagridview.Columns.Add(myCheckedColumn);

            DatagridViewCheckBoxHeaderCell datagridViewCheckBoxHeaderCell = new DatagridViewCheckBoxHeaderCell();

            if (datagridview.Name.Equals("dataGridView_table"))
            {
                
                datagridview.Columns[2].Visible = false;
                datagridViewCheckBoxHeaderCell.OnCheckBoxClicked += new CheckBoxClickedHandler(fordataGridView_table_OnCheckBoxClicked);
                datagridview.Columns[3].HeaderCell = datagridViewCheckBoxHeaderCell;

                datagridview.Columns[3].Width = 50;

                datagridview.Columns[0].HeaderText = "Table's";
            }

            else if (datagridview.Name.Equals("dataGridView_view"))
            {
                datagridViewCheckBoxHeaderCell.OnCheckBoxClicked += new CheckBoxClickedHandler(fordataGridView_view_OnCheckBoxClicked);
                datagridview.Columns[2].HeaderCell = datagridViewCheckBoxHeaderCell;

                datagridview.Columns[2].Width = 50;
                datagridview.Columns[0].HeaderText = "View's";
            }

            else
            {
                datagridViewCheckBoxHeaderCell.OnCheckBoxClicked += new CheckBoxClickedHandler(fordataGridView_sp_OnCheckBoxClicked);
                datagridview.Columns[1].HeaderCell = datagridViewCheckBoxHeaderCell;

                datagridview.Columns[1].Width = 50;
                datagridview.Columns[0].HeaderText = "Procedure's";
            }

            datagridview.Columns[0].Width = 256;
            
        }


        public void fordataGridView_table_OnCheckBoxClicked(bool state)
        {
            dataGridView_table.RefreshEdit();

            foreach (DataGridViewRow row in this.dataGridView_table.Rows)
            {

                row.Cells[0].Value = state;
            }
            dataGridView_table.RefreshEdit();

            if (state == true)
            {
                button_create_sp.Enabled = button_createtype.Enabled = button_createview.Enabled = true;
            }

            else
            {
                button_create_sp.Enabled = button_createtype.Enabled = button_createview.Enabled = false;
            }
        }

        public void fordataGridView_view_OnCheckBoxClicked(bool state)
        {
            dataGridView_view.RefreshEdit();

            foreach (DataGridViewRow row in this.dataGridView_view.Rows)
            {

                row.Cells[0].Value = state;
            }
            dataGridView_view.RefreshEdit();
        }


        public void fordataGridView_sp_OnCheckBoxClicked(bool state)
        {
            dataGridView_storedprocedures.RefreshEdit();

            foreach (DataGridViewRow row in this.dataGridView_storedprocedures.Rows)
            {

                row.Cells[0].Value = state;
            }
            dataGridView_storedprocedures.RefreshEdit();
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void btn_map_Click(object sender, EventArgs e)
        {
            writeclass_progressBar.Enabled = writeclass_progressBar.Visible = true;
            this.Height = 574;
            btn_map.Enabled = false;
            choosefolder_btn.Enabled = false;
            await Task.Run(() => {

                foreach (DataGridViewRow row in dataGridView_table.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value == true)
                        {
                            (row.DataBoundItem as Table).WriteClass();
                            TableList.GetTableList((row.DataBoundItem as Table)).WriteClass();
                        }
                    }
                }


                foreach (DataGridViewRow row in dataGridView_view.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value == true)
                        {
                            (row.DataBoundItem as View).WriteClass();
                        }
                    }
                }

                foreach (DataGridViewRow row in dataGridView_storedprocedures.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value == true)
                        {
                            (row.DataBoundItem as StoredProcedure).WriteClass();
                        }
                    }
                }
            
            });
            btn_map.Enabled = true;
            choosefolder_btn.Enabled = true;
            this.Height = 542;
            writeclass_progressBar.Enabled = writeclass_progressBar.Visible = false;

            MessageBox.Show("Your Selected Database Objects Mapped Successfully !", "Mapped Successfully", MessageBoxButtons.OK);


        }

        private void dataGridView_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dataGridView_table.EndEdit();
                foreach (DataGridViewRow row in this.dataGridView_table.Rows)
                {

                    if (Convert.ToBoolean(row.Cells[e.ColumnIndex].Value) == true)
                    {
                        button_create_sp.Enabled = button_createtype.Enabled = button_createview.Enabled = true;
                        break;
                    }

                    else
                    {
                        button_create_sp.Enabled = button_createtype.Enabled = button_createview.Enabled = false;
                    }
                }
            }
        }

        private void button_createtype_Click(object sender, EventArgs e)
        {
            string _query = string.Empty;
            int iterator = 0;
            foreach (DataGridViewRow row in dataGridView_table.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if ((bool)row.Cells[0].Value == true)
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection(MiscClass.ConnectionString);
                            con.Open();
                            _query = @" IF EXISTS (SELECT * FROM sys.objects where type='TT' and  name like '%" + (row.DataBoundItem as Table).TableName + @"_Type%') DROP TYPE " + (row.DataBoundItem as Table).TableName + @"_Type 
 Create Type " + (row.DataBoundItem as Table).TableName + @"_Type as Table(";
                            iterator = 0;
                            foreach (Tuple<string, string, int, string> data in (row.DataBoundItem as Table).FieldsForQuery)
                            {
                                _query += @"[" + data.Item1 + "]" + " " + data.Item2 + (data.Item4 == "" || data.Item2.Equals("text") ? "" : "(" + (data.Item4.Equals("-1") ? "max" : data.Item4) + ")");
                                iterator++;
                                if ((row.DataBoundItem as Table).FieldsForQuery.Count != iterator)
                                {
                                    _query += @",";
                                }
                            }
                            _query += @")";
                            SqlCommand cmd = new SqlCommand(_query, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                }
            }

            MessageBox.Show("Type Created Successfully For Selected Tables");
        }

        private void button_createview_Click(object sender, EventArgs e)
        {
            string _query = string.Empty;

            foreach (DataGridViewRow row in dataGridView_table.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if ((bool)row.Cells[0].Value == true)
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection(MiscClass.ConnectionString);
                            con.Open();
                            _query = @"DECLARE @SQL as varchar(4000)
SET @SQL = 'CREATE VIEW " + (row.DataBoundItem as Table).TableName + @"_VW as SELECT * FROM " + (row.DataBoundItem as Table).TableName + @"_TB' 
 IF NOT EXISTS ( SELECT * FROM sys.objects where type='V' and  name = '" + (row.DataBoundItem as Table).TableName + @"_VW')
 BEGIN
    EXEC(@SQL);
 END";
                            SqlCommand cmd = new SqlCommand(_query, con);
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }

            MessageBox.Show("View(s) Created Successfully For Selected Tables");
            HelpingClass.PopulateDataGridView(View.GetViewsInfo(), dataGridView_view);
        }

        private void button_create_sp_Click(object sender, EventArgs e)
        {
            string _query = string.Empty;

            foreach (DataGridViewRow row in dataGridView_table.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if ((bool)row.Cells[0].Value == true)
                    {
                        

                        try
                        {
                            // ADD Stored Procedures Start

                            SqlConnection con = new SqlConnection(MiscClass.ConnectionString);
                            con.Open();
                            _query = @"DECLARE @SQL as varchar(4000)

SET @SQL = ' PROCEDURE Add" + (row.DataBoundItem as Table).TableName + @"_SP
@" + (row.DataBoundItem as Table).TableName.Substring(0,3) + @"_TVP " + (row.DataBoundItem as Table).TableName + @"_Type READONLY
AS";

                            _query += @" INSERT INTO " + (row.DataBoundItem as Table).TableName + @"_TB(";
                            //First Loop
                            for (int i = 0; i < (row.DataBoundItem as Table).FieldsForQuery.Count; i++)
                            {
                                _query += (row.DataBoundItem as Table).FieldsForQuery[i].Item3 == 1 ? "" : "[" + (row.DataBoundItem as Table).FieldsForQuery[i].Item1 + "]";

                                if (((row.DataBoundItem as Table).FieldsForQuery.Count - i) != 1 && (row.DataBoundItem as Table).FieldsForQuery[i].Item3 != 1)
                                {
                                    _query += ",";
                                }
                            }
                                _query += @")
 SELECT ";
                                for (int i = 0; i < (row.DataBoundItem as Table).FieldsForQuery.Count; i++)
                                {
                                    _query += (row.DataBoundItem as Table).FieldsForQuery[i].Item3 == 1 ? "" : "[" + (row.DataBoundItem as Table).FieldsForQuery[i].Item1 + "]";

                                    if (((row.DataBoundItem as Table).FieldsForQuery.Count - i) != 1 && (row.DataBoundItem as Table).FieldsForQuery[i].Item3 != 1)
                                    {
                                        _query += ",";
                                    }
                                }
   
                            _query += @" FROM @" + (row.DataBoundItem as Table).TableName.Substring(0, 3) + @"_TVP;'";

_query += @" IF NOT EXISTS (SELECT * FROM sys.objects where type='P' and name ='Add" + (row.DataBoundItem as Table).TableName + @"_SP')
BEGIN
    SET @SQL =  'CREATE '+@SQL
END;

ELSE
BEGIN
    SET @SQL =  'ALTER '+@SQL
END;

exec(@SQL);";

                            SqlCommand cmd = new SqlCommand(_query, con);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            // ADD Stored Procedures End

                            // Update Stored Procedures Start

                            con = new SqlConnection(MiscClass.ConnectionString);
                            con.Open();

                            _query = @"DECLARE @SQL as varchar(4000)

SET @SQL = ' PROCEDURE Update" + (row.DataBoundItem as Table).TableName + @"_SP
@" + (row.DataBoundItem as Table).TableName.Substring(0, 3) + @"_TVP " + (row.DataBoundItem as Table).TableName + @"_Type READONLY
AS
Update " + (row.DataBoundItem as Table).TableName + @"_TB SET";

                            for (int i = 0; i < (row.DataBoundItem as Table).FieldsForQuery.Count; i++)
                            {
                                _query += (row.DataBoundItem as Table).FieldsForQuery[i].Item3 == 1 ? "" : "[" + (row.DataBoundItem as Table).FieldsForQuery[i].Item1 + "] = i.[" + (row.DataBoundItem as Table).FieldsForQuery[i].Item1 + "]";

                                if (((row.DataBoundItem as Table).FieldsForQuery.Count - i) != 1 && (row.DataBoundItem as Table).FieldsForQuery[i].Item3 != 1)
                                {
                                    _query += @",
";
                                }
                            }

                            _query += @"
FROM (SELECT * FROM @" + (row.DataBoundItem as Table).TableName.Substring(0, 3) + @"_TVP) i
WHERE " + (row.DataBoundItem as Table).TableName + "_TB." + (row.DataBoundItem as Table).FieldsForQuery.Single(a => a.Item3 == 1).Item1 + " = i." + (row.DataBoundItem as Table).FieldsForQuery.Single(a => a.Item3 == 1).Item1+";'";

_query += @" IF NOT EXISTS (SELECT * FROM sys.objects where type='P' and name ='Update" + (row.DataBoundItem as Table).TableName + @"_SP')
BEGIN
    SET @SQL =  'CREATE '+@SQL
END;

ELSE
BEGIN
    SET @SQL =  'ALTER '+@SQL
END;

exec(@SQL);";

                            cmd = new SqlCommand(_query, con);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            // Update Stored Procedures End

                            // Delete Stored Procedures Start

                            con = new SqlConnection(MiscClass.ConnectionString);
                            con.Open();

                            _query = @"DECLARE @SQL as varchar(4000)

SET @SQL = ' PROCEDURE Delete" + (row.DataBoundItem as Table).TableName + @"_SP
@" + (row.DataBoundItem as Table).TableName.Substring(0, 3) + @"_TVP " + (row.DataBoundItem as Table).TableName + @"_Type READONLY
AS
DELETE FROM " + (row.DataBoundItem as Table).TableName + @"_TB WHERE " + (row.DataBoundItem as Table).FieldsForQuery.Single(a => a.Item3 == 1).Item1 + @" IN (SELECT " + (row.DataBoundItem as Table).FieldsForQuery.Single(a => a.Item3 == 1).Item1 + @" FROM @" + (row.DataBoundItem as Table).TableName.Substring(0, 3) + "_TVP);'";

_query += @" IF NOT EXISTS (SELECT * FROM sys.objects where type='P' and name ='Delete" + (row.DataBoundItem as Table).TableName + @"_SP')
BEGIN
    SET @SQL =  'CREATE '+@SQL
END;

ELSE
BEGIN
    SET @SQL =  'ALTER '+@SQL
END;

exec(@SQL);";
                            cmd = new SqlCommand(_query, con);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Stored Procedure(s) Created Successfully For Selected Tables");
                            HelpingClass.PopulateDataGridView(StoredProcedure.GetStoredProceduresInfo(), dataGridView_storedprocedures);

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message+" "+ex.StackTrace);
                        }

                    }

                }

            }
        }
    }
}
