using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ChurchSMS.Models;
using DataModels.Models;

namespace ChurchSMS_offline.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
       private ChurchSMSofflineContext db = new ChurchSMSofflineContext();

        //
        // GET: /Questions/Details/5

        public ActionResult Details(int id = 0)
        {
            var question = db.Questions.Find(id);
            
            if (question == null)
            {
                return HttpNotFound();
            }

            var answers = question.Answers.ToList();
            var ans = (from a in answers
                let timeStamp = a.TimeStamp
                where timeStamp != null
                select new AnswerViewModel()
                      {
                          AnswerId = a.AnswerId,
                          Participant = a.User.Name,
                          Phone = a.User.PhoneNumber,
                          Response = a.Response,
                          Time = (DateTime) timeStamp
                      });

            ViewData["Answers"] = ans.ToList();

            if (question.QAType.TypeId==1)
            {
                ViewBag.Yes = question.Answers.Count(t => t.AnswerType == 1);
                ViewBag.No = question.Answers.Count(t => t.AnswerType == 2);
            }

            return View(question);
        }

        [HttpPost]
        public ActionResult Create(QuestionPool questionpool)
        {
            if (ModelState.IsValid)
            {
                db.QuestionPools.Add(questionpool);
                db.SaveChanges();
                return RedirectToAction("Index", "Settings");
            }
            return RedirectToAction("Index", "Settings");
            //ViewBag.Type = new SelectList(db.QATypes, "TypeId", "Description", questionpool.Type);
        }

        [HttpPost]
        public void DeleteSurveyQuestion(int id)
        {
            var question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
        }

        [HttpPost]
        public void DeleteQuestionPool(int id)
        {
            var pool = db.QuestionPools.Find(id);
            db.QuestionPools.Remove(pool);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}