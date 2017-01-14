using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Padron
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;

            label1.Text = Application.ProductName;
            label2.Text = Application.ProductVersion;
            label3.Text = Application.CompanyName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
