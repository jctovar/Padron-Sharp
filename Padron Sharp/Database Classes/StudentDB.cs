using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Padron.Database_Classes
{
    class StudentDB
    {
        public Padron.Object_Classes.Student GetStudent(string username)
        {
            Padron.Object_Classes.Student student = new Object_Classes.Student();
            MyDataBase mydatabase = new MyDataBase();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            string sql = "SELECT * FROM alumnos_suayed WHERE ch_alumno_num_cta = ?username";

            try
            {
                conn = mydatabase.GetConnection();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("username", username));

                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        student.Firstname = reader.GetString("ch_persona_nombre");
                        student.Lastname = reader.GetString("ch_persona_appaterno") + " " + reader.GetString("ch_persona_apmaterno");
                        student.Email = reader.GetString("ch_persona_email");
                        student.Headquarters = reader.GetString("ch_dependencia_nombre");
                        student.Generation = reader.GetString("nu_alumno_ingreso");
                        student.Field = reader.GetString("ch_plan_cve");
                        student.Curp = reader.GetString("ch_persona_curp");
                        student.Phone = reader.GetString("ch_persona_telefono");
                        //lblSurfaceArea.Text = string.Format("{0:0.00}", reader.GetFloat("surfacearea"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }

            return student;
        }
    }
}
