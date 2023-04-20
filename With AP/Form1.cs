using Newtonsoft.Json;
using System.Linq;
using static Test_with_AP.Controllers.WeatherForecastController;

namespace With_AP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string h = numericUpDown1.Text;
            string w = numericUpDown2.Text;
            string r = numericUpDown3.Text;
            //string re = numericUpDown4.Text;

            
            

            String url;
            

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    url = $"https://localhost:44341/WeatherForecast/Square/{h}";
                    GetApi(url);
                    break;

                case 1:
                    url = $"https://localhost:44341/WeatherForecast/rectangle/{w}/{h}";
                    GetApi(url);
                    break;

                case 2:
                    url = $"https://localhost:44341/WeatherForecast/circle/{r}";
                    GetApi(url);
                    break;

                case 3:
                    url = $"https://localhost:44341/WeatherForecast/Trangle/{h}";
                    GetApi(url);
                    break;

                case 4:
                    url = $"https://localhost:44341/WeatherForecast/hexagon/{w}";
                    GetApi(url);
                    break;

                case 5:
                    url = $"https://localhost:44341/WeatherForecast/octagon/{w}";
                    GetApi(url);
                    break;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                numericUpDown1.Enabled = true;//numericUpDown1
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                //numericUpDown4.Enabled = false;
            }
            else if(comboBox1.SelectedIndex == 1) 
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                //numericUpDown4.Enabled = false;
            }else if(comboBox1.SelectedIndex == 2)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
               // numericUpDown4.Enabled = true;
            }else if(comboBox1.SelectedIndex == 3)
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                //numericUpDown4.Enabled = false;
            }else if(comboBox1.SelectedIndex == 4)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
               // numericUpDown4.Enabled = false;
            }else if(comboBox1.SelectedIndex == 5)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                //numericUpDown4.Enabled = false;
            }
            //else
            //{
            //    numericUpDown1.Enabled = true;
            //    numericUpDown2.Enabled = true;
            //    numericUpDown3.Enabled = true;
            //    numericUpDown4.Enabled = true;
            //}


        }


        // sync with API 
        private async void GetApi(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);

                String json = await response.Content.ReadAsStringAsync();
                SquareResult result = JsonConvert.DeserializeObject<SquareResult>(json);

                String dotPattern = result.DotPattern;
                int countint = result.Count;
                string count = Convert.ToString(countint);

                if (response.IsSuccessStatusCode)
                {
                    richTextBox1.Text = dotPattern;
                    textBox2.Text = count;  
                }
                else
                {
                    richTextBox1.Text = "Server Error";
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text = ex.Message;
            }

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tex = textBox1.Text;

            string url;
            url = $"https://localhost:44341/WeatherForecast/text/{tex}";
            GetApi(url);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //TabControl tabControl = (TabControl)sender;
            //TabPage tabPage = tabControl.TabPages[e.Index];

            //// Set the background color of the tab page
            //tabPage.BackColor = Color.Blue;

            //// Set the text color of the tab page
            //tabPage.ForeColor = Color.White;

            //// Draw the tab item
            //e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds);
            //e.Graphics.DrawString(tabPage.Text, tabControl.Font, new SolidBrush(Color.White), e.Bounds.X + 3, e.Bounds.Y + 3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MoreDetails md = new MoreDetails();
            md.ShowDialog();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



/*
 * //Square checking 
            if (comboBox1.SelectedIndex == 0)
            {
                numericUpDown1.Enabled = true;//numericUpDown1
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
            }
            else
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
            }

            //Rectangle checking
            if (comboBox1.SelectedIndex == 1)
            {
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
            }
            else
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
            }

            //Circle checking
            if (comboBox1.SelectedIndex == 2)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown4.Enabled = false;
            }
            else
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
            }

            //Trangle checking
            if (comboBox1.SelectedIndex == 3)
            {
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
            }
            else
            {
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
            }
 */
