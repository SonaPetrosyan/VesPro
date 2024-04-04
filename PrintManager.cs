using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace ReportPrinter
{
    public class ReportManager
    {
        private ReportViewer _reportViewer;
        private IEnumerable<ReportParameter> parameters;

        public ReportManager()
        {
            _reportViewer = new ReportViewer();
        }
        public void PreviewReport(string reportName, string reportPath, DataTable data, Dictionary<string, object> parameters, string printerName)
        {

            _reportViewer.ProcessingMode = ProcessingMode.Local;
            _reportViewer.LocalReport.DataSources.Add(new ReportDataSource(reportName, data));
            _reportViewer.LocalReport.ReportPath = @reportPath;
           

            // Pass parameters to report if needed
            if (parameters != null && parameters.Count > 0)
            {
                List<ReportParameter> reportParameters = new List<ReportParameter>();
                foreach (var parameter in parameters)
                {
                    reportParameters.Add(new ReportParameter(parameter.Key, parameter.Value.ToString()));
                }
                _reportViewer.LocalReport.SetParameters(reportParameters);
            }
            _reportViewer.RefreshReport();
            // Show the report viewer in a form
            Form previewForm = new Form();
            _reportViewer.Dock = DockStyle.Fill;
            _reportViewer.ZoomMode = ZoomMode.PageWidth;
            previewForm.Controls.Add(_reportViewer);
            previewForm.WindowState = FormWindowState.Maximized;
            previewForm.ShowDialog();
            if (printerName != null)
            {
                PrinterSettings settings = new PrinterSettings();
                settings.PrinterName = printerName;
                _reportViewer.PrintDialog(settings); // Print the report on the specified printer
            }


        }
        //public void PreviewReport(string reportName, string reportPath, DataTable dataSource, Dictionary<string, object> parameters, object parameter)
        //{
        //    _reportViewer.ProcessingMode = ProcessingMode.Local;
        //    _reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetName", dataSource));
        //    _reportViewer.LocalReport.ReportPath = reportPath;

        //    // Set parameters for the report
        //    if (parameters != null && parameters.Count > 0)
        //    {
        //        List<ReportParameter> reportParameters = new List<ReportParameter>();
        //        foreach (var param in parameters)
        //        {
        //            reportParameters.Add(new ReportParameter(param.Key, param.Value.ToString()));
        //        }
        //        _reportViewer.LocalReport.SetParameters(reportParameters);
        //    }

        //    _reportViewer.RefreshReport();

        //    // Show the report viewer in a form
        //    Form previewForm = new Form();
        //    _reportViewer.Dock = DockStyle.Fill;
        //    _reportViewer.ZoomMode = ZoomMode.PageWidth;
        //    previewForm.Controls.Add(_reportViewer);
        //    previewForm.WindowState = FormWindowState.Maximized;
        //    previewForm.ShowDialog();
        //}


    }
}
