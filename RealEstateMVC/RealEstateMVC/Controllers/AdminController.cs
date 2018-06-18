using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using RealEstateMVC.Models;

namespace RealEstateMVC.Controllers
{   [Authorize]
    public class AdminController : Controller
    {
        RealEstateEntities db = new RealEstateEntities();
        
        
        public ActionResult Index()
        {
            var model = db.Properties.ToList();
            return View(model);
        }
        
        [HttpPost]
        
        public ActionResult CreateNewProperty(Property property)
        {
            if (property.id==0)
            {
                db.Properties.Add(property);
            }
            else
            {
                var updateProperty = db.Properties.Find(property.id);
                if (updateProperty == null)
                {
                    return HttpNotFound();
                }

                updateProperty.district = property.district;
                updateProperty.adress = property.adress;
                updateProperty.explanation = property.explanation;
                updateProperty.floor = property.floor;
                updateProperty.numberofrooms = property.numberofrooms;
                updateProperty.price = property.price;
                updateProperty.stateId = property.stateId;
                updateProperty.city = property.city;
                updateProperty.m2 = property.m2;

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult CreateNewProperty()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult CreateNewUser()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateNewUser(User user)
        {
            if (user.id == 0)
            {
                db.Users.Add(user);
            }
            else
            {
                var updateProperty = db.Users.Find(user.id);
                if (updateProperty == null)
                {
                    return HttpNotFound();
                }

                updateProperty.username = user.username;
                updateProperty.password = user.password;
                updateProperty.role = user.role;
            }

            
            db.SaveChanges();
            return RedirectToAction("ListUsers");
        }
        
        
        public ActionResult ListUsers()
        {
            var model = db.Users.ToList();
            return View(model);
        }

        
        [HttpGet]
        public ActionResult CreateNewAgency()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateNewAgency(Representer representers)
        {
            if (representers.id == 0)
            {
                db.Representers.Add(representers);
            }
            else
            {
                var updateProperty = db.Representers.Find(representers.id);
                if (updateProperty == null)
                {
                    return HttpNotFound();
                }

                updateProperty.name = representers.name;
                updateProperty.surname = representers.surname;
                updateProperty.email = representers.email;
                updateProperty.phone = representers.phone;
            }

           
            db.SaveChanges();
            return RedirectToAction("ListAgency");
        }
     

        public ActionResult ListAgency()
        {
            var model = db.Representers.ToList();
            return View(model);
        }
        
        
        public ActionResult UpdateProperties(Property prop)
        {
            var model = db.Properties.Find(prop.id);
            if (model == null)
            {
                HttpNotFound();
            }
            return View("CreateNewProperty",model);
        }

        public ActionResult DeleteProperties(int id)
        {
            var model = db.Properties.Find(id);
            
            if (model == null)
                
            {
                HttpNotFound();
            }
            db.Properties.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateAgency(Representer rep)
        {
            var model = db.Representers.Find(rep.id);
            if (model == null)
            {
                HttpNotFound();
            }
            return View("CreateNewAgency",model);
        }
        public ActionResult DeleteAgency(int id)
        {
            var model = db.Representers.Find(id);

            if (model == null)

            {
                HttpNotFound();
            }
            db.Representers.Remove(model);
            db.SaveChanges();
            return RedirectToAction("ListAgency");
        }
        public ActionResult UpdateUser(User user)
        {
            var model = db.Users.Find(user.id);
            if (model == null)
            {
                HttpNotFound();
            }
            return View("CreateNewUser",model);
        }
        public ActionResult DeleteUser(int id)
        {
            var model = db.Users.Find(id);

            if (model == null)

            {
                HttpNotFound();
            }
            db.Users.Remove(model);
            db.SaveChanges();
            return RedirectToAction("ListUsers");
        }
        [HttpPost]
        public ActionResult AddPictureProperty(PropertyImage pic)
        {

            if (pic.image != null)
            {
                db.PropertyImages.Add(pic);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddPictureProperty()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AddPictureAgency(RepresenterImage rep)
        {
            if (rep.image != null)
            {
                db.RepresenterImages.Add(rep);
                db.SaveChanges();
            }
            return RedirectToAction("ListAgency");
        }
        [HttpGet]
        public ActionResult AddPictureAgency()
        {
            return View();
        }
    }
}