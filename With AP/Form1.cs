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
            string w = numericUpDown1.Text;
            string h = numericUpDown2.Text;
            String url;
            

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    url = $"https://localhost:44341/WeatherForecast/rectangle/{w}/{h}";
                    GetApi(url);
                    break;

                case 1:
                    url = $"https://localhost:44341/WeatherForecast/circle/{w}/{h}";
                    GetApi(url);
                    break;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void GetApi(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                string dotPattern = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    richTextBox1.Text = dotPattern;
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

        
    }
}