using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ChurchSMS.Models;
using DataModels.Models;

namespace ChurchSMS_offline.Controllers
{
    [Authorize]
    public class ResolutionController : Controller
    {
       private ChurchSMSofflineContext db = new ChurchSMSofflineContext();
        private readonly MessageValidate _mv = new MessageValidate();

        //
        // GET: /Resolution/
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Resolution resolution = db.Resolutions.Find(id);
            db.Resolutions.Remove(resolution);
            db.SaveChanges();
            return Json(new {success = true}, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Resolution/Delete/5

        public ActionResult Resolve(int id = 0)
        {
            var resolution = db.Resolutions.Find(id);
            
            var questions = resolution.Survey.Questions.ToList();
            ViewData["Questions"] = questions.ToList();

            if (resolution == null)
            {
                return HttpNotFound();
            }
            return View(resolution);
        }

        [HttpPost]
        public ActionResult Resolve(int ResolutionID, List<QAViewModel> answers)
        {
            var resolution = db.Resolutions.Find(ResolutionID);

            if (ModelState.IsValid)
            {
                db.Entry(resolution).State = EntityState.Modified;
                var num = 0;
                foreach (var question in resolution.Survey.Questions) {
                   
                    var A = new Answer();
                   
                    //A.AnswerType = question.QuestionType;
                    if (question.QuestionType == 2)
                    {
                        A.AnswerType = 3;
                        A.Response = answers[num].Value;
                    }
                    else if(answers[num].Value.ToLower().Contains("yes")){
                        A.AnswerType = 1;
                        A.Response = "Yes";
                    }
                    else if (answers[num].Value.ToLower().Contains("no")) {
                        A.AnswerType = 2;
                        A.Response = "No";
                    }
                   
                    A.User_UserId = (int)resolution.UserId;
                    A.TimeStamp = resolution.Time;
                    question.Answers.Add(A);
                    resolution.Resolved = true;
                    num++;
                }

                db.SaveChanges();
                return RedirectToAction("Index","Messages");
            }
            //ViewBag.SurveyID = new SelectList(db.Surveys, "SurveyId", "SurveyName", resolution.SurveyID);
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "Name", resolution.UserId);
            return View(resolution);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}