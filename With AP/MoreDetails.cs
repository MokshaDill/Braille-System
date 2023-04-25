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
        private int count2;
        private int tolcount;

        public MoreDetails(string dotPattern, int count, int dotBraille)
        {
            InitializeComponent();

            dotpat = dotPattern;
            count1 = count;
            count2 = dotBraille;

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

                //shape dots count + name dot count
                tolcount = count1 + count2;

                //text part volume
                double textpart = 50;

                //total dot volume
                double tolvol1 = volume * tolcount;

                //add text part to dots volume
                double tolvolume = tolvol1 + textpart;

                //round the volume
                double tolvol = Math.Round(tolvolume,3);

               
                //display volume
                textBox9.Text = tolvol.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter numeric values for the height and radius.");
            }
            
            

            //show dot count
            textBox8.Text = tolcount.ToString();

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


                    

                    DialogResult result = MessageBox.Show("Are you sure you want to print it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        print pin = new print();
                        pin.ShowDialog();

                    }
                    else
                    {
                        // Do nothing or handle cancellation
                    }

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
