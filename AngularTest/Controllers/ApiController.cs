using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularTest.Models;

namespace AngularTest.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        Person_DBEntities db = new Person_DBEntities();
        
        public JsonResult LoadPerson()
        {

            return Json(db.Person.OrderByDescending(p => p.ID).Select(a => new
            { ID = a.ID, Name = a.Name, Family = a.Family, Age = a.Age }).ToList());
        }
        public JsonResult AddPerson(Person person)
        {
            db.Person.Add(person);
            db.SaveChanges();
            return LoadPerson();
        }
    }
}
