namespace Processar.ProyectoAyudar.ReportesLibrary
{
    partial class frmInformeAutorizacion
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetBenefeciarios = new Processar.ProyectoAyudar.ReportesLibrary.DataSetBenefeciarios();
            this.EntregaPorBeneficiarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InformeAutorizacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBenefeciarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntregaPorBeneficiarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformeAutorizacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "datosOrden";
            reportDataSource3.Value = this.EntregaPorBeneficiarioBindingSource;
            reportDataSource4.Name = "datosAutorizacion";
            reportDataSource4.Value = this.InformeAutorizacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Processar.ProyectoAyudar.ReportesLibrary.InformeAutorizacion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 261);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetBenefeciarios
            // 
            this.DataSetBenefeciarios.DataSetName = "DataSetBenefeciarios";
            this.DataSetBenefeciarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // EntregaPorBeneficiarioBindingSource
            // 
            this.EntregaPorBeneficiarioBindingSource.DataMember = "EntregaPorBeneficiario";
            this.EntregaPorBeneficiarioBindingSource.DataSource = this.DataSetBenefeciarios;
            // 
            // InformeAutorizacionBindingSource
            // 
            this.InformeAutorizacionBindingSource.DataMember = "InformeAutorizacion";
            this.InformeAutorizacionBindingSource.DataSource = this.DataSetBenefeciarios;
            // 
            // frmInformeAutorizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInformeAutorizacion";
            this.Text = "frmInformeAutorizacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInformeAutorizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBenefeciarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntregaPorBeneficiarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformeAutorizacionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EntregaPorBeneficiarioBindingSource;
        private DataSetBenefeciarios DataSetBenefeciarios;
        private System.Windows.Forms.BindingSource InformeAutorizacionBindingSource;
    }
}