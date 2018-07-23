namespace Processar.ProyectoAyudar.ReportesLibrary
{
    partial class frmVerEntregaBeneficiario
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.entregaPorBeneficiarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetBenefeciarios = new Processar.ProyectoAyudar.ReportesLibrary.DataSetBenefeciarios();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetBenefeciariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.entregaPorBeneficiarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBenefeciarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBenefeciariosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // entregaPorBeneficiarioBindingSource
            // 
            this.entregaPorBeneficiarioBindingSource.DataMember = "EntregaPorBeneficiario";
            this.entregaPorBeneficiarioBindingSource.DataSource = this.dataSetBenefeciarios;
            // 
            // dataSetBenefeciarios
            // 
            this.dataSetBenefeciarios.DataSetName = "DataSetBenefeciarios";
            this.dataSetBenefeciarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "Datos";
            reportDataSource2.Value = this.entregaPorBeneficiarioBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Processar.ProyectoAyudar.ReportesLibrary.ReporteEntregaBeneficiario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 261);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetBenefeciariosBindingSource
            // 
            this.dataSetBenefeciariosBindingSource.DataSource = this.dataSetBenefeciarios;
            this.dataSetBenefeciariosBindingSource.Position = 0;
            // 
            // frmVerEntregaBeneficiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmVerEntregaBeneficiario";
            this.Text = "Reporte de entregas por beneficiario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerEntregaBeneficiario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.entregaPorBeneficiarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBenefeciarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBenefeciariosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource entregaPorBeneficiarioBindingSource;
        private Processar.ProyectoAyudar.ReportesLibrary.DataSetBenefeciarios dataSetBenefeciarios;
        private System.Windows.Forms.BindingSource dataSetBenefeciariosBindingSource;
    }
}