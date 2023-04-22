using java.util.logging;
using Newtonsoft.Json;
using System.Linq;
using NLog;
using static Test_with_AP.Controllers.WeatherForecastController;
using Logger = NLog.Logger;
using LogManager = NLog.LogManager;

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
                    url = $"https://localhost:7286/WeatherForecast/Square/{h}";
                    GetApi(url);
                    break;

                case 1:
                    url = $"https://localhost:7286/WeatherForecast/rectangle/{w}/{h}";
                    GetApi(url);
                    break;

                case 2:
                    url = $"https://localhost:7286/WeatherForecast/circle/{r}";
                    GetApi(url);
                    break;

                case 3:
                    url = $"https://localhost:7286/WeatherForecast/Trangle/{h}";
                    GetApi(url);
                    break;

                case 4:
                    url = $"https://localhost:7286/WeatherForecast/hexagon/{w}";
                    GetApi(url);
                    break;

                case 5:
                    url = $"https://localhost:7286/WeatherForecast/octagon/{w}";
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

        
        private string count;
        private int countnew;
        private string dotPattern;
        private string braillename;
        // sync with API 
        private async void GetApi(string url)
        {


            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);

                String json = await response.Content.ReadAsStringAsync();
                SquareResult result = JsonConvert.DeserializeObject<SquareResult>(json);

                dotPattern = result.DotPattern;
                countnew = result.Count;
                braillename = result.Braille;
                int dotbraille = result.brailledot;

                count = Convert.ToString(countnew);
                string dotBraille = Convert.ToString(dotbraille);

                

                if (response.IsSuccessStatusCode)
                {
                    richTextBox1.Text = dotPattern;
                    textBox2.Text = count;  
                    richTextBox2.Text= braillename;
                    label7.Text = dotBraille;
                }
                else
                {
                    richTextBox1.Text = "Server Error";
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text = ex.Message;
                richTextBox2.Text = ex.Message;
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
            url = $"https://localhost:7286/WeatherForecast/text/{tex}";
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
            
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            if(countnew == 0)
            {
                MessageBox.Show("The first step is to create the initial Braille pattern using our software.");
            }
            else
            {
                //MoreDetails md = new MoreDetails(dotPattern, count);
                editPrinter ep = new editPrinter(dotPattern,braillename,countnew);
                ep.ShowDialog();
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void DoSomething()
        {
            // Perform some operation
            LoggerManager.Instance.Debug("DoSomething method called.");

            // Perform another operation
            LoggerManager.Instance.Info("Another operation performed.");
        }

    }

    public class LoggerManager
    {
        private static Logger logger;

        public static Logger Instance
        {
            get
            {
                if (logger == null)
                {
                    logger = LogManager.GetCurrentClassLogger();
                }
                return logger;
            }
        }
    }

    public class BrailleSystem
    {
        
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
