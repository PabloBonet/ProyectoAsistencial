namespace Processar.ProyectoAyudar.ReportesLibrary
{
    partial class frmOrdenEntrega
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
            this.ordenEntregaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetBenefeciarios = new Processar.ProyectoAyudar.ReportesLibrary.DataSetBenefeciarios();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ordenEntregaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBenefeciarios)).BeginInit();
            this.SuspendLayout();
            // 
            // InformeEntregaBindingSource
            // 
            this.ordenEntregaBindingSource.DataMember = "OrdenEntrega";
            this.ordenEntregaBindingSource.DataSource = this.DataSetBenefeciarios;
            // 
            // DataSetBenefeciarios
            // 
            this.DataSetBenefeciarios.DataSetName = "DataSetBenefeciarios";
            this.DataSetBenefeciarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "datosOrden";
            reportDataSource1.Value = this.ordenEntregaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Processar.ProyectoAyudar.ReportesLibrary.OrdenEntrega.rdlc";
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
            this.Name = "frmOrdenEntrega";
            this.Text = "frmOrdenEntrega";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOrdenEntrega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordenEntregaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBenefeciarios)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

      
        private System.Windows.Forms.BindingSource ordenEntregaBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetBenefeciarios DataSetBenefeciarios;
    }
}