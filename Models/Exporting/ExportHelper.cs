using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WebForms;

namespace DataModels.Exporting
{
    public static class ExportHelper
    {
        public static ExportObject PrintReport(string reportPath, object[] data, string[] dataSourceName)
        {
            return PrintReport(reportPath, data, dataSourceName, "PDF");
        }

        public static ExportObject PrintReport(string reportPath, object[] data, string[] dataSourceName, string reportType)
        {
            var localReport = new LocalReport { ReportPath = reportPath };

            for (int i = 0; i < data.Count(); i++)
            {
                var reportDataSource = new ReportDataSource(dataSourceName[i], data[i]);
                localReport.DataSources.Add(reportDataSource);
            }

            string mimeType;
            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx

            var deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>" + reportType + "</OutputFormat>" +
            "  <PageWidth>8.27in</PageWidth>" +
            "  <PageHeight>11.69in</PageHeight>" +
            "  <MarginTop>0in</MarginTop>" +
            "  <MarginLeft>0in</MarginLeft>" +
            "  <MarginRight>0in</MarginRight>" +
            "  <MarginBottom>0in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;

            //Render the report
            var renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
                );

            var result = new ExportObject
            {
                RenderBytes = renderedBytes,
                MimeType = mimeType
            };
            return result;
        }
        public static ExportObject PrintReport(string reportPath, object data, string dataSourceName, bool isPdf = true, bool isPortriat = true)
        {
            var localReport = new LocalReport { ReportPath = reportPath };

            var reportDataSource = new ReportDataSource(dataSourceName, data);
            localReport.DataSources.Add(reportDataSource);

            var reportType = isPdf ? "PDF" : "Excel";
            var pageLayout = isPortriat
                                    ? "  <PageWidth>8.5in</PageWidth> <PageHeight>11in</PageHeight> "
                                    : "  <PageWidth>11in</PageWidth> <PageHeight>8.5in</PageHeight> ";
            string mimeType;
            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx
            var deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>" + reportType + "</OutputFormat>" +
           pageLayout +
            "  <MarginTop>1in</MarginTop>" +
            "  <MarginLeft>0.25in</MarginLeft>" +
            "  <MarginRight>0.25in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;

            //Render the report
            var renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
                );

            var result = new ExportObject
            {
                RenderBytes = renderedBytes,
                MimeType = mimeType
            };
            return result;
        }


        public static ExportObject Print(string reportPath)
        {
            var localReport = new LocalReport { ReportPath = reportPath };

            //var reportDataSource = new ReportDataSource(dataSourceName, data);
            //localReport.DataSources.Add(reportDataSource);

            const string reportType = "PDF";
            //var pageLayout = isPortriat
            //                      ? "  <PageWidth>8.5in</PageWidth> <PageHeight>11in</PageHeight> "
            //                    : "  <PageWidth>11in</PageWidth> <PageHeight>8.5in</PageHeight> ";

            string mimeType;
            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx
            const string deviceInfo = "<DeviceInfo>" +
                                      "  <OutputFormat>" + reportType + "</OutputFormat>" +
                                      "<PageWidth>11.69in</PageWidth> <PageHeight>8.27in</PageHeight>" +
                                      "  <MarginTop>1in</MarginTop>" +
                                      "  <MarginLeft>0.25in</MarginLeft>" +
                                      "  <MarginRight>0.25in</MarginRight>" +
                                      "  <MarginBottom>0.5in</MarginBottom>" +
                                      "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;

            //Render the report
            var renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
                );

            var result = new ExportObject
            {
                RenderBytes = renderedBytes,
                MimeType = mimeType
            };
            return result;
        }
    }
}