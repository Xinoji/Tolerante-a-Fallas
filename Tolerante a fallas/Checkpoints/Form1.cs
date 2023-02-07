namespace Checkpoints
{
    public partial class Form1 : Form
    {
        System.EventHandler evento;

        public Form1()
        {
            InitializeComponent();
            evento = new System.EventHandler(this.respaldar);
            button1.Click += evento;
            checkBackup();
        }

        private void checkBackup()
        {
            if (!File.Exists("backup.bin"))
                return;
            var dialog = MessageBox.Show("Obtener el respaldo para recuperar progreso?",
                                         "Respaldo",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
            
            if (!(dialog == DialogResult.Yes))
            {
                return;
            }

            object[,] data = ReadFromBinaryFile<object[,]>("backup.bin");

            for (int x = 0; x < data.GetLength(0); x++)
            {
                dataGridView1.Rows.Add();
                for (int y = 0; y < data.GetLength(1); y++)
                    dataGridView1.Rows[x].Cells[y].Value = data[x, y];
            }
                
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            throw new Exception();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index;
            index = dataGridView1.Rows.Add();
            var row = dataGridView1.Rows[index];
            row.Cells[0].Value = textBox1.Text;
            row.Cells[1].Value = textBox2.Text;
            row.Cells[2].Value = textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            File.Delete("backup.bin");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                button1.Click += evento;
                backup.Stop();
                progress.Stop();
                return;   
            }
            button1.Click -= evento;
            backup.Start();
            progress.Start();
        }

        private void respaldar(object sender, EventArgs e)
        {
            object[,] data = new object[dataGridView1.Rows.Count, dataGridView1.Columns.Count];
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
                for (int y = 0; y < dataGridView1.Columns.Count; y++)
                    data[x, y] = dataGridView1.Rows[x].Cells[y].Value;


            WriteToBinaryFile<object[,]>("backup.bin", data);

        }

        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar2.Value == progressBar2.Maximum)
            {
                progressBar2.Value = 0;
            }
            progressBar2.Value++;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            backup.Interval = (int)numericUpDown1.Value * 1000;
            progressBar2.Value = 0;
            progressBar2.Maximum = (int)numericUpDown1.Value;
        }
    }
}