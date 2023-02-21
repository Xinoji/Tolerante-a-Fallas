namespace ProcessState
{
    partial class Installer1
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
            components = new System.ComponentModel.Container();
            this.processInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.processInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            
            this.serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            this.serviceInstaller.Description = "Servicio para la materia Tolerante a fallas";
            this.serviceInstaller.DisplayName = "Tolerante a Fallas";
            //
            // processInstaller
            //
            this.processInstaller.Password = null;
            this.processInstaller.Username = null;
            //
            // serviceInstaller
            //
            this.serviceInstaller.ServiceName = "ToleranteAFallas";
            //
            //
            //
            this.Installers.AddRange(new System.Configuration.Install.Installer[]
            {
                this.processInstaller,
                this.serviceInstaller
            });
            
        }

        #endregion
        private System.ServiceProcess.ServiceProcessInstaller processInstaller;
        private System.ServiceProcess.ServiceInstaller serviceInstaller;
            
    }
}