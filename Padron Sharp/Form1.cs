using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            Padron.MyDataBase mydatabase = new Padron.MyDataBase();
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            string sql = "SELECT * FROM alumnos_suayed WHERE ch_alumno_num_cta = ?username";

            try
            {
                conn = mydatabase.GetConnection();
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("username", textBox1.Text));

                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
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
                        textBox9.Text = reader.GetString("ch_persona_telefono");
                        //lblSurfaceArea.Text = string.Format("{0:0.00}", reader.GetFloat("surfacearea"));
                    }
                }
                else
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
            }
            else
            {
                textBox1.Select();
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = textBox1.Text.Length;
                MessageBox.Show("Ingrese un número de cuenta valido!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void guardarCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveCSV();
        }

        private void saveCSV()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = String.Format("{0}.csv", textBox1.Text);
            saveFileDialog1.Filter = "Archivo CSV|*.csv";
            saveFileDialog1.Title = "Salvar como archivo CSV";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                if (saveFileDialog1.FileName != "")
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    {
                        Padron.Functions functions = new Padron.Functions();

                        string header = "username,firstname,lastname,email,password,department";

                        string username = textBox1.Text;
                        string firstname = textBox2.Text;
                        string lastname = textBox3.Text;
                        string email = functions.mail(textBox4.Text, textBox1.Text);
                        string password = functions.password(textBox8.Text);
                        string department = "Psicología";

                        string account = String.Format("{0},{1},{2},{3},{4},{5}",username,firstname,lastname,email,password,department);

                        sw.WriteLine(header);
                        sw.Write(account);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Padron.Form3 Test1 = new Padron.Form3();
            Test1.ShowDialog();
        }
    }
}
