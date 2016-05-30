using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NominaSoprade.Modelos
{
    public class SqlClass
    {
        public DataTable ObtenerEmp()
        {
            //string m_cadena = "Persist Security Info=False;User ID=sa;Password=Sql1N4r1;Initial Catalog=dbDatosNominaTest;Server=DB-SERVER\\INARISQL";
            string m_cadena = "Persist Security Info=False;User ID=sa;Password=Inari2016;Initial Catalog=dbDatosNomina;Server=TI-PROGANA01\\INARIPROG";
              DataTable m_empleados = new DataTable();
            try
            {
                using (SqlConnection m_conexion = new SqlConnection(m_cadena))
                {
                    m_conexion.Open();
                    string m_command = "SELECT Cont.contIDEmpl, RTRIM(Emp.emplNombre) + ' ' + RTRIM(Emp.emplApPat) + ' ' + ";
                    m_command += "RTRIM(Emp.emplApMat) as NombreCompleto, Cont.contIDPues, Cont.contIDDeps ";
                    m_command += "FROM dbo.nomContratos as Cont INNER JOIN dbo.nomEmpleados AS Emp ON ";
                    m_command += "Cont.contIDEmpl = Emp.emplIDEmpl WHERE contIDEmpl LIKE '130%' ";
                    //m_command += "AND Emp.emplEstatus = 'A'";

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
    }
}
