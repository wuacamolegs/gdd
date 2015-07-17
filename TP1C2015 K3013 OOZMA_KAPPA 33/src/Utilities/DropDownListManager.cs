using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Utilities
{
    public class DropDownListManager
    {
        public static void CargarCombo(ComboBox combo, object dataSource, string valueMember, string displayMember, bool tieneTextoDefault, string textoDefault)
        {

            if (tieneTextoDefault)
            {
                DataRow dr = ((DataTable)dataSource).NewRow();
                dr[valueMember] = 0;
                if (textoDefault == string.Empty)
                {
                    dr[displayMember] = "Seleccione...";
                }
                else
                {
                    dr[displayMember] = 0;
                }
                ((DataTable)dataSource).Rows.InsertAt(dr, 0);
            }


            if (displayMember.Length > 0)
            {
                combo.DisplayMember = displayMember;
            }
            if (valueMember.Length > 0)
            {
                combo.ValueMember = valueMember;
            }

            combo.DataSource = dataSource;
        }

      
    }
}
