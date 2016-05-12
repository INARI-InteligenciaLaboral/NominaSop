using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NominaSoprade.Modelos
{
    public class ProcesarDocumento
    {
        public DataTable procesamiento (DataTable m_DataGrid)
        {
            foreach(DataRow m_Row in m_DataGrid.Rows)
                foreach(DataColumn m_Column in m_DataGrid.Columns)
                {
                    MessageBox.Show(m_Column.ColumnName);
                    MessageBox.Show(m_Row[m_Column.ColumnName].ToString());
                }
            return new DataTable();
        }
    }
}
