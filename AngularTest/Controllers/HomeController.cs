using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularTest.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace AngularTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Person_DBEntities db = new Person_DBEntities();

        public ActionResult Index()
        {
        
            return View();
        }
        [OutputCache(Duration =20)]
        public JsonResult LoadPerson()
        {

            
            return Json(db.Person.OrderByDescending(p=>p.ID).Select(a=>new
            { ID=a.ID,Name=a.Name,Family=a.Family,Age=a.Age }),JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult AddPerson(Person person)
        {
            db.Person.Add(person);
            db.SaveChanges();
            return LoadPerson();
        }
        [HttpGet]
        public JsonResult Delete(int ID)
        {
            var q = db.Person.Find(ID);
            db.Person.Remove(q);
            db.SaveChanges();
            return LoadPerson();
        }
        public JsonResult Range(int Rangtxt)
        {

            //var q1 = (from a in db.Person
            //          where a.Age <= Rangtxt
            //          select new  { ID = a.ID, Name = a.Name, Family = a.Family, Age = a.Age }).ToList();

            //return Json(q1, JsonRequestBehavior.AllowGet);
            return Json(db.Person.Where(p => p.ID<=Rangtxt).Select(a => new
            { ID = a.ID, Name = a.Name, Family = a.Family, Age = a.Age }), JsonRequestBehavior.AllowGet);
        }
    }
}