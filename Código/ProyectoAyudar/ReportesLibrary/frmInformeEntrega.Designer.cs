namespace Processar.ProyectoAyudar.ReportesLibrary
{
    partial class frmInformeEntrega
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.InformeEntregaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetBenefeciarios = new Processar.ProyectoAyudar.ReportesLibrary.DataSetBenefeciarios();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.InformeEntregaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBenefeciarios)).BeginInit();
            this.SuspendLayout();
            // 
            // InformeEntregaBindingSource
            // 
            this.InformeEntregaBindingSource.DataMember = "InformeEntrega";
            this.InformeEntregaBindingSource.DataSource = this.DataSetBenefeciarios;
            // 
            // DataSetBenefeciarios
            // 
            this.DataSetBenefeciarios.DataSetName = "DataSetBenefeciarios";
            this.DataSetBenefeciarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "datosEntrega";
            reportDataSource1.Value = this.InformeEntregaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Processar.ProyectoAyudar.ReportesLibrary.InformeEntrega.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 261);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmInformeEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInformeEntrega";
            this.Text = "frmInformeEntrega";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInformeEntrega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InformeEntregaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBenefeciarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource InformeEntregaBindingSource;
        private DataSetBenefeciarios DataSetBenefeciarios;
    }
}