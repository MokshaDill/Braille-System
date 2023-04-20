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
    public partial class MoreDetails : Form
    {
        private string dotpat;
        private int count1;

        public MoreDetails(string dotPattern, string count)
        {
            InitializeComponent();

            dotpat = dotPattern;
            count1 = Convert.ToInt32(count);
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double h = Convert.ToInt32(textBox1.Text);
            double r = Convert.ToInt32(textBox2.Text);
            double volume = Math.PI * r * r * h;
            textBox3.Text = volume.ToString();
            label7.Text = r.ToString();
            label8.Text = h.ToString();

            textBox8.Text = count1.ToString(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double think = Convert.ToInt32(textBox4.Text);
            double speed = Convert.ToInt32(textBox5.Text);
            double temp = Convert.ToInt32(textBox6.Text);
            double angle = Convert.ToInt32(textBox7.Text);
            double h = Convert.ToInt32(textBox1.Text);
            double r = Convert.ToInt32(textBox2.Text);
            double volume = Math.PI * r * r * h;
            int dotcount = 0;

            
        }

     

        private void MoreDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
