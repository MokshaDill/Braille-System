using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace With_AP
{
    public partial class editPrinter : Form
    {
        private string shapedot_p;
        private string braille_name;
        private int count;
        public editPrinter(string dotPattern,string braillename, int countx)
        {
            InitializeComponent();

            shapedot_p= dotPattern;
            braille_name = braillename;
            count = countx;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = shapedot_p+" \n Braille Name - "+braille_name;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoreDetails mr = new MoreDetails(shapedot_p, count);
            mr.ShowDialog();
        }
    }
}
