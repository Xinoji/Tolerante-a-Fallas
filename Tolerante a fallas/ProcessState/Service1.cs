using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProcessState
{
    public partial class Status : ServiceBase
    {
        const string FilePath = "TAF.txt";
        const string ExePath = "C:\\Users\\DELL\\Desktop\\Tolerante a fallas\\Tolerante a fallas\\Checkpoints\\bin\\Debug\\net6.0-windows\\Checkpoints.exe";


        public Status()
        {
            InitializeComponent();
            proceso.StartInfo.FileName = ExePath;
            StartProcess();
        }

        protected override void OnStart(string[] args)
        {
            AddtoLog("Servicio Iniciado");
            
        }



        private void StartProcess()
        {
            try
            {
                proceso.Start();
                AddtoLog("Proceso Iniciado");

            }
            catch (Exception)
            {
                AddtoLog("No se encontro el proceso");
            }

            
        }

        protected override void OnStop()
        {
            AddtoLog("Servicio Terminado");
            proceso.Kill();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (proceso.HasExited)
            {
                AddtoLog("Proceso Cerrado");
                AddtoLog("Reiniciando Proceso...");
                StartProcess();
            }
            else 
            {
                AddtoLog("Proceso Aun Activo");
            }
        }

        void AddtoLog(string msg) 
        {
            var file = Path.GetTempPath() + FilePath;

            string Timestamp = DateTime.Now.ToString("[yyyy.MM.d H:m:ss]");

            if (!File.Exists(file))
                File.Create(file).Close();

            string log = Timestamp + " [INFO] " + msg + "\n";
            using (StreamWriter stream = new StreamWriter(file, append: true))
            {
                stream.WriteLine(log);
            }
        }
    }
}
