using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DataModels.Models;

namespace ChurchSMS_offline.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
       private ChurchSMSofflineContext db = new ChurchSMSofflineContext();

        //
        // GET: /Services/

        public ActionResult Index()
        {
            return View(db.ServiceCodes.ToList());
        }

        public ActionResult Services()
        {

            return Json(db.ServiceCodes.ToList(),JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Services/Details/5

        public ActionResult Details(int id = 0)
        {
            ServiceCode servicecode = db.ServiceCodes.Find(id);
            if (servicecode == null)
            {
                return HttpNotFound();
            }
            return View(servicecode);
        }

        //
        // GET: /Services/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Services/Create

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(ServiceCode servicecode)
        {
            if (ModelState.IsValid)
            {
                servicecode.Type = 2;
                if (db.ServiceCodes.Any(t=>t.Code.ToLower().Equals(servicecode.Code.ToLower())))
                {
                    ViewBag.Error = "A service with code '"+servicecode.Code+"' already exists. Please use a different one.";
                    return View(servicecode);
                }
                db.ServiceCodes.Add(servicecode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicecode);
        }

        //
        // GET: /Services/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ServiceCode servicecode = db.ServiceCodes.Find(id);
            if (servicecode == null)
            {
                return HttpNotFound();
            }
            return View(servicecode);
        }

        //
        // POST: /Services/Edit/5

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceCode servicecode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicecode).State = EntityState.Modified;
                //if (db.ServiceCodes.Any(t => t.Code.ToLower().Equals(servicecode.Code.ToLower())))
                //{
                //    ViewBag.Error = "A service with code '" + servicecode.Code + "' already exists. Please use a different one.";
                //    return View(servicecode);
                //}
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicecode);
        }

        //
        // GET: /Services/Delete/5
    
        [HttpPost]
        public JsonResult Delete(int id = 0)
        {
            ServiceCode servicecode = db.ServiceCodes.Find(id);
            //if (servicecode == null)
            //{
                //servicecode = db.ServiceCodes.Find(id);
                db.ServiceCodes.Remove(servicecode);
                db.SaveChanges();
            return Json(new {success = true}, JsonRequestBehavior.AllowGet);
            //}
            //return View(servicecode);
        }

        public ActionResult RemoveRequest(int id = 0)
        {
            var request = db.ServiceRequests.Find(id);
            //if (servicecode == null)
            //{
            //servicecode = db.ServiceCodes.Find(id);
            db.ServiceRequests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
            //}
            //return View(servicecode);
        }

        //
        // POST: /Services/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceCode servicecode = db.ServiceCodes.Find(id);
            db.ServiceCodes.Remove(servicecode);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}