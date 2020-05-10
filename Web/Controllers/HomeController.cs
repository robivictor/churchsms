using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using DataModels.Models;

namespace ChurchSMS_offline.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
       private ChurchSMSofflineContext db = new ChurchSMSofflineContext();

        
        public ActionResult Index()
        {
            var phone = db.PhoneStatus.Find(1);
            
            if (phone.LastConnected!=null)
            {
                var t = (DateTime.Now.Ticks - phone.LastConnected.Value.Ticks);
                ViewBag.PhoneStatus = t <= (13438310*5);
            }
            else
            {
                ViewBag.PhoneStatus = false;    
            }

            ViewBag.LastConnectedTime = phone.LastConnected;
            ViewBag.BatteryLevel = phone.BatteryLevel;
            ViewBag.OnCharge = phone.PowerMode != 0;
            ViewBag.SIMnumber = phone.SIM_Number;

            ViewBag.Contacts = db.Users.Count(t=>t.Status==1);
            ViewBag.New = db.Users.Count(t => t.Status == 3); 
            ViewBag.Groups = db.Groups.Count();

            //var msgstoday = db.Messages.Where(t=>t.RecievedTime.Equals)
            //var v = DateTime.Compare(DateTime.Today, DateTime.Today);
            var rt = db.MessageLogs.Where(t => t.Status == 1);
            //ViewBag.RecievedToday = db.MessageLogs.Count(t => 1 == DateTime.Compare(t.Time.Value.Date,DateTime.Today));
            ViewBag.SentToday = Enumerable.Count(db.Messages.Where(t=>t.Status==2), msg => msg.SentTime != null && 0 == DateTime.Compare(DateTime.Today, msg.SentTime.Value.Date)); 
            //var sent = db.Messages.Where(t => t.Status == 2);
            ViewBag.RecievedToday = Enumerable.Count(rt, msg => msg.Time != null && 0 == DateTime.Compare(DateTime.Today, msg.Time.Value.Date));

            //foreach (var message in sent.Where(message => message.SentTime.Value.Date == DateTime.Today))
            //{
            //}
            //int count = sent.Count(message => message.SentTime.Value.Date == DateTime.Today);
            //ViewBag.SentToday = sent.Count(message => message.SentTime.Value.Date == DateTime.Today);
            
            ViewBag.Unsent = db.Messages.Count(t => t.Status == 7); ;
            ViewBag.Resoultion = db.Resolutions.Count(e => e.Resolved == false);

            

            var activeSurvey = db.Surveys.FirstOrDefault(t => t.Status == 1);
            //ViewBag.Responded = 25;
            //ViewBag.Pending = 32;
            if (activeSurvey != null)
            {
               // var w = (activeSurvey.Questions.Count()) * (activeSurvey.Users1.Count()) - db.Answers.Count(t => t.Question.Survey_SurveyId == activeSurvey.SurveyId);
                //var w = ((activeSurvey.Questions.Count()) * (activeSurvey.Users1.Count()) - db.Answers.Count(t => t.Question.Survey_SurveyId == activeSurvey.SurveyId)) / (activeSurvey.Users1.Count());
                //ViewBag.Pending = w;
                //ViewBag.Responded = activeSurvey.Users1.Count - w;
                //ViewBag.ActiveSurvey = activeSurvey;
                var w = db.Answers.Count(t => t.Question.Survey_SurveyId == activeSurvey.SurveyId) / activeSurvey.Questions.Count();
                //s.Progress = ((survey.Users1.Count - w) / survey.Users1.Count) * 100;
                ViewBag.Pending = activeSurvey.Users1.Count - w;
                ViewBag.Responded = w;
                ViewBag.ActiveSurvey = activeSurvey;
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
      
    }
}