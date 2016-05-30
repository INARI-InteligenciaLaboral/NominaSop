using System;
using System.Collections;
using System.Data;

namespace NominaSoprade.Modelos
{
    public class ProcesarDocumento
    {
        public ArrayList procesamiento(DataTable m_DataGrid)
        {
            ArrayList ListaInsidencias = new ArrayList();
            foreach (DataRow m_Row in m_DataGrid.Rows)
            {
                int m_vac = 0, m_f = 0, m_psg = 0, m_pgs = 0, m_r = 0;
                DateTime? m_fecvac = null, m_fecf = null, m_fecpsg = null, m_fecpgs = null, m_fecr = null;
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
                                ListaInsidencias.Add(new Errores()
                                {
                                    ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                    Columna = m_Column.ColumnName,
                                    Nombre = m_Row[3].ToString(),
                                    Concepto = m_Row[m_Column.ColumnName].ToString()
                                });
                            }
                            else
                            {
                                if (m_Row[m_Column.ColumnName].ToString().ToUpper().Equals("VAC"))
                                {
                                    if (!m_fecvac.HasValue)
                                    {
                                        m_fecvac = Convert.ToDateTime(m_Column.ColumnName);
                                    }
                                    m_vac++;
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().ToUpper().Equals("F"))
                                {
                                    if (!m_fecf.HasValue)
                                    {
                                        m_fecf = Convert.ToDateTime(m_Column.ColumnName);
                                    }
                                    m_f++;
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().ToUpper().Equals("PSG"))
                                {
                                    if (!m_fecpsg.HasValue)
                                    {
                                        m_fecpsg = Convert.ToDateTime(m_Column.ColumnName);
                                    }
                                    m_psg++;
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().ToUpper().Equals("PGS"))
                                {
                                    if (!m_fecpgs.HasValue)
                                    {
                                        m_fecpgs = Convert.ToDateTime(m_Column.ColumnName);
                                    }
                                    m_pgs++;
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().ToUpper().Equals("R"))
                                {
                                    if (!m_fecr.HasValue)
                                    {
                                        m_fecr = Convert.ToDateTime(m_Column.ColumnName);
                                    }
                                    m_r++;
                                }
                            }
                        }
                    }
                    catch
                    {
                        if (m_Column.ColumnName.ToString().ToUpper().Equals("VALES DE DESPENSA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "358", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("PREMIO DE PUNTUALIDAD"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "353", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("PREMIO DE ASISTENCIA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "354", Unidades = 1, Importe = m_valor, Centro_Costo = 01});
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("PRODUCTIVIDAD"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "355", Unidades = 1, Importe = m_valor, Centro_Costo = 01, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString() });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("APOYO COMPENSACIÓN") || m_Column.ColumnName.ToString().ToUpper().Equals("COMPENSACIÓN"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "383", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("APOYO GRATIFICACIÓN") || m_Column.ColumnName.ToString().ToUpper().Equals("GRATIFICACIÓN"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "377", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("APOYO TRANSPORTE") || m_Column.ColumnName.ToString().ToUpper().Equals("APOYO DE TRANSPORTE"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "375", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("APOYO PROMOCIÓN") || m_Column.ColumnName.ToString().ToUpper().Equals("APOYO DE PROMOCIÓN"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "378", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("BONO RECOMENDACIÓN") || m_Column.ColumnName.ToString().ToUpper().Equals("BONO DE RECOMENDACIÓN"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "379", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("APOYO TECNOLOGÍA") || m_Column.ColumnName.ToString().ToUpper().Equals("APOYO DE TECNOLOGÍA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "379", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("COMPLEMENTO NÓMINA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "371", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("BONO") || m_Column.ColumnName.ToString().ToUpper().Equals("BONO A"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "385", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("PRIMA VACACIONAL"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "382", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("COMISIONES"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "351", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("APOYO POR ASISTENCIA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "381", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("CREESER (BC)"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "468", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("CREESER (T. AMI)") || m_Column.ColumnName.ToString().ToUpper().Equals("CREESER (T AMI)"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "469", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("ARTICULOS PROMOCIONALES"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "470", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("EVENTOS INSTITUCIONALES"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "445", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("GASTOS NO COMPROBADOS"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "465", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("BAJAS DESFASADAS"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "476", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("PRESTAMO") || m_Column.ColumnName.ToString().ToUpper().Equals("PRÉSTAMOS CALL FASST") || m_Column.ColumnName.ToString().ToUpper().Equals("PRESTAMOS CALL FASST"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "444", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("PRESTAMO CAJA DE AHORRO") || m_Column.ColumnName.ToString().ToUpper().Equals("PRÉSTAMOS CAJA DE AHORRO CALL FASST") || m_Column.ColumnName.ToString().ToUpper().Equals("PRESTAMOS CAJA DE AHORRO CALL FASST"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "478", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("CAJA DE AHORRO") || m_Column.ColumnName.ToString().ToUpper().Equals("CAJA DE AHORRO FASST"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "477", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("COMPLEMENTO DE NOMINA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "479", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Column.ColumnName.ToString().ToUpper().Equals("PERMISO GENTE INNOVANDO"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "443", Unidades = 1, Importe = m_valor, Centro_Costo = 01 });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (Int32.Parse(m_Row[2].ToString())),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
                if (m_vac > 0)
                    ListaInsidencias.Add(new Vacaciones() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "CV1", Dias = m_vac, Fecha = m_fecvac.Value });
                if (m_f > 0)
                    ListaInsidencias.Add(new Ausencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "CF1", Fecha = m_fecf.Value, Cantidad = m_f });
                if (m_psg > 0)
                    ListaInsidencias.Add(new Ausencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "CF4", Fecha = m_fecpsg.Value, Cantidad = m_psg });
                if (m_pgs > 0)
                    ListaInsidencias.Add(new Ausencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "CF3", Fecha = m_fecpgs.Value, Cantidad = m_pgs });
                if (m_r > 0)
                    ListaInsidencias.Add(new Ausencias() { ID_Empleado = Int32.Parse(m_Row[2].ToString()), Concepto = "CF5", Fecha = m_fecr.Value, Cantidad = m_r });
            }
            return ListaInsidencias;
        }
        private bool valvalido(string m_Insidencia)
        {
            string[] m_ArreInsid = new string[11] { "A", "F", "B", "VAC", "D", "PD", "R", "PGS", "IM", "PSG", "EG" };
            bool m_Valido = false;
            m_Insidencia = m_Insidencia.ToUpper();
            for (int elemento = 0; elemento < m_ArreInsid.Length; elemento++)
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