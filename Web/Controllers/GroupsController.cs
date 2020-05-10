using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DataModels.Models;

namespace ChurchSMS_offline.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
       private ChurchSMSofflineContext db = new ChurchSMSofflineContext();

        //
        // GET: /Groups/

        //
        // GET: /Groups/Details/5

        public ActionResult Details(int id = 0)
        {
            Group group = db.Groups.Find(id);

            var unadded = db.Users.ToList();

            foreach (var member in group.UserGroups)
            {
                unadded.Remove(member.User);
            }

            ViewBag.UserId = new SelectList(unadded, "UserId", "Name");
            //ViewBag.GroupId = new SelectList(db.Groups, "GroupID", "GroupName");
            
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        [HttpPost]
        public ActionResult GroupSms(int groupId, string msgBody)
        {
            if (ModelState.IsValid)
            {
                var members = db.UserGroups.Where(g => g.GroupID == groupId);
                var group = db.Groups.Find(groupId);

                var groupedMessage = new GroupedMessage()
                {
                    GroupedMessageName = group.GroupName,
                    Type = 1,
                    Message = msgBody,
                    Id = Guid.NewGuid()
                };
                db.SaveChanges();
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
                return RedirectToAction("Details", new { id = groupId });
            }
            return RedirectToAction("Details", new { id = groupId });
        }

        //
        // GET: /Groups/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Groups/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Group group)
        {
            if (ModelState.IsValid)
            {
                group.Status = 1;
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Groups", "Contacts");
            }

            return View(group);
        }

        //
        // GET: /Groups/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        //
        // POST: /Groups/Edit/5

        [HttpPost]
        public ActionResult Edit(Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Groups","Contacts");
            }
            return View(group);
        }

        //
        // GET: /Groups/Delete/5


        public ActionResult Remove(int groupId,int id = 0)
        {
            //var user = db.Users.Find(id);
            //var i = user.User.GroupID;
            var item = db.UserGroups.FirstOrDefault(g => g.GroupID == groupId && g.UserID==id);
            db.UserGroups.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Details", "Groups", new { id = groupId });
        }

      
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Disable(int id)
        {
            var group = db.Groups.Find(id);
            //db.Groups.Remove(group);
            group.Status = 2;
            db.SaveChanges();
            return RedirectToAction("Groups", "Contacts");
        }

        //
        // POST: /Groups/Delete/5

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
            db.SaveChanges();
            return Json(new {success = true}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void DeleteGroup(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
            db.SaveChanges();
        }

        [HttpPost]
        public ActionResult AddMember(int userId, int groupId)
        {
            if (ModelState.IsValid)
            {
                //var user = db.Users.Find(userId);
                //var group = db.Groups.Find(groupId);
                var userGroup = new UserGroup()
                {GroupID = groupId, RoleID = null, UserID = userId};
                db.UserGroups.Add(userGroup);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = groupId });
            }
            return RedirectToAction("Details", new { id = groupId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}