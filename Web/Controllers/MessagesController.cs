using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using DataModels.Models;
using DataModels.ViewModels;
using Microsoft.Ajax.Utilities;

namespace ChurchSMS_offline.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private ChurchSMSofflineContext db = new ChurchSMSofflineContext();

        //
        // GET: /Messages/
        //[OutputCache(Duration = 30,VaryByParam = "none")]
        public ActionResult Index(int activetab = 1)
        {
            var messages = db.Messages.Include(m => m.User).Where(t => t.ParentGroup == null);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name");
            ViewBag.groupId = new SelectList(db.Groups, "GroupID", "GroupName");
            ViewBag.Subscribers = db.Users.Count(t => t.Status == 1);
            ViewBag.Active = activetab;
            //ViewBag.StatusID = new SelectList(db.MessageStatus, "MessageStatus", "Description");
            //participants
            //var res = db.Resolutions.ToList();
            ViewData["toberesolved"] = db.Resolutions.ToList();
            ViewData["MsgLog"] = db.MessageLogs.Where(s => s.Status == 1).OrderBy(t => t.Time).ToList();
            ViewData["GrMsg"] = GetGroupedMessages();
            return View(messages.ToList());
        }
        [HttpPost]
        public ActionResult Remove(int id)
        {
            //var user = db.Users.Find(id);
            //var i = user.User.GroupID;
            var item = db.Messages.Find(id);
            db.Messages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Clean(Guid id)
        {
            //var user = db.Users.Find(id);
            //var i = user.User.GroupID;
            var item = db.GroupedMessages.Find(id);
            var p = item.Messages.Count(t => t.Status == 7) > 0;
            if (p)
            {
                foreach (var message in item.Messages.Where(t => t.Status == 7).ToList())
                {
                    db.Messages.Remove(message);
                }
            }
            db.SaveChanges();

            return RedirectToAction("GroupedMessageDeatil", "Messages", new { id });
        }

        [HttpPost]
        public ActionResult GroupSms(int groupId, string msgBody)
        {
            var id = Guid.Empty;

            if (ModelState.IsValid)
            {
                var members = db.UserGroups.Where(g => g.GroupID == groupId);
                var group = db.Groups.Find(groupId);

                var groupedMessage = new GroupedMessage()
                {
                    GroupedMessageName = group.GroupName,
                    Type = 1,
                    Message = msgBody,
                    TrrigeredTime = DateTime.Now,
                    Id = Guid.NewGuid()
                };
                //db.SaveChanges();
                id = groupedMessage.Id;

                db.GroupedMessages.Add(groupedMessage);

                foreach (var member in members)
                {
                    var message = new Message
                    {
                        UserId = member.User.UserId,
                        msg_body = msgBody,
                        Status = 7,
                        ScheduledTime = DateTime.Now,
                        SentBy = User.Identity.Name,
                        ParentGroupID = groupedMessage.Id
                    };
                    groupedMessage.Messages.Add(message);
                }
                db.SaveChanges();

                return RedirectToAction("GroupedMessageDeatil", "Messages", new { id = groupedMessage.Id });
            }
            return RedirectToAction("GroupedMessageDeatil", "Messages", new { id = id });
        }

        [HttpPost]
        public ActionResult Broadcast(string msgBody)
        {
            var id = Guid.Empty;

            if (ModelState.IsValid)
            {
                var members = db.Users.Where(u => u.Status == 1);
                var broadcastMsg = new GroupedMessage()
                {
                    GroupedMessageName = "All",
                    Type = 2,
                    Message = msgBody,
                    TrrigeredTime = DateTime.Now,
                    Id = Guid.NewGuid()
                };

                db.GroupedMessages.Add(broadcastMsg);
                foreach (var member in members)
                {
                    var message = new Message
                    {
                        UserId = member.UserId,
                        msg_body = msgBody,
                        Status = 7,
                        ScheduledTime = DateTime.Now,
                        SentBy = User.Identity.Name,
                        ParentGroupID = broadcastMsg.Id
                    };
                    broadcastMsg.Messages.Add(message);
                }
                db.SaveChanges();

                return RedirectToAction("GroupedMessageDeatil", "Messages", new { id = broadcastMsg.Id });
            }
            return RedirectToAction("GroupedMessageDeatil", "Messages", new { id = id });
        }

        public ActionResult GroupedMessageDeatil(Guid id)
        {
            var grmsg = db.GroupedMessages.Find(id);
            if (grmsg.Messages != null)
            {
                var p = grmsg.Messages.Count(t => t.Status == 7);
                ViewBag.Pending = p;
                ViewBag.Delivered = grmsg.Messages.Count - p;
            }
            else
            {
                ViewBag.Pending = 0;
                ViewBag.Delivered = 0;
            }

            return View(grmsg);
        }

        [HttpPost]
        public JsonResult Percentage(Guid id)
        {
            var grmsg = db.GroupedMessages.Find(id);
            var p = 0;
            var d = 0;
            if (grmsg.Messages.Any())
            {
                p = grmsg.Messages.Count(t => t.Status == 7);
                d = grmsg.Messages.Count - p;

            }
            var f = new Dictionary<string, int> { { "delivered", d }, { "pending", p } };
            return Json(f, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public List<GroupedMessageViewModel> GetGroupedMessages()
        {
            var messages = db.GroupedMessages.Where(c => c.Type == 1 || c.Type == 2);
            var grmsgs = (from msg in messages
                          select new GroupedMessageViewModel()
                          {
                              ID = msg.Id,
                              Name = msg.GroupedMessageName,
                              Message = msg.Message,
                              Percentage = msg.Messages.Count > 0 ? msg.Messages.Count(t => t.Status != 7) * 100 / msg.Messages.Count : 0,
                              Count = msg.Messages.Count,
                              Type = msg.Type
                          }
              );
            return grmsgs.ToList();
        }

        [HttpPost]
        public ActionResult DeleteGroupedMessage(Guid id)
        {
            var grmsg = db.GroupedMessages.Find(id);
            db.GroupedMessages.Remove(grmsg);
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Comments()
        {
            var comments = db.MessageLogs.Where(c => c.Status == 6);
            return View(comments);
        }


        public ActionResult Prayer_requests(string id = null)
        {
            var requests = db.MessageLogs.Where(c => c.Status == 5);
            return View(requests);
        }


        [HttpPost]
        public void DeleteLog(int id)
        {
            var messagelog = db.MessageLogs.Find(id);
            db.MessageLogs.Remove(messagelog);
            db.SaveChanges();
        }

        [HttpPost]
        public void DeleteOut(int id)
        {
            var message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
        }
        //
        // GET: /Messages/Create


        //
        // GET: /Messages/Edit/5


        //
        // POST: /Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult Requests()
        {
            var p = db.ServiceCodes.Find(1);
            return Json(p.ServiceRequests.ToList(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}