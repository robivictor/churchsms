using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Antlr.Runtime.Misc;
using ChurchSMS.Models;
using ChurchSMS_offline.Models;
using DataModels.Models;
using DataModels.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace ChurchSMS_offline.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {

         public SettingsController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

         public SettingsController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        
        private ChurchSMSofflineContext db = new ChurchSMSofflineContext();
        
        
        [Authorize(Roles = "admin")]
        public ActionResult Useraccounts()
        {
            //var accounts = db.AspNetUsers;
            var context = new ApplicationDbContext();
            var accounts = context.Users.ToList();
            var users = new List<UserAccountViewModel>();
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            
            foreach (var account in accounts)
            {
                var a = new UserAccountViewModel()
                {
                    UserName = account.UserName,
                    IsAdmin = UserManager.IsInRole(account.Id, "admin"),
                    IsCurrent = account.Id.Equals(UserManager.FindById(User.Identity.GetUserId()).Id)
                };
                users.Add(a);
            }
            return View(users);
        }

        public ActionResult Lookups(int active=1)
        {
            ViewBag.Active = active;
            return View();
        }


        [HttpPost]
        public JsonResult DeleteAccount(string username)
        {
            var account = db.AspNetUsers.First(u => u.UserName == username);
            db.AspNetUsers.Remove(account);
            db.SaveChanges();
            return Json(new {success = true}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RoleChanger(string username)
        {
            //var user = new ApplicationUser() { UserName = username };
           // var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = UserManager.FindByName(username);
            
            if (UserManager.IsInRole(currentUser.Id,"admin"))
            {
                UserManager.RemoveFromRole(currentUser.Id, "admin");
            }
            else
            {
                UserManager.AddToRole(currentUser.Id, "admin");
            }
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            //Questions
            ViewBag.Qty = db.QuestionPools.Count();
            
            var questions = db.QuestionPools.ToList();

            var qs = (from q in questions
                      select new QuestionPoolViewModel()
                      {
                          QuestionPoolID = q.QuestionPoolID,
                          Question = q.Question,
                          Type = q.QAType.Description,
                      });

            ViewData["Questions"] = qs.ToList();

            ViewData["Questions"] = qs.ToList();

            ViewBag.Type = new SelectList(db.QATypes, "TypeId", "Description");
            return View();
        }

    }
}