using System;
using System.Collections;
using System.Data;

namespace NominaSoprade.Modelos
{
    public class ProcesarDocumento
    {
        public ArrayList procesamiento (DataTable m_DataGrid)
        {
            ArrayList ListaInsidencias = new ArrayList();
            foreach(DataRow m_Row in m_DataGrid.Rows)
            {
                int m_vac = 0, m_f= 0, m_psg = 0, m_pgs = 0, m_r = 0;
                DateTime? m_fecvac = null, m_fecf = null, m_fecpsg = null, m_fecpgs = null, m_fecr= null;
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
                                ListaInsidencias.Add(new Errores() { ID_Empleado = (Int32.Parse(m_Row[0].ToString())), Columna = m_Column.ColumnName,
                                    Nombre = m_Row[1].ToString(), Concepto = m_Row[m_Column.ColumnName].ToString()});
                            }
                            else 
                            {
                                if (m_Row[m_Column.ColumnName].ToString().Equals("VAC"))
                                {
                                    if (!m_fecvac.HasValue)
                                    {
                                        m_fecvac = Convert.ToDateTime(m_Column.ColumnName);
                                    }
                                    m_vac++;
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().Equals("F"))
                                {
                                    if (!m_fecf.HasValue)
                                    {
                                        m_fecf = Convert.ToDateTime(m_Column.ColumnName);
                                    }
                                    m_f++;
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().Equals("PSG"))
                                {
                                    if (!m_fecpsg.HasValue)
                                    {
                                        m_fecpsg = Convert.ToDateTime(m_Column.ColumnName);
                                    }
                                    m_psg++;
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().Equals("PGS"))
                                {
                                    if (!m_fecpgs.HasValue)
                                    {
                                        m_fecpgs = Convert.ToDateTime(m_Column.ColumnName);
                                    }
                                    m_pgs++;
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().Equals("R"))
                                {
                                    if (!m_fecr.HasValue)
                                    {
                                        m_fecr = Convert.ToDateTime(m_Column.ColumnName);
                                    }
                                    m_r++;
                                }
                            }
                        }
                        else
                        {

                        }
                    }
                    catch
                    { }
                }
                if (m_vac > 0)
                    ListaInsidencias.Add(new Vacaciones() { ID_Empleado = Int32.Parse(m_Row[0].ToString()), Concepto = "CV1", Dias = m_vac, Fecha = m_fecvac.Value });
                if (m_f > 0)
                    ListaInsidencias.Add(new Ausencias() { ID_Empleado = Int32.Parse(m_Row[0].ToString()), Concepto = "CF1", Fecha = m_fecf.Value, Cantidad = m_f });
                if (m_psg > 0)
                    ListaInsidencias.Add(new Ausencias() { ID_Empleado = Int32.Parse(m_Row[0].ToString()), Concepto = "CF4", Fecha = m_fecpsg.Value, Cantidad = m_psg });
                if (m_pgs > 0)
                    ListaInsidencias.Add(new Ausencias() { ID_Empleado = Int32.Parse(m_Row[0].ToString()), Concepto = "CF3", Fecha = m_fecpgs.Value, Cantidad = m_pgs });
                if (m_r > 0)
                    ListaInsidencias.Add(new Ausencias() { ID_Empleado = Int32.Parse(m_Row[0].ToString()), Concepto = "CF5", Fecha = m_fecr.Value, Cantidad = m_r });
            } 
            return ListaInsidencias;
        }
        private bool valvalido(string m_Insidencia)
        {
            string[] m_ArreInsid = new string[11] { "A", "F", "B", "VAC", "D", "PD", "R", "PGS", "IM", "PSG", "EG" };
            bool m_Valido = false;
            m_Insidencia = m_Insidencia.ToUpper();
            for(int elemento = 0; elemento < m_ArreInsid.Length; elemento++)
            {
                if (m_Insidencia.Equals(m_ArreInsid[elemento]))
                {
                    m_Valido = true;
                    break;
                }
            }
            return m_Valido;
        }
    }
}
