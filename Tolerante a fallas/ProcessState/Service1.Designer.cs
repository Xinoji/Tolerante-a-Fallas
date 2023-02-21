namespace ProcessState
{
    partial class Status
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.proceso = new System.Diagnostics.Process();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // proceso
            // 
            this.proceso.StartInfo.Domain = "";
            this.proceso.StartInfo.LoadUserProfile = false;
            this.proceso.StartInfo.Password = null;
            this.proceso.StartInfo.StandardErrorEncoding = null;
            this.proceso.StartInfo.StandardOutputEncoding = null;
            this.proceso.StartInfo.UserName = "";
            // 
            // Status
            // 
            this.ServiceName = "Service1";

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Diagnostics.Process proceso;
    }
}
