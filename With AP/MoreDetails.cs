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

            try
            {
                double h = Convert.ToDouble(textBox1.Text);
                double r = Convert.ToDouble(textBox2.Text);

                double volume1 = Math.PI * r * r * h;
                double volume = Math.Round(volume1,3);

                textBox3.Text = volume.ToString();
                label7.Text = r.ToString();
                label8.Text = h.ToString();

                double tolvol1 = volume * count1;
                double tolvol = Math.Round(tolvol1,3);

                textBox9.Text = tolvol.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter numeric values for the height and radius.");
            }
            
            

            //show dot count
            textBox8.Text = count1.ToString();

            //show dot pattern in rich box
            //richTextBox1.Text = dotpat;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToDouble(textBox4.Text) == 0 && Convert.ToDouble(textBox5.Text) == 0 && Convert.ToDouble(textBox6.Text) == 0 && Convert.ToDouble(textBox7.Text) == 0) 
                {
                    MessageBox.Show("Please Fill All Boxes");

                }
                else
                {
                    double think = Convert.ToInt32(textBox4.Text);
                    double speed = Convert.ToInt32(textBox5.Text);
                    double temp = Convert.ToInt32(textBox6.Text);
                    double angle = Convert.ToInt32(textBox7.Text);
                    double h = Convert.ToInt32(textBox1.Text);
                    double r = Convert.ToInt32(textBox2.Text);
                    double volume = Math.PI * r * r * h;
                    int dotcount = 0;


                    print pin = new print();
                    pin.ShowDialog();

                }

            }
            catch (FormatException)
                {
                    MessageBox.Show("Please enter numeric values for the height and radius.");
                }


                
        }

     

        private void MoreDetails_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
