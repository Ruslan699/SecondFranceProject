namespace Papastreet.JobRunner
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.JobRunnerProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.JobRunnerServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // JobRunnerProcessInstaller
            // 
            this.JobRunnerProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.JobRunnerProcessInstaller.Password = null;
            this.JobRunnerProcessInstaller.Username = null;
            // 
            // JobRunnerServiceInstaller
            // 
            this.JobRunnerServiceInstaller.ServiceName = "JobService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.JobRunnerProcessInstaller,
            this.JobRunnerServiceInstaller});

        }

        #endregion
        public System.ServiceProcess.ServiceProcessInstaller JobRunnerProcessInstaller;
        public System.ServiceProcess.ServiceInstaller JobRunnerServiceInstaller;
    }
}