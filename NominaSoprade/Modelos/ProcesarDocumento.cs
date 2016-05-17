using System;
using System.Data;
using System.Windows.Forms;

namespace NominaSoprade.Modelos
{
    public class ProcesarDocumento
    {
        public string procesamiento (DataTable m_DataGrid)
        {
            string m_Resultados = "";
            foreach(DataRow m_Row in m_DataGrid.Rows)
            {
                foreach (DataColumn m_Column in m_DataGrid.Columns)
                {
                    DateTime? m_Fecha = null;
                    try
                    {
                        m_Fecha = Convert.ToDateTime(m_Column.ColumnName);
                        if (m_Fecha.HasValue)
                        {
                            if (!valvalido(m_Row[m_Column.ColumnName].ToString()) && !m_Row[m_Column.ColumnName].ToString().Equals(""))
                            {
                                m_Resultados += "Valor invalido en la columna " + m_Column.ColumnName
                                    + " en el empleado " + m_Row[0].ToString() + " " + m_Row[1].ToString() + Environment.NewLine;
                            }

                        }
                    }
                    catch
                    { }
                }
            } 
            return m_Resultados;
        }
        private bool valvalido(string m_Insidencia)
        {
            string[] m_ArreInsid = new string[11] { "A", "F", "B", "VAC", "D", "PD", "R", "PGS", "IM", "PSG", "EG" };
            bool m_Valido = false;
            m_Insidencia = m_Insidencia.ToUpper();
            for(int elemento = 0; elemento < m_ArreInsid.Length; elemento++)
            {
                if (m_Insidencia.Equals(m_ArreInsid[elemento]))
                    m_Valido = true;
            }
            return m_Valido;
        }
    }
}
