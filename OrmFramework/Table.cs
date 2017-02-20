using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmFramework
{
    class Table
    {
        public string TableName { get; set; }
        public IList<Fields> Fields { get; set; }
        public IList<Tuple<string,string,int,string>> FieldsForQuery { get; set; }

        public Table()
        {
            Fields = new List<Fields>();
            FieldsForQuery = new List<Tuple<string, string, int,string>>();
        }

        public static List<Table> GetTablesInfo()
        {
            List<Table> returnTable = new List<Table>();
            Table TempTable = new Table();
            SqlConnection con = new SqlConnection(MiscClass.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select name from sys.tables", con);
            SqlDataReader dtreader = cmd.ExecuteReader();
            string tablename;
            while (dtreader.Read())
            {
                
                tablename = dtreader.GetValue(0).ToString();
                
                if(tablename.Substring(tablename.Length-3,3).Equals("_TB"))
                {
                SqlConnection con2 = new SqlConnection(MiscClass.ConnectionString);
                con2.Open();
                SqlCommand cmd2 = new SqlCommand(@"SELECT a.Column_Name,a.Data_Type,CASE WHEN b.COLUMN_NAME IS NULL THEN 0 ELSE 1 END as 'IsPrimaryKey' , a.CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS as a LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE as b
 ON a.Column_Name = b.COLUMN_NAME
 AND b.CONSTRAINT_NAME = (SELECT CONSTRAINT_NAME from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_TYPE = 'PRIMARY KEY' and table_name=@tablename)
 where a.table_name=@tablename", con2);

                cmd2.Parameters.AddWithValue("@tablename", tablename);
                SqlDataReader dtreader2 = cmd2.ExecuteReader();
                TempTable = new Table();
                TempTable.TableName = tablename.Substring(0,tablename.Length-3);
                while(dtreader2.Read()) 
                {
                    TempTable.Fields.Add(new Fields() { FieldName = dtreader2.GetValue(0).ToString(),FieldType = MiscClass.stringtoenum(dtreader2.GetValue(1).ToString())});
                    TempTable.FieldsForQuery.Add(new Tuple<string, string, int, string>(dtreader2.GetValue(0).ToString(), dtreader2.GetValue(1).ToString(), Convert.ToInt32(dtreader2.GetValue(2)), dtreader2.GetValue(3) == DBNull.Value ? "" : dtreader2.GetValue(3).ToString()));
                }
                returnTable.Add(TempTable);
                dtreader2.Close();
                con2.Close();
                
                }
 
            }

            dtreader.Close();
            con.Close();

            return returnTable;
        }

        public void WriteClass()
        {
                        string _classdeclaration =
@"using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace " + MiscClass.Namespace + @".Orm_Tool.Tables
{
     public class " + this.TableName + @"
     {
";

                        foreach (Fields type in Fields)
                        {
                            _classdeclaration +=
@"         public " + type.FieldType.ToString().Replace("Arr","[]") + " " + type.FieldName + @" { get; set; }
";
                        }

                        _classdeclaration +=
@"

         public " + this.TableName + @"() {}
     }
}
";
                        MiscClass.WriteClass(_classdeclaration, MiscClass.ClassType.Table, this.TableName);
        }
    }
}
