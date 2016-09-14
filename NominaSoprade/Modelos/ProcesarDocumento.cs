using System;
using System.Collections;
using System.Data;

namespace NominaSoprade.Modelos
{
    public class ProcesarDocumento
    {
        public ArrayList procesamiento(DataTable m_DataGrid)
        {
            DateTime? m_FechaInsi = null;
            DataTable m_DiasAuseto = new DataTable();
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
                            if (!m_FechaInsi.HasValue)
                            {
                                SqlClass m_ConBd = new SqlClass();
                                m_FechaInsi = m_ConBd.ObtenerPeri(DateTime.Parse(m_Column.ColumnName));
                                if (!m_FechaInsi.HasValue)
                                {
                                    Herramientas.Clases.Information.MensajeInformation("No existe Periodo Ordinario \npara estas fechas");
                                    m_FechaInsi = DateTime.Now;
                                }
                                m_DiasAuseto = m_ConBd.ObtenerDiasAsueto(m_FechaInsi.Value);
                            }
                            if (!valvalido(m_Row[m_Column.ColumnName].ToString()) && !m_Row[m_Column.ColumnName].ToString().Equals(""))
                            {
                                ListaInsidencias.Add(new Errores()
                                {
                                    ID_Empleado = m_Row[2].ToString(),
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
                                        m_vac++;
                                    }
                                    else
                                    {
                                        if (m_fecvac.Value.AddDays(m_vac) == Convert.ToDateTime(m_Column.ColumnName))
                                        {
                                            m_vac++;
                                        }
                                        else
                                        {
                                            ListaInsidencias.Add(new Vacaciones() { ID_Empleado = m_Row[2].ToString(), Concepto = "CV1", Dias = m_vac, Fecha = m_fecvac.Value });
                                            m_fecvac = Convert.ToDateTime(m_Column.ColumnName);
                                            m_vac = 1;
                                        }
                                    }
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().ToUpper().Equals("F"))
                                {
                                    if (!m_fecf.HasValue)
                                    {
                                        m_fecf = Convert.ToDateTime(m_Column.ColumnName);
                                        m_f++;
                                    }
                                    else
                                    {
                                        if (m_fecf.Value.AddDays(m_f) == Convert.ToDateTime(m_Column.ColumnName))
                                        {
                                            m_f++;
                                        }
                                        else
                                        {
                                            ListaInsidencias.Add(new Ausencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "CF1", Fecha = m_fecf.Value, Cantidad = m_f });
                                            m_fecf = Convert.ToDateTime(m_Column.ColumnName);
                                            m_f = 1;
                                        }
                                    }
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().ToUpper().Equals("PSG"))
                                {
                                    if (!m_fecpsg.HasValue)
                                    {
                                        m_fecpsg = Convert.ToDateTime(m_Column.ColumnName);
                                        m_psg++;
                                    }
                                    else
                                    {
                                        if (m_fecpsg.Value.AddDays(m_psg) == Convert.ToDateTime(m_Column.ColumnName))
                                        {
                                            m_psg++;
                                        }
                                        else
                                        {
                                            ListaInsidencias.Add(new Ausencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "CF4", Fecha = m_fecpsg.Value, Cantidad = m_psg });
                                            m_fecpsg = Convert.ToDateTime(m_Column.ColumnName);
                                            m_psg = 1;
                                        }
                                    }
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().ToUpper().Equals("PGS"))
                                {
                                    if (!m_fecpgs.HasValue)
                                    {
                                        m_fecpgs = Convert.ToDateTime(m_Column.ColumnName);
                                        m_pgs++;
                                    }
                                    else
                                    {
                                        if (m_fecpgs.Value.AddDays(m_pgs) == Convert.ToDateTime(m_Column.ColumnName))
                                        {
                                            m_pgs++;
                                        }
                                        else
                                        {
                                            ListaInsidencias.Add(new Ausencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "CF3", Fecha = m_fecpgs.Value, Cantidad = m_pgs });
                                            m_fecpgs = Convert.ToDateTime(m_Column.ColumnName);
                                            m_pgs = 1;
                                        }
                                    }
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().ToUpper().Equals("R"))
                                {
                                    if (!m_fecr.HasValue)
                                    {
                                        m_fecr = Convert.ToDateTime(m_Column.ColumnName);
                                        m_r++;
                                    }
                                    else
                                    {
                                        ListaInsidencias.Add(new Ausencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "CF5", Fecha = m_fecr.Value, Cantidad = m_r });
                                        m_fecr = Convert.ToDateTime(m_Column.ColumnName);
                                        m_r = 1;
                                    }
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().ToUpper().Equals("A"))
                                {
                                    if (m_DiasAuseto.Rows.Count > 0)
                                    {
                                        foreach(DataRow m_Filas in m_DiasAuseto.Rows)
                                        {
                                            if(DateTime.Parse(m_Filas[0].ToString()) == DateTime.Parse(m_Column.ColumnName))
                                            {
                                                ListaInsidencias.Add(new ExcepcionTrabajada() { ID_Empleado = m_Row[2].ToString() , Concepto = "CD2", Fecha = DateTime.Parse(m_Column.ColumnName), Min_Retardo = 1 });
                                            }
                                        }
                                    }
                                }
                                else if (m_Row[m_Column.ColumnName].ToString().ToUpper().Equals("PD"))
                                {
                                    if (m_DiasAuseto.Rows.Count > 0)
                                    {
                                        foreach (DataRow m_Filas in m_DiasAuseto.Rows)
                                        {
                                            if (DateTime.Parse(m_Filas[0].ToString()) == DateTime.Parse(m_Column.ColumnName))
                                            {
                                                ListaInsidencias.Add(new ExcepcionTrabajada() { ID_Empleado = m_Row[2].ToString(), Concepto = "CD3", Fecha = DateTime.Parse(m_Column.ColumnName), Min_Retardo = 1 });
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        string m_Columna = m_Column.ColumnName.ToString().ToUpper().Replace(" ", "");
                        if (m_Columna.ToString().Equals("VALESDEDESPENSA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "358", Unidades = 1, Importe = m_valor });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("PREMIODEPUNTUALIDAD"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "353", Unidades = 1, Importe = m_valor });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (m_Row[2].ToString()),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("PREMIODEASISTENCIA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "354", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = (m_Row[2].ToString()),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("PRODUCTIVIDAD"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "355", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("APOYOCOMPENSACIÓN") || m_Columna.ToString().Equals("COMPENSACIÓN"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "383", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("APOYOGRATIFICACIÓN") || m_Columna.ToString().Equals("GRATIFICACIÓN"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "377", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("APOYOTRANSPORTE") || m_Columna.ToString().Equals("APOYODETRANSPORTE"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "375", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("APOYOPROMOCIÓN") || m_Columna.ToString().Equals("APOYODEPROMOCIÓN"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "378", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("BONORECOMENDACIÓN") || m_Columna.ToString().Equals("BONODERECOMENDACIÓN"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "379", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("APOYOTECNOLOGÍA") || m_Columna.ToString().Equals("APOYODETECNOLOGÍA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "379", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("COMPLEMENTONÓMINA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "371", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("BONO") || m_Columna.ToString().Equals("BONOA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "385", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("PRIMAVACACIONAL"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "382", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("COMISIONES"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "351", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("APOYOPORASISTENCIA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "381", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("CREESER(BC)"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "468", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("CREESER(T.AMI)") || m_Columna.ToString().Equals("CREESER(TAMI)"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "469", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("ARTICULOSPROMOCIONALES") || m_Columna.ToString().Equals("ART.PROMOCIONALES") || m_Columna.ToString().Equals("ARTPROMOCIONALES"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "470", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("EVENTOSINSTITUCIONALES"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "445", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("GASTOSNOCOMPROBADOS"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "465", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("BAJASDESFASADAS"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "476", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("PRESTAMO") || m_Columna.ToString().Equals("PRÉSTAMOSCALLFASST") || m_Columna.ToString().Equals("PRESTAMOSCALLFASST"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "444", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("PRESTAMOCAJADEAHORRO") || m_Columna.ToString().Equals("PRÉSTAMOSCAJADEAHORROCALLFASST") || m_Columna.ToString().Equals("PRESTAMOSCAJADEAHORROCALLFASST"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "478", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("CAJADEAHORRO") || m_Columna.ToString().Equals("CAJADEAHORROFASST"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "477", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("COMPLEMENTODENOMINA"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "479", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
                                            Columna = m_Column.ColumnName,
                                            Nombre = m_Row[3].ToString(),
                                            Concepto = m_Row[m_Column.ColumnName].ToString()
                                        });
                                    }
                                    catch { }
                                }
                            }
                        }
                        else if (m_Columna.ToString().Equals("PERMISOGENTEINNOVANDO"))
                        {
                            if (!string.IsNullOrEmpty(m_Row[m_Column.ColumnName].ToString()))
                            {
                                try
                                {
                                    float m_valor = float.Parse(m_Row[m_Column.ColumnName].ToString());
                                    if (m_valor > 0)
                                    {
                                        ListaInsidencias.Add(new Insidencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "443", Unidades = 1, Importe = m_valor, Departamento = m_Row[0].ToString(), Puesto = m_Row[1].ToString(), Fecha = m_FechaInsi.Value });
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        ListaInsidencias.Add(new Errores()
                                        {
                                            ID_Empleado = m_Row[2].ToString(),
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
                    ListaInsidencias.Add(new Vacaciones() { ID_Empleado = m_Row[2].ToString(), Concepto = "CV1", Dias = m_vac, Fecha = m_fecvac.Value });
                if (m_f > 0)
                    ListaInsidencias.Add(new Ausencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "CF1", Fecha = m_fecf.Value, Cantidad = m_f });
                if (m_psg > 0)
                    ListaInsidencias.Add(new Ausencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "CF4", Fecha = m_fecpsg.Value, Cantidad = m_psg });
                if (m_pgs > 0)
                    ListaInsidencias.Add(new Ausencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "CF3", Fecha = m_fecpgs.Value, Cantidad = m_pgs });
                if (m_r > 0)
                    ListaInsidencias.Add(new Ausencias() { ID_Empleado = m_Row[2].ToString(), Concepto = "CF5", Fecha = m_fecr.Value, Cantidad = m_r });
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