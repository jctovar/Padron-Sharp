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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text.Length == 9)
            {
                loadStudent();
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

        private void loadStudent()
        {
            Padron.Object_Classes.Student student = new Padron.Object_Classes.Student();
            Padron.Database_Classes.StudentDB studentDB = new Padron.Database_Classes.StudentDB();

            try
            {
                student = studentDB.GetStudent(textBox1.Text);
                if (student != null)
                {
                    textBox2.Text = student.Firstname;
                    textBox3.Text = student.Lastname;
                    textBox4.Text = student.Email;
                    textBox5.Text = student.Headquarters;
                    textBox6.Text = student.Generation;
                    textBox7.Text = student.Field;
                    textBox8.Text = student.Curp;
                    textBox9.Text = student.Phone;
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
                textBox1.Select();
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = textBox1.Text.Length;
            }

        }
    }
}
