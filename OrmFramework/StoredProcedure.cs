using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmFramework
{
    class StoredProcedure
    {
        public string StoredProcedureName { get; set; }
        public List<Tuple<string,string>> Fields { get; set; }

        public StoredProcedure()
        {
            Fields = new List<Tuple<string, string>>();
        }

        public static List<StoredProcedure> GetStoredProceduresInfo()
        {
            List<StoredProcedure> returnSPs = new List<StoredProcedure>();
            StoredProcedure TempSP = new StoredProcedure();
            SqlConnection con = new SqlConnection(MiscClass.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select name from sys.procedures", con);
            SqlDataReader dtreader = cmd.ExecuteReader();
            string spname;
            while (dtreader.Read())
            {

                spname = dtreader.GetValue(0).ToString();

                if (spname.Substring(spname.Length - 3, 3).Equals("_SP"))
                {
                    SqlConnection con2 = new SqlConnection(MiscClass.ConnectionString);
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand("select  'Parameter_name' = name,  'Type'   = type_name(user_type_id) from sys.parameters where object_id = object_id(@spname)", con2);
                    cmd2.Parameters.AddWithValue("@spname", spname);
                    SqlDataReader dtreader2 = cmd2.ExecuteReader();
                    TempSP = new StoredProcedure();
                    TempSP.StoredProcedureName = spname.Substring(0, spname.Length - 3);
                    while (dtreader2.Read())
                    {
                        TempSP.Fields.Add(new Tuple<string, string>(dtreader2.GetValue(0).ToString(), MiscClass.sqltypetonettype(dtreader2.GetValue(1).ToString())));
                    }
                    returnSPs.Add(TempSP);
                    dtreader2.Close();
                    con2.Close();

                }

            }

            dtreader.Close();
            con.Close();

            return returnSPs;
        }

        public void WriteClass()
        {
            string _methoddeclaration =
@"
         public static object "+this.StoredProcedureName+" (";

            for (int i=0;i<Fields.Count;i++)
            {
                _methoddeclaration += Fields[i].Item2.Contains("_Type") ? MiscClass.Namespace + ".Orm_Tool.Tables.List" + Fields[i].Item2.Replace("_Type","")+" "+Fields[i].Item1.Substring(1) : Fields[i].Item2 + " " + Fields[i].Item1.Substring(1);
                if (i != (Fields.Count - 1))
                {
                    _methoddeclaration += ",";
                }
            }

            _methoddeclaration +=
@")
         {
             try
             {
                 SqlConnection Connection = new SqlConnection(" + MiscClass.Namespace + @".Orm_Tool.DBInfo._GetConnectionString());
                 Connection.Open();
                 SqlCommand Command = new SqlCommand(""" +this.StoredProcedureName+ @"_SP"", Connection);
                 Command.CommandType = System.Data.CommandType.StoredProcedure;        
";
            for (int i = 0; i < Fields.Count; i++)
            {
                if (Fields[i].Item2.Contains("_Type"))
                {
                    _methoddeclaration += 
@"
                     SqlParameter Parameter" + i.ToString() + @" = Command.Parameters.AddWithValue(""" + Fields[i].Item1 + @""", " + Fields[i].Item1.Substring(1) + @");
                     Parameter" + i.ToString() + @".SqlDbType = System.Data.SqlDbType.Structured;";
                }

                else
                {
                    _methoddeclaration +=
@"
                     Command.Parameters.AddWithValue(""" + Fields[i].Item1 + @"""," + Fields[i].Item1 + @")";
                }
            }

            _methoddeclaration +=
@"
                     Command.ExecuteNonQuery();
                     Connection.Close();

                     return ""Operation Successfull !"";

             }

             catch(Exception ex) 
             {
                 return ex.Message;
             }
         }

";

            MiscClass.WriteClass(_methoddeclaration, MiscClass.ClassType.StoreProcedure);
        }
    }
}
