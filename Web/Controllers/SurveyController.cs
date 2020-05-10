using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ChurchSMS.Models;
using DataModels.Models;
using DataModels.ViewModels;

namespace ChurchSMS_offline.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
       private ChurchSMSofflineContext db = new ChurchSMSofflineContext();

        //
        // GET: /Survey/

        public ActionResult Index()
        {
            var surveys = new List<SurveyViewModel>();
            foreach (var survey in db.Surveys)
            {
                var s = new SurveyViewModel {SurveyId = survey.SurveyId, Name = survey.SurveyName};
                
                if (!survey.Questions.Any() || !survey.Users1.Any())
                {
                    s.Progress = 0;
                }else{
                    //var ws = ((survey.Questions.Count()) * (survey.Users1.Count()) - db.Answers.Count(t => t.Question.Survey_SurveyId == survey.SurveyId)) / (survey.Users1.Count());
                    //ViewBag.Pending = ws;
                    //ViewBag.Responded = survey.Users1.Count - ws;

                    //var w = ((survey.Questions.Count()) * (survey.Users1.Count()) - db.Answers.Count(t => t.Question.Survey_SurveyId == survey.SurveyId)) / (survey.Users1.Count());
                    var w =db.Answers.Count(t => t.Question.Survey_SurveyId == survey.SurveyId)/survey.Questions.Count();
                    //s.Progress = ((survey.Users1.Count - w) / survey.Users1.Count) * 100;
                    s.Progress = ((decimal)w / survey.Users1.Count * 100);
                }
                s.Questions = survey.Questions.Count;
                s.Participants = survey.Users1.Count;
                if (survey.Status != null) s.Status = (int)survey.Status;
                s.Description = survey.SurveyStatu.Description;
                surveys.Add(s);
            }
            return View(surveys);
        }

        //
        // GET: /Survey/Details/5

        public ActionResult Details(int id = 0)
        {
            Survey survey = db.Surveys.Find(id);
            var questions = survey.Questions.ToList();

            ViewBag.UserId = new SelectList(db.Users.Where(u => u.Status == 1), "UserId", "Name");
            ViewBag.QuestionId = new SelectList(db.QuestionPools, "QuestionPoolID", "Question");
            ViewBag.GroupId = new SelectList(db.Groups.Where(g => g.Status == 1), "GroupID", "GroupName");

            var qs = (from q in questions
                      select new QuestionViewModel
                      {
                          QuestionId = q.QuestionId,
                          Question = q.Question1,
                          Type = q.QAType.Description,
                          Responded = q.Answers.Count
                      });
            ViewData["Questions"] = qs.ToList();


            //participants
            var participants = survey.Users1.ToList();
            var ps = (from p in participants
                      select new ParticipantViewModel
                      {
                          UserId = p.UserId,
                          Name = p.Name,
                          Phone = p.PhoneNumber,
                          Description = p.Description,
                          Status = db.Answers.Any(s => s.Question.Survey_SurveyId == survey.SurveyId && s.User.UserId == p.UserId)
                      });

            ViewData["Participants"] = ps.ToList();

            //var r = db.Answers.Count(t => t.Question.Survey_SurveyId == survey.SurveyId) / survey.Questions.Count;
            if (survey.Users1.Any()) { 
            //var w = ((survey.Questions.Count()) * (survey.Users1.Count()) - db.Answers.Count(t => t.Question.Survey_SurveyId == survey.SurveyId)) / (survey.Users1.Count());
            var w = db.Answers.Count(t => t.Question.Survey_SurveyId == survey.SurveyId) / survey.Questions.Count();
            //s.Progress = ((survey.Users1.Count - w) / survey.Users1.Count) * 100;
            ViewBag.Pending = survey.Users1.Count-w;
            ViewBag.Responded = w;
               // s.Progress = ((decimal)w / survey.Users1.Count * 100);
            }
            return View(survey);
        }

        //
        // GET: /Survey/Create

        public ActionResult Create()
        {
            //ViewBag.Project_Id = new SelectList(db.Projects, "Id", "ProjectName");
            return View();
        }

        //
        // POST: /Survey/Create

        [HttpPost]
        public ActionResult Create(Survey survey)
        {
            survey.Status = 3;

            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = survey.SurveyId });
            }

            //ViewBag.Project_Id = new SelectList(db.Projects, "Id", "ProjectName", survey.Project_Id);
            return View(survey);
        }

        //
        // GET: /Survey/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
           // ViewBag.Status = new SelectList(db.SurveyStatus, "SurveyStatusID", "Description", survey.Status);
            return View(survey);
        }

        public void Close(int id = 0)
        {
            var survey = db.Surveys.Find(id);
            survey.Status = 2;
            //Set this survey as current survey for all its participants
            foreach (var user in survey.Users1)
            {
                survey.Users.Remove(user);
            }
            db.SaveChanges();
        }

        //
        // POST: /Survey/Edit/5

        [HttpPost]
        public ActionResult Edit(Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                //Set the participants current survey
                // var sur = db.Surveys.Find(survey.SurveyId);
                
                //if (survey.Status == 1)
                //{
                //    foreach (var su in db.Surveys.Where(s => s.SurveyId != survey.SurveyId && s.Status == 1))
                //    {
                //        su.Status = 4;
                //    }
                //}
                db.SaveChanges();
                //db.Entry(survey).State=EntityState.Unchanged;
                return RedirectToAction("Details","Survey", new{id=survey.SurveyId});
            }

            //var sur = db.Surveys.Find(survey.SurveyId);
            ////Set this survey as current survey for all its participants
            //foreach (var user in sur.Users1)
            //{
            //    sur.Users.Add(user);
            //}

           // ViewBag.Status = new SelectList(db.SurveyStatus, "SurveyStatusID", "Description", survey.Status);
            return View(survey);
        }
        //Activate
        public ActionResult Activate(int id = 0)
        {
            var survey = db.Surveys.Find(id);
            foreach (var su in db.Surveys.Where(s => s.SurveyId != survey.SurveyId && s.Status == 1))
            {
                su.Status = 4;
            }
            survey.Status = 1;
            var sur = db.Surveys.Find(survey.SurveyId);
            //Set this survey as current survey for all its participants
            foreach (var user in sur.Users1)
            {
                sur.Users.Add(user);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddParticipant(int userId, int surveyId)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(userId);
                var survey = db.Surveys.Find(surveyId);
                survey.Users1.Add(user);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = surveyId });
            }
            return RedirectToAction("Details", new { id = surveyId });
        }

        [HttpPost]
        public ActionResult DeleteParticipant(int userId, int surveyId)
        {
            if (!ModelState.IsValid) return RedirectToAction("Details", new { id = surveyId });
            var user = db.Users.Find(userId);
            var survey = db.Surveys.Find(surveyId);
            survey.Users1.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = surveyId });
        }

        [HttpPost]
        public ActionResult AddQuestion(int questionId, int surveyId)
        {
            if (!ModelState.IsValid) return RedirectToAction("Details", new { id = surveyId });
            var question = db.QuestionPools.Find(questionId);
            var survey = db.Surveys.Find(surveyId);
            var q = new Question()
            {
                QuestionType = question.Type,
                Survey_SurveyId = surveyId,
                Question1 = question.Question
            };
            survey.Questions.Add(q);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = surveyId });
        }

        [HttpPost]
        public ActionResult AddGroup(int groupId, int surveyId)
        {
            if (!ModelState.IsValid) return RedirectToAction("Details", new { id = surveyId });
            var users = db.UserGroups.Where(g=>g.GroupID == groupId && g.User.Status==1);
            var survey = db.Surveys.Find(surveyId);
            foreach (var user in users)
            {
                survey.Users1.Add(user.User);
            }
            db.SaveChanges();
            return RedirectToAction("Details", new { id = surveyId });
        }
        //[HttpPost]
        public ActionResult Resend(int userid, int surveyid)
        {
            var survey = db.Surveys.Find(surveyid);
            var user = db.Users.Find(userid);
            survey.Users.Add(user);

            var msg = survey.Questions.Aggregate("", (current, question) => current + question.Question1);

            var m = new Message()
            {
                UserId = user.UserId,
                msg_body = msg,
                Status = 7,
                ScheduledTime = DateTime.Now
            };
            db.Messages.Add(m);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = surveyid });
        }

        public ActionResult ResendAll(int surveyid)
        {
            var survey = db.Surveys.Find(surveyid);
            //var user = db.Users.Find(userid);
            //survey.Users.Add(user);

            var participants = survey.Users1.ToList();
            var ps = (from p in participants
                      select new ParticipantViewModel
                      {
                          UserId = p.UserId,
                          Name = p.Name,
                          Phone = p.PhoneNumber,
                          Description = p.Description,
                          Status = db.Answers.Any(s => s.Question.Survey_SurveyId == survey.SurveyId && s.User.UserId == p.UserId)
                      });

            var msg = survey.Questions.Aggregate("", (current, question) => current + question.Question1);

            foreach (var m in ps.Where(r=>r.Status==false).Select(p => new Message()
            {
                UserId = p.UserId,
                msg_body = msg,
                Status = 7,
                ScheduledTime = DateTime.Now
            }))
            {
                db.Messages.Add(m);
                db.SaveChanges();
            }
            
            return RedirectToAction("Details", new { id = surveyid });
        }

        [HttpPost]
        public ActionResult SendMessage(string msg, int id)
        {
            if (!ModelState.IsValid) return RedirectToAction("Details", new { id = id });
            var survey = db.Surveys.Find(id);
            var users = survey.Users1;

            //Set the participants current survey
            foreach (var user in users)
            {
                survey.Users.Add(user);
            }

            foreach (var user in users)
            {
                var m = new Message()
                {
                    UserId = user.UserId,
                    msg_body = msg,
                    Status = 7,
                    ScheduledTime = DateTime.Now
                };
                db.Messages.Add(m);
                db.SaveChanges();
            }

            //Make the survey active one
            survey.Status = 1;
            foreach (var s in db.Surveys.Where(y => y.SurveyId != id && y.Status == 1))
            {
                s.Status = 4;
            }
            db.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }

        public JsonResult QuestionsToMessage(int id)
        {
            var s = new object();
            var questions = db.Surveys.Find(id).Questions;
            var qs = (from question in questions
                      select question.Question1
                     );
            return Json(qs, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Survey/Delete/5

        

        [HttpPost]
        public void DeleteSurvey(int id)
        {
            var survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}