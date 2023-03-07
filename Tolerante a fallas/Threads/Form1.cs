using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace Threads
{
    public partial class main : Form
    {
        List<Thread> threads;
        public main()
        {
            InitializeComponent();
            threads = new List<Thread>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void threadTraceRoute(string Dest, bool feedback, string? file = null ) 
        {
            try
            {
                traceRoute(Dest, feedback, file);
            }
            catch (Exception e)
            {
                MessageBox.Show("Hilo Muerto, ocurrio un error: \n " + e.Message);
            }
        }

        private void traceRoute(string Dest, bool feedback, string? file = null) 
        {
            FileStream stream = null;

            const int timeout = 10000;
            const int maxTTL = 30;
            const int bufferSize = 32;
            List<byte> fileString = new List<byte>();
            byte[] buffer = new byte[bufferSize];
            new Random().NextBytes(buffer);
            List<(string ip,long ms)> jumps = new List<(string, long)>();
            Form2 form = null;

            if (feedback) 
            { 
                form = new Form2();
                form.Show();
            }

            using (var pinger = new Ping())
            {
                   
                for (int ttl = 1; ttl <= maxTTL; ttl++)
                { 
                    PingOptions options = new PingOptions(ttl, true);
                    
                    PingReply reply = pinger.Send(Dest, timeout, buffer, options);

                    foreach (char c in reply.Address.ToString())
                        fileString.Add(Convert.ToByte(c));

                    fileString.Add(Convert.ToByte('\n'));
                    
                    if (reply.Status == IPStatus.Success || reply.Status == IPStatus.TtlExpired) 
                    { 
                        jumps.Add((reply.Address.ToString(), reply.RoundtripTime));
                        if(form != null)
                            form.textBox1.Text += $"{reply.Address}\n";
                        form.Refresh();
                    }

                    if (reply.Status != IPStatus.TtlExpired && reply.Status != IPStatus.TimedOut) 
                         break;
                   
                }
                
            }
            string test = "";
    
            foreach (var jump in jumps)
                 test += $"{jump.ip}\n";
            test += "MS en traceroute:" + jumps.Last().ms;
            if (file != null)
            {
                stream = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
                stream.Write(fileString.ToArray(), 0, fileString.Count);
                stream.Close();
            }
            MessageBox.Show(test);

        }

        private string SaveFile() 
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Bloc de Notas|*.txt|cualquier archivo|*|TraceRoute File|*.trcrt";
            saveFileDialog1.Title = "Guardar TraceRoute";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
                throw new Exception("Error en la seleccion del archivo");

            return saveFileDialog1.FileNames[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string file = null;
            try 
            {
                if (checkBox1.Checked)
                    file = SaveFile();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }    

            (new Thread(() => threadTraceRoute(textBox1.Text, checkBox2.Checked, file))).Start();
           
        }
    }   
}