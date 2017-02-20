using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmFramework
{
    class Fields
    {
        public enum _FieldType { 
            Int64
            , ByteArr,
        Boolean,
           String,
          DateTime,
           DateTimeOffset,
           Decimal,
           Double,
           Int32,
           Int16,
           Object,
           Byte,
           Guid,
            Single,
            TimeSpan

        }

        public Fields()
        {
            
        }

        public string FieldName { get; set; }
        public _FieldType FieldType { get; set; }
    }
}
