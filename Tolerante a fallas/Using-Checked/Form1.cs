namespace Using_Checked
{
    public partial class Form1 : Form
    {
        int num = int.MaxValue;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                    num = checked((int)num + 1);
                else
                    num = unchecked((int)num + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sucedio un error : {ex.Message}");
                throw;
            }
            textBox1.Text = num.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                    num = unchecked((int)num - 1);
                else
                    num = unchecked((int)num - 1);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sucedio un error : {ex.Message}");
                throw;
            }
            textBox1.Text = num.ToString(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = num.ToString();
        }

    }
}