using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Drawing;
using System.Web.Query.Dynamic;
using DataModels;
using DataModels.Models;
using DataModels.ViewModels;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChurchSMS_offline.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private ChurchSMSofflineContext db = new ChurchSMSofflineContext();

        //
        // GET: /Contacts/

        public ActionResult Index()
        {
            var u = db.Users.ToList();
            //var d = u.First().Address.Subcity;
            return View(db.Users.ToList());
        }

        public ActionResult Members()
        {
            var u = db.Users.ToList();
            return View(u);
        }

        //
        // GET: /Contacts/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //
        // GET: /Contacts/Create
        [HttpPost]
        public JsonResult UploadFile(int id=0)
        {
            //var r = new List<ViewDataUploadFilesResult>();
            var s = Request.Params.Get("avatar_src");
            var r = Request.Params.Get("avatar_data");
            var d = Request.Files.Get("avatar_file");

            //var fie = new Image("",true);

            foreach (string file in Request.Files)
            {
                var hpf = Request.Files[file];
                if (hpf != null && hpf.ContentLength == 0)
                    continue;
                var n=Guid.NewGuid().ToString()+".jpg";
                var savedFileName = Path.Combine(
                   AppDomain.CurrentDomain.BaseDirectory,path2:"profiles",path3:Path.GetFileName(n));

                hpf.SaveAs(savedFileName);

                var user = db.Users.First(t => t.UserId == id);
                user.ImagePath = n;
                db.SaveChanges();

            }

            //var cropper = new CropAvatar(s,r,d);
            //cropper.GetMsg();
            //cropper.GetResult();
           // var html = r.First().Content;
            //var p = new PredefinedCvModel();

            //p.FirstName = _indexingService.Search(html, Constants.FIRSTNAME);
            //p.MiddleName = _indexingService.Search(html, Constants.MIDDLENAME);
            //p.LastName = _indexingService.Search(html, Constants.LASTNAME);
            //dynamic rst = new DynamicDictionary();
            //rst.
            //{
            //    state= 200,
            //    message= 'good',
            //    result= 'result'
            //};

            return Json(new{}, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            return View();
        }

        //
        // POST: /Contacts/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            user.Status = 1;
            
            if (ModelState.IsValid)
            {
                char[] a = { ' ', '(', ')', '-' };
                var t = user.PhoneNumber.Split(a);
                var d = t.Aggregate(String.Empty, (current, s1) => current + s1);
                var fullnumber = "+251" + d;
                ViewBag.Error = "";
                if (db.Users.Any(n => n.PhoneNumber == fullnumber))
                {
                    ViewBag.Error = String.Format("A contact with the Phone number {0} already exists", fullnumber);
                    return View();
                }
                user.PhoneNumber = "+251" + d;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Contactaddress(Address address, int userId)
        {
            var member = db.Users.Find(userId);
            if (ModelState.IsValid)
            {
                if (member.Address != null)
                {
                    member.Address.Subcity = address.Subcity;
                    member.Address.Subrub = address.Subrub;
                    member.Address.Kebele = address.Kebele;
                    member.Address.HouseNumber = address.HouseNumber;
                    member.Address.Country = address.Country;
                    member.Address.City = address.City;
                    member.Address.WorkPhone = address.WorkPhone;
                    member.Address.HomePhone = address.HomePhone;
                    member.Address.Post = address.Post;
                    member.Address.Email = address.Email;
                    member.Address.Facebook = address.Facebook;
                    member.Address.Twitter = address.Twitter;

                    //db.Entry(a0ddress).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Edit", "Contacts", new { id = userId, activetab = 2 });
                }
                else
                {   //var member = db.Users.Find(userId);
                    address.UserId = userId;
                    member.Address = address;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Edit", "Contacts", new { id = userId, activetab = 2 });
            //return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ContactHistory(History history, int userId)
        {
            var member = db.Users.Find(userId);
            if (ModelState.IsValid)
            {
                if (member.History != null)
                {
                    member.History.SalvationDate = history.SalvationDate;
                    member.History.OriginalChurch = history.OriginalChurch;
                    member.History.BabtisimDate = history.BabtisimDate;
                    member.History.JoiningReason = history.JoiningReason;
                    member.History.WithOfficialLetter = history.WithOfficialLetter;
                    member.History.LetterReason = history.LetterReason;
                    member.History.JoinedDate = history.JoinedDate;
                    
                    //db.Entry(address).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Edit", "Contacts", new { id = userId, activetab = 4 });
                }
                else
                {   //var member = db.Users.Find(userId);
                    history.UserId = userId;
                    member.History = history;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Edit", "Contacts", new { id = userId, activetab = 4 });
            //return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Contacts/Edit/5

        public ActionResult Edit(int id = 0, int activetab = 1)
        {
            User user = db.Users.Find(id);
            var s  = db.Users.OrderBy(t => t.UserId).ToList();
            if (user == null)
            {
                return HttpNotFound();
            }
            var leftEnd = s.LastOrDefault(t => t.UserId < id);
            if (leftEnd != null)
                ViewBag.Previous = leftEnd.UserId;

            var rightStart = s.FirstOrDefault(t => t.UserId > id);
            if (rightStart != null)
                ViewBag.Next = rightStart.UserId;

            ViewBag.Active = activetab;
            ViewBag.Status = new SelectList(db.UsersStatus, "UsersStatusId", "Description", user.Status);
            ViewBag.OccupationID = new SelectList(db.Occupations, "Id", "Title", user.OccupationID);
            return View(user);
        }

        public ActionResult Groups()
        {
            return View(db.Groups.Where(t => t.Status == 1).ToList());
        }

        public ActionResult MessageHistory(int id)
        {
            return View(db.Users.Find(id));
        }
        
        public ActionResult Details(int id)
        {
            return View(db.Users.Find(id));
        }

        //
        // POST: /Contacts/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;

                char[] a = { ' ', '(', ')', '-' };
                var t = user.PhoneNumber.Split(a);
                var d = t.Aggregate(String.Empty, (current, s1) => current + s1);
                var fullnumber = "+251" + d;
                user.PhoneNumber = fullnumber;

                db.SaveChanges();
                
            }
            ViewBag.Status = new SelectList(db.UsersStatus, "UsersStatusId", "Description", user.Status);
            ViewBag.OccupationID = new SelectList(db.Occupations, "Id", "Title", user.OccupationID);
            return RedirectToAction("Edit", "Contacts", new { activetab = 1 });
        }

        //
        // GET: /Contacts/Delete/5

        //
        // POST: /Contacts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Disable(int id)
        {
            User user = db.Users.Find(id);
            user.Status = 2;
            //db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void Enable(int id)
        {
            User user = db.Users.Find(id);
            user.Status = 1;
            //db.Users.Remove(user);
            db.SaveChanges();
        }

        [HttpPost]
        public void Approve(int id)
        {
            User user = db.Users.Find(id);
            user.Status = 1;
            //db.Users.Remove(user);
            db.SaveChanges();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}