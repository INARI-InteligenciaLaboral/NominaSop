using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NominaSoprade.Modelos
{
    public class SqlClass
    {
        //string m_cadena = "Persist Security Info=False;User ID=sa;Password=Sql1N4r1;Initial Catalog=dbDatosNominaTest;Server=DB-SERVER\\INARISQL";
        string m_cadena = "Persist Security Info=False;User ID=sa;Password=Inari2016;Initial Catalog=dbDatosNomina;Server=TI-PROGANA01\\INARIPROG";
        public DataTable ObtenerEmp()
        {
            DataTable m_empleados = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "SELECT Cont.contIDEmpl, RTRIM(Emp.emplNombre) + ' ' + RTRIM(Emp.emplApPat) + ' ' + ";
                    m_command += "RTRIM(Emp.emplApMat) as NombreCompleto, Cont.contIDPues, Cont.contIDDeps ";
                    m_command += "FROM dbo.nomContratos as Cont INNER JOIN dbo.nomEmpleados AS Emp ON ";
                    m_command += "Cont.contIDEmpl = Emp.emplIDEmpl WHERE (contIDEmpl LIKE '130%' Or contIDEmpl LIKE '131%') ";
                    m_command += "AND Emp.emplEstatus = 'A'";

                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_empleados.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión \n" + ex.Message);
            }
            return m_empleados;
        }
        public string ObtCentroCosto()
        {
            DataTable m_CenCosto = new DataTable();
            string m_StrCen = "";
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "SELECT cencIDCenc FROM dbo.nomCentrosCosto ";
                    m_command += "WHERE cencDescripcion = 'FASST SA DE CV'";
                    SqlCommand m_adapter = new SqlCommand(m_command, m_conexion);
                    m_CenCosto.Load(m_adapter.ExecuteReader());
                    m_conexion.Close();

                    foreach (DataRow m_Row in m_CenCosto.Rows)
                    {
                        m_StrCen = m_Row[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión \n" + ex.Message);
            }
            return m_StrCen;
        }
        public DateTime? ObtenerPeri()
        {
            string m_command = "SELECT periFecIni FROM dbo.nomPeriodos WHERE periIDNomi = 'ORD' AND periIDPcal = '5601' ";
                   m_command += "AND @FechaInicio BETWEEN periFecIni AND periFecFin";
            DateTime? m_FechaInicial = null; 
            using (SqlConnection m_conexion = new SqlConnection(m_cadena))
            {
                SqlCommand command = new SqlCommand(m_command, m_conexion);
                command.Parameters.Add("@FechaInicio", SqlDbType.Date);
                command.Parameters["@FechaInicio"].Value = m_FechaInc;
                DataTable m_Periodo = new DataTable();
                try
                {
                    m_conexion.Open();
                    m_Periodo.Load(command.ExecuteReader());
                    m_conexion.Close();
                    if (m_Periodo.Rows.Count > 0)
                    {
                        foreach (DataRow m_Row in m_Periodo.Rows)
                        {
                            m_FechaInicial = DateTime.Parse(m_Row[0].ToString());
                        }
                    }
                }
                catch {}
            }
            if (m_FechaInicial.HasValue)
            {
                return m_FechaInicial.Value;
            }
            else
            {
                return null;
            }
        }
    }
}
