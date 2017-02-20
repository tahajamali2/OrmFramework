using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmFramework
{
    class View
    {
        public string ViewName { get; set; }
        public IList<Fields> Fields { get; set; }

        public View()
        {
            Fields = new List<Fields>();
        }

        public static List<View> GetViewsInfo()
        {
            List<View> returnView = new List<View>();
            View TempView = new View();
            SqlConnection con = new SqlConnection(MiscClass.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select name from sys.views", con);
            SqlDataReader dtreader = cmd.ExecuteReader();
            string viewname;
            while (dtreader.Read())
            {

                viewname = dtreader.GetValue(0).ToString();

                if (viewname.Substring(viewname.Length - 3, 3).Equals("_VW"))
                {
                    SqlConnection con2 = new SqlConnection(MiscClass.ConnectionString);
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand("SELECT Column_Name , Data_Type FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = @viewname", con2);
                    cmd2.Parameters.AddWithValue("@viewname", viewname);
                    SqlDataReader dtreader2 = cmd2.ExecuteReader();
                    TempView = new View();
                    TempView.ViewName = viewname.Substring(0, viewname.Length - 3);
                    while (dtreader2.Read())
                    {
                        TempView.Fields.Add(new Fields() { FieldName = dtreader2.GetValue(0).ToString(), FieldType = MiscClass.stringtoenum(dtreader2.GetValue(1).ToString()) });
                    }
                    returnView.Add(TempView);
                    dtreader2.Close();
                    con2.Close();

                }

            }

            dtreader.Close();
            con.Close();

            return returnView;
        }

        public void WriteClass()
        {
            string _classdeclaration =
@"using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace " + MiscClass.Namespace + @".Orm_Tool.Views
{
     public class " + this.ViewName + @"
     {
         private static string _query = ""SELECT * FROM "+this.ViewName+ @"_VW"";
         private static List<Tuple<string,object>> paramaters = new List<Tuple<string,object>>();

";

            foreach (Fields type in Fields)
            {
                _classdeclaration +=
@"         public " + type.FieldType.ToString().Replace("Arr", "[]") + " " + type.FieldName + @" { get; set; }
";
            }

            _classdeclaration +=
@"

         public " + this.ViewName + @"() {}

         public static void As(string keyword) 
         {
            _query += "" AS "" + keyword;
         }

         public static void Where() 
         {
            _query += "" WHERE "";
         }

         public static void Expression(string expression,List<Tuple<string,object>> param) 
         {
            _query += expression;
            paramaters.AddRange(param);
         }

         public static void And() 
         {
            _query += "" AND "";
         }

         public static void Or() 
         {
            _query += "" OR "";
         }

         public static void Orderby(string[] columns) 
         {
            _query += "" ORDER BY "" + string.Join("","", columns);
         }

         public static void Paging(int TotalrecordPerpage , int PageNumber) 
         {
            _query += "" Offset "" + ((TotalrecordPerpage * PageNumber) - TotalrecordPerpage).ToString() + "" ROWS FETCH NEXT ""+TotalrecordPerpage+"" ROWS ONLY "";
         }

         public static IList<" + this.ViewName + @"> Execute() 
         {
              SqlConnection Connection = new SqlConnection(" + MiscClass.Namespace + @".Orm_Tool.DBInfo._GetConnectionString());
              List<" + this.ViewName + @"> return" + this.ViewName + @" = new List<" + this.ViewName + @">();

                try
                {

                     Connection.Open();
                     SqlCommand Command = new SqlCommand(_query, Connection);
                     foreach (Tuple<string, object> data in paramaters)
                     {
                         Command.Parameters.AddWithValue(data.Item1, data.Item2);
                     }

                     SqlDataReader Datareader = Command.ExecuteReader();
                 
                     while (Datareader.Read())
                     {
                         return" + this.ViewName + @".Add(new " + this.ViewName + @"()
                         {";
            int iterator = 0;
            foreach (Fields type in Fields)
            {
                if (!type.FieldType.ToString().Equals("String"))
                {
_classdeclaration +=
@"
                               " + type.FieldName + @" = Datareader.Get" + type.FieldType.ToString().Replace("Arr","s")+"("+iterator+")";
                }

                else
                {
_classdeclaration +=
@"
                               " + type.FieldName + " = Datareader.GetValue(" + iterator + @") == DBNull.Value?"""":Datareader.Get" + type.FieldType.ToString()+@"("+iterator+@")";
                }

                iterator++;
                if(iterator!=Fields.Count)
                {
                    _classdeclaration += @",
";
                }
            }

_classdeclaration+=
@"
                         });
                     }
                     Datareader.Close();
                     Connection.Close();

                     paramaters.Clear();
                     _query = ""SELECT * FROM " + this.ViewName + @"_VW"";
                      

                }

                catch (Exception ex)
                {
                    Connection.Close();

                    paramaters.Clear();
                    _query = ""SELECT * FROM "+this.ViewName+@"_VW"";

                    throw new Exception(ex.Message);
                }

                    return return" + this.ViewName + @".AsReadOnly();
         }
     }
}
";
            MiscClass.WriteClass(_classdeclaration, MiscClass.ClassType.View, this.ViewName);
        }
    }
}
