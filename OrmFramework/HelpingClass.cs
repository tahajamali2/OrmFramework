using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrmFramework
{
    class HelpingClass
    {
        public static void PopulateDataGridView(object objectlist, DataGridView gidviewtofill)
        {
            if (objectlist.GetType().GetGenericTypeDefinition() == typeof(List<>) && objectlist.GetType().IsGenericType)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = objectlist;

                gidviewtofill.DataSource = bs;
                gidviewtofill.AutoGenerateColumns = true;
            }

            else
            {
                throw new Exception("Please Provide Generic List Of Objects");
            }
        }
    }
}
