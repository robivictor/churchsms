using System.Linq;
using System.Web.Mvc;
using DataModels.Exporting;
using DataModels.Models;

namespace ChurchSMS_offline.Controllers
{
    [Authorize]
    public class ExportController : Controller
    {
        private ChurchSMSofflineContext db = new ChurchSMSofflineContext();
        //
        // GET: /Reports/

        public FileResult Export(int surveyID)
        {
            var surveyview = db.SurveyViews.Where(s=>s.SurveyId==surveyID);
            var reportPath = Server.MapPath("~/Exports/Survey_view.rdlc");
            var report = surveyview.ToList();
            var reportData = report;
            const string dataSourceName = "Survey";
            //var result = ReportHelper.Print(reportPath);
            var result = ExportHelper.PrintReport(reportPath, reportData, dataSourceName, false);
            return File(result.RenderBytes, result.MimeType);
        }
    }
}
