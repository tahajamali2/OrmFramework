using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OrmFramework
{
    static class MiscClass
    {
        public enum ClassType { Table,View,StoreProcedure,TableList}
        private static string _ormfoldername = "Orm Tool";
        private static string _tablefoldername = "Tables";
        private static string _viewfoldername = "Views";
        private static string _procedurefoldername = "Stored Procedures";
        private static string _procedurefilename = "MyProc.cs";
        private static string _dbinfofilename = "DBInfo.cs";
        public static string ConnectionString { get; set; }
        public static string DBName { get; set; }

        public static string Namespace { get; set; }
        public static string ProjectFileName { get; set; }

        public static string ProjectPath { get; set; }
        public static Fields._FieldType stringtoenum(string datatype)
        {
            Fields._FieldType returnValue = Fields._FieldType.Boolean;

            if (datatype.Equals("bigint"))
            {
                returnValue = Fields._FieldType.Int64;
            }

            else if (datatype.Equals("binary") || datatype.Equals("varbinary(max)") || datatype.Equals("image") || datatype.Equals("rowversion") || datatype.Equals("timestamp") || datatype.Equals("varbinary"))
            {
                returnValue = Fields._FieldType.ByteArr;
            }

            else if (datatype.Equals("bit"))
            {
                returnValue = Fields._FieldType.Boolean;
            }

            else if (datatype.Equals("char") || datatype.Equals("nchar") || datatype.Equals("ntext") || datatype.Equals("nvarchar") || datatype.Equals("text") || datatype.Equals("varchar"))
            {
                returnValue = Fields._FieldType.String;
            }

            else if (datatype.Equals("date") || datatype.Equals("datetime") || datatype.Equals("datetime2") || datatype.Equals("smalldatetime"))
            {
                returnValue = Fields._FieldType.DateTime;
            }

            else if (datatype.Equals("datetimeoffset"))
            {
                returnValue = Fields._FieldType.DateTimeOffset;
            }

            else if (datatype.Equals("decimal") || datatype.Equals("money") || datatype.Equals("numeric") || datatype.Equals("smallmoney"))
            {
                returnValue = Fields._FieldType.Decimal;
            }

            else if (datatype.Equals("float"))
            {
                returnValue = Fields._FieldType.Double;
            }

            else if (datatype.Equals("int"))
            {
                returnValue = Fields._FieldType.Int32;
            }

            else if (datatype.Equals("real"))
            {
                returnValue = Fields._FieldType.Single;
            }

            else if (datatype.Equals("smallint"))
            {
                returnValue = Fields._FieldType.Int16;
            }

            else if (datatype.Equals("sql_variant"))
            {
                returnValue = Fields._FieldType.Object;
            }

            else if (datatype.Equals("tinyint"))
            {
                returnValue = Fields._FieldType.Byte;
            }

            else if (datatype.Equals("uniqueidentifier"))
            {
                returnValue = Fields._FieldType.Guid;
            }

            else if (datatype.Equals("time"))
            {
                returnValue = Fields._FieldType.TimeSpan;
            }


            return returnValue;
        }

        public static string dbtypetoenumeration(string datatype)
        {
            if (datatype.Equals("bigint"))
            {
                return "BigInt";
            }

            if (datatype.Equals("binary"))
            {
                return "VarBinary";
            }

            if (datatype.Equals("bit"))
            {
                return "Bit";
            }

            if (datatype.Equals("char"))
            {
                return "Char";
            }

            if (datatype.Equals("date"))
            {
                return "Date";
            }

            if (datatype.Equals("datetime"))
            {
                return "DateTime";
            }

            if (datatype.Equals("datetime2"))
            {
                return "DateTime2";
            }

            if (datatype.Equals("datetimeoffset"))
            {
                return "DateTimeOffset";
            }

            if (datatype.Equals("decimal"))
            {
                return "Decimal";
            }

            if (datatype.Equals("float"))
            {
                return "Float";
            }

            if (datatype.Equals("image"))
            {
                return "Binary";
            }

            if (datatype.Equals("int"))
            {
                return "Int";
            }

            if (datatype.Equals("money"))
            {
                return "Money";
            }

            if (datatype.Equals("nchar"))
            {
                return "NChar";
            }

            if (datatype.Equals("ntext"))
            {
                return "NText";
            }

            if (datatype.Equals("numeric"))
            {
                return "Decimal";
            }

            if (datatype.Equals("nvarchar"))
            {
                return "NVarChar";
            }

            if (datatype.Equals("real"))
            {
                return "Real";
            }

            if (datatype.Equals("rowversion"))
            {
                return "Timestamp";
            }

            if (datatype.Equals("smalldatetime"))
            {
                return "DateTime";
            }

            if (datatype.Equals("smallint"))
            {
                return "SmallInt";
            }

            if (datatype.Equals("smallmoney"))
            {
                return "SmallMoney";
            }

            if (datatype.Equals("sql_variant"))
            {
                return "Variant";
            }

            if (datatype.Equals("text"))
            {
                return "Text";
            }

            if (datatype.Equals("time"))
            {
                return "Time";
            }

            if (datatype.Equals("timestamp"))
            {
                return "Timestamp";
            }

            if (datatype.Equals("tinyint"))
            {
                return "TinyInt";
            }

            if (datatype.Equals("uniqueidentifier"))
            {
                return "UniqueIdentifier";
            }

            if (datatype.Equals("varbinary"))
            {
                return "VarBinary";
            }

            if (datatype.Equals("varchar"))
            {
                return "VarChar";
            }

            if (datatype.Equals("xml"))
            {
                return "Xml";
            }

            return "";
        }


        public static string sqltypetonettype(string datatype)
        {
            string returnValue = string.Empty;

            if (datatype.Equals("bigint"))
            {
                returnValue = "Int64";
            }

            else if (datatype.Equals("binary") || datatype.Equals("varbinary(max)") || datatype.Equals("image") || datatype.Equals("rowversion") || datatype.Equals("timestamp") || datatype.Equals("varbinary"))
            {
                returnValue = "Byte[]";
            }

            else if (datatype.Equals("bit"))
            {
                returnValue = "Boolean";
            }

            else if (datatype.Equals("char") || datatype.Equals("nchar") || datatype.Equals("ntext") || datatype.Equals("nvarchar") || datatype.Equals("text") || datatype.Equals("varchar"))
            {
                returnValue = "String";
            }

            else if (datatype.Equals("date") || datatype.Equals("datetime") || datatype.Equals("datetime2") || datatype.Equals("smalldatetime"))
            {
                returnValue = "DateTime";
            }

            else if (datatype.Equals("datetimeoffset"))
            {
                returnValue = "DateTimeOffset";
            }

            else if (datatype.Equals("decimal") || datatype.Equals("money") || datatype.Equals("numeric") || datatype.Equals("smallmoney"))
            {
                returnValue = "Decimal";
            }

            else if (datatype.Equals("float"))
            {
                returnValue = "Double";
            }

            else if (datatype.Equals("int"))
            {
                returnValue = "Int32";
            }

            else if (datatype.Equals("real"))
            {
                returnValue = "Single";
            }

            else if (datatype.Equals("smallint"))
            {
                returnValue = "Int16";
            }

            else if (datatype.Equals("sql_variant"))
            {
                returnValue = "Object";
            }

            else if (datatype.Equals("tinyint"))
            {
                returnValue = "Byte";
            }

            else if (datatype.Equals("uniqueidentifier"))
            {
                returnValue = "Guid";
            }

            else if (datatype.Equals("time"))
            {
                returnValue = "TimeSpan";
            }


            else if (datatype.Contains("_Type"))
            {
                returnValue = datatype;
            }
            


            return returnValue;
        }


        public static void WriteClass(string text, ClassType Type, string Classname = "Only Required For Table And View")
         {
            if (text.Trim().Equals("") || text.Trim().Length < 16)
            {
                throw new Exception("Text Can,t Contain Class Or Method Defination !");
            }

            if (Classname.Equals("Only Required For Table And View") && Type != ClassType.StoreProcedure)
            {
                throw new Exception("Supply Class Name Its Is Required For Table And View !");
            }

            if (Classname.Trim().Equals(""))
            {
                throw new Exception("Class Name Can't Be Empty !");
            }

            Classname = Classname.TrimStart().TrimEnd();
            if (!Directory.Exists(ProjectPath+"\\"+_ormfoldername))
            {
                Directory.CreateDirectory(ProjectPath + "\\" + _ormfoldername);
            }

            if (!Directory.Exists(ProjectPath + "\\" + _ormfoldername + "\\"+_tablefoldername)) 
            {
                Directory.CreateDirectory(ProjectPath + "\\" + _ormfoldername + "\\" + _tablefoldername);
            }

            if (!Directory.Exists(ProjectPath + "\\" + _ormfoldername + "\\" + _viewfoldername))
            {
                Directory.CreateDirectory(ProjectPath + "\\" + _ormfoldername + "\\" + _viewfoldername);
            }

            if (!Directory.Exists(ProjectPath + "\\" + _ormfoldername + "\\" + _procedurefoldername))
            {
                Directory.CreateDirectory(ProjectPath + "\\" + _ormfoldername + "\\" + _procedurefoldername);
            }

            if (Type == ClassType.Table || Type == ClassType.TableList)
            {
                if (!File.Exists(ProjectPath + "\\" + _ormfoldername + "\\" + _tablefoldername + "\\" + Classname + ".cs"))
                {
                    WriteCompileTag(_ormfoldername + "\\" + _tablefoldername + "\\" + Classname + ".cs");
                }

                File.WriteAllText(ProjectPath + "\\" + _ormfoldername + "\\" + _tablefoldername + "\\" + Classname + ".cs",text);
                
            }


            else if (Type == ClassType.View)
            {
                if (!File.Exists(ProjectPath + "\\" + _ormfoldername + "\\" + _viewfoldername + "\\" + Classname + ".cs"))
                {
                    WriteCompileTag(_ormfoldername + "\\" + _viewfoldername + "\\" + Classname + ".cs");
                }

                File.WriteAllText(ProjectPath + "\\" + _ormfoldername + "\\" + _viewfoldername + "\\" + Classname + ".cs", text);
            }

            else
            {
                if (!File.Exists(ProjectPath + "\\" + _ormfoldername + "\\" + _procedurefoldername + "\\" + _procedurefilename))
                {
                    File.WriteAllText(ProjectPath + "\\" + _ormfoldername + "\\" + _procedurefoldername + "\\" + _procedurefilename,
@"using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace " + Namespace+ @".Orm_Tool.SP
{
     public static class "+_procedurefilename.Substring(0,_procedurefilename.Length-3)+@"
     {
     }
}");
                    WriteCompileTag(_ormfoldername + "\\" + _procedurefoldername + "\\" + _procedurefilename);
                }

                string _procfilecontent = File.ReadAllText(ProjectPath + "\\" + _ormfoldername + "\\" + _procedurefoldername + "\\" + _procedurefilename);
                _procfilecontent = _procfilecontent.Remove(_procfilecontent.TrimEnd().LastIndexOf(Environment.NewLine));
                _procfilecontent = _procfilecontent.Remove(_procfilecontent.TrimEnd().LastIndexOf(Environment.NewLine));

                _procfilecontent = _procfilecontent + text +
@"
     }
}
";

                File.WriteAllText(ProjectPath + "\\" + _ormfoldername + "\\" + _procedurefoldername + "\\" + _procedurefilename, _procfilecontent); 

            }

            if (!File.Exists(ProjectPath + "\\" + _ormfoldername + "\\" + _dbinfofilename)) 
            {
                WriteCompileTag(_ormfoldername + "\\" + _dbinfofilename);
            }

            File.WriteAllText(ProjectPath + "\\" + _ormfoldername + "\\" + _dbinfofilename,
@"using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace " + Namespace + @".Orm_Tool
{
     class " + _dbinfofilename.Substring(0, _procedurefilename.Length - 3) + @"
     {
           public static string _GetConnectionString()
           {
             return WebConfigurationManager.ConnectionStrings[""conString""].ConnectionString;
           }   
           public static string _Connectionstring =  @""" + ConnectionString + @""";

     }
}");
        }

        private static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }


        private static void WriteCompileTag(string CompleteFileName)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ProjectFileName);

            for(int i =0 ;i<xmlDoc.GetElementsByTagName("ItemGroup").Count;i++)
            {
                if (xmlDoc.GetElementsByTagName("ItemGroup")[i].LastChild.Name.Equals("Compile"))
                {
                    XmlNode xmlcompiletag = xmlDoc.CreateNode(XmlNodeType.Element, "Compile", xmlDoc.GetElementsByTagName("ItemGroup")[i].NamespaceURI);
                    xmlcompiletag.Attributes.Append(CreateAttribute(xmlDoc,"Include",CompleteFileName));
                    xmlDoc.GetElementsByTagName("ItemGroup")[i].InsertAfter(xmlcompiletag, xmlDoc.GetElementsByTagName("ItemGroup")[i].LastChild);
                    break;
                }
            }

            xmlDoc.Save(ProjectFileName);

        }


       public static XmlAttribute CreateAttribute(XmlDocument xmlDocument,string attrName,string attrValue)
        {
            XmlAttribute oAtt = xmlDocument.CreateAttribute(attrName);
            oAtt.Value = attrValue;
            return oAtt;
        }

    }
}
