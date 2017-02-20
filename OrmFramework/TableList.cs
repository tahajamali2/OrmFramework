using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmFramework
{
    class TableList
    {
        public string TableName { get; set; }
        public string ListName { get; set; }

        public IList<Tuple<string, string,string,string>> Fields { get; set; } 

        public TableList()
        {
            Fields = new List<Tuple<string, string, string, string>>();
        }

        public static TableList GetTableList(Table table)
        {
            SqlConnection con = new SqlConnection(MiscClass.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Column_Name , Data_Type , CHARACTER_MAXIMUM_LENGTH as Lenght FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = @tablename", con);
            cmd.Parameters.AddWithValue("@tablename", table.TableName+"_TB");
            SqlDataReader dtreader = cmd.ExecuteReader();
            TableList TempTableList = new TableList();
            TempTableList.ListName = "List" + table.TableName;
            TempTableList.TableName = table.TableName;
            while (dtreader.Read())
            {
                TempTableList.Fields.Add(new Tuple<string, string, string, string>(dtreader.GetValue(0).ToString(), MiscClass.sqltypetonettype(dtreader.GetValue(1).ToString()).Replace("[]", "s"), dtreader.GetValue(2) == DBNull.Value ? "" : dtreader.GetValue(2).ToString(), MiscClass.dbtypetoenumeration(dtreader.GetValue(1).ToString())));
            }
            dtreader.Close();
            con.Close();

            return TempTableList;
        }

        public void WriteClass()
        {
            int iterator = 0;
            string _classdeclaration =
@"using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data;
using Microsoft.SqlServer.Server;

namespace " + MiscClass.Namespace + @".Orm_Tool.Tables
{
     public class " + this.ListName + @":List<" + this.TableName + @">,IEnumerable<SqlDataRecord>
     {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

            SqlDataRecord ret = new SqlDataRecord(";
            foreach (Tuple<string, string, string, string> field in this.Fields)
            {
                _classdeclaration +=
@"
               new SqlMetaData(""" + field.Item1 + @""",SqlDbType." + field.Item4 + "" + ((field.Item4.Equals("Text") || field.Item3.Equals(""))?"":","+field.Item3) + @")";
                iterator++;
                if (iterator != this.Fields.Count)
                {
                    _classdeclaration += ",";
                }
            }

            _classdeclaration +=
@"
               );

            foreach (" + this.TableName + @" data in this)
            {";

            iterator = 0;
            foreach (Tuple<string, string, string, string> field in Fields)
            {
                _classdeclaration += 
@"
                  if(CheckNullOrEmpty(data." + field.Item1 + @"))
                  {
                     ret.SetDBNull(" + iterator.ToString() + @");
                  }

                  else 
                  {
                     ret.Set" + field.Item2 + @"(" + iterator.ToString() + @",data." + field.Item1 + @");
                  }

";

                iterator++;
            }

            _classdeclaration +=
@"                 yield return ret;
            }
        }

        private static bool CheckNullOrEmpty<T>(T value)
        {
            if (typeof(T) == typeof(string))
                return string.IsNullOrEmpty(value as string);

            return value == null || value.Equals(default(T));
        }

     }
}";

            MiscClass.WriteClass(_classdeclaration, MiscClass.ClassType.TableList, this.ListName);
        }
    }
}
