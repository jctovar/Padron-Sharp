using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pruebas1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadData()
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            string host = Padron.Properties.Settings.Default.host;
            string database = Padron.Properties.Settings.Default.database;
            string username = Padron.Properties.Settings.Default.username;
            string password = Padron.Properties.Settings.Default.password;


            string myConnectionString = String.Format("server={0};uid={1};pwd={2};database={3};",host,username,password,database);

            try
            {
                string sql = "SELECT * FROM alumnos_suayed WHERE ch_alumno_num_cta = ?username";

                conn = new MySqlConnection(myConnectionString);
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("username", textBox1.Text));

                conn.Open();

                reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        textBox2.Text = reader.GetString("ch_persona_nombre");
                        textBox3.Text = reader.GetString("ch_persona_appaterno") + " " + reader.GetString("ch_persona_apmaterno");
                        textBox4.Text = reader.GetString("ch_persona_email");
                        textBox5.Text = reader.GetString("ch_dependencia_nombre");
                        textBox6.Text = reader.GetString("nu_alumno_ingreso");
                        textBox7.Text = reader.GetString("ch_plan_cve");
                        textBox8.Text = reader.GetString("ch_persona_curp");
                        //lblSurfaceArea.Text = string.Format("{0:0.00}", reader.GetFloat("surfacearea"));
                    }
                } else
                {
                   
                    MessageBox.Show("No se encontro la cuenta!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
                textBox1.Select();
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = textBox1.Text.Length;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text.Length == 9)
            {
                loadData();
            } else {
                textBox1.Select();
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = textBox1.Text.Length;
                MessageBox.Show("Ingrese un número de cuenta valido!",Application.ProductName,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Padron.Form2 ConfigBox = new Padron.Form2();
            ConfigBox.ShowDialog();
        }

        private void acercaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Padron.About AboutBox = new Padron.About();
            AboutBox.ShowDialog();
        }
    }
}
