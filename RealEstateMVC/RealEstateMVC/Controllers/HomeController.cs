using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateMVC.Models;

namespace RealEstateMVC.Controllers
{
    public class HomeController : Controller
    {
        RealEstateEntities db= new RealEstateEntities();
        // GET: Home
        
        public ActionResult Index()
        {
            return View();
        }
        [Route("forsale")]
        public ActionResult ForSale()

        {
            
            var model = db.Properties.Where(c => c.stateId == 2).Include(x => x.PropertyImages).ToList();
            return View(model);
        }
        [Route("forrent")]
        public ActionResult ForRent()
        {
            var model = db.Properties.Where(c=> c.stateId == 1).Include(x=>x.PropertyImages).ToList();
            return View(model);
        }
        [HttpGet]
        [Route("contact")]
        public ActionResult Contact()
        {

            return View();

        }
        [HttpPost]
        [Route("contact")]
        public ActionResult Contact(mail mail)
        {
            db.mails.Add(mail);
            db.SaveChanges();
            return RedirectToAction("/");

        }
        [Route("about")]
        public ActionResult About()
        {
            var model = db.ReferencesImages.ToList();
            return View(model);
        }
        [Route("agencies")]
        public ActionResult Agencies()
        {
            var model = db.Representers.Include(x => x.RepresenterImages).ToList();
            return View(model);
        }
        [Route("details")]
        public ActionResult Details(Property property)
        {
            var model = db.Properties.Where(c=>c.id == property.id).Include(x=>x.PropertyImages).ToList();
            return View(model);
        }
        [Route("searchbar")]
        public ActionResult SearchBar(Property property)
        {
            /* 1 li arama*/
            /* ----------------------------------------------------------------------------------------------------------------------------------------------------------- */
            if (property.city != null && property.district == null && property.m2 == 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId == 0)
            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                if (firstsearched.Count == 0 )
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(firstsearched);
                
            }
            else if (property.city == null && property.district != null && property.m2 == 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId == 0) 

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                if (firstsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(firstsearched);

            }
            else if (property.city == null && property.district == null && property.m2 != 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.m2 == property.m2).ToList();
                if (firstsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(firstsearched);
            }
            else if (property.city == null && property.district == null && property.m2 == 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                if (firstsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(firstsearched);
            }
            else if (property.city == null && property.district == null && property.m2 == 0 && property.numberofrooms == 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.floor == property.floor).ToList();
                if (firstsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(firstsearched);
            }
            else if (property.city == null && property.district == null && property.m2 == 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.stateId == property.stateId).ToList();
                if (firstsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(firstsearched);
            }

            /* 2 li arama*/
            /* ----------------------------------------------------------------------------------------------------------------------------------------------------------- */
            else if (property.city != null && property.district != null && property.m2 == 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city != null && property.district == null && property.m2 != 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city != null && property.district == null && property.m2 == 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city != null && property.district == null && property.m2 == 0 && property.numberofrooms == 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.floor == property.floor).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
             }
            else if (property.city != null && property.district == null && property.m2 == 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.stateId == property.stateId).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city == null && property.district != null && property.m2 != 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city == null && property.district != null && property.m2 == 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city == null && property.district != null && property.m2 == 0 && property.numberofrooms == 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.floor == property.floor).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city == null && property.district != null && property.m2 == 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.stateId == property.stateId).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city == null && property.district == null && property.m2 != 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.m2 == property.m2).ToList();
                var secondsearched = firstsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city == null && property.district == null && property.m2 != 0 && property.numberofrooms == 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.m2 == property.m2).ToList();
                var secondsearched = firstsearched.Where(c => c.floor == property.floor).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city == null && property.district == null && property.m2 != 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.m2 == property.m2).ToList();
                var secondsearched = firstsearched.Where(c => c.stateId == property.stateId).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city == null && property.district == null && property.m2 == 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var secondsearched = firstsearched.Where(c => c.floor == property.floor).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city == null && property.district == null && property.m2 == 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var secondsearched = firstsearched.Where(c => c.stateId == property.stateId).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }
            else if (property.city == null && property.district == null && property.m2 == 0 && property.numberofrooms == 0 && property.floor != 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.floor == property.floor).ToList();
                var secondsearched = firstsearched.Where(c => c.stateId == property.stateId).ToList();
                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(secondsearched);
            }

            /* 3 lü arama*/
            /* ----------------------------------------------------------------------------------------------------------------------------------------------------------- */
            else if (property.city != null && property.district != null && property.m2 != 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                var thirdsearched = secondsearched.Where(c => c.m2 == property.m2).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city != null && property.district != null && property.m2 == 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                var thirdsearched = secondsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city != null && property.district != null && property.m2 == 0 && property.numberofrooms == 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                var thirdsearched = secondsearched.Where(c => c.floor == property.floor).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city != null && property.district != null && property.m2 == 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                var thirdsearched = secondsearched.Where(c => c.stateId == property.stateId).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city != null && property.district == null && property.m2 != 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                var thirdsearched = secondsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city != null && property.district == null && property.m2 != 0 && property.numberofrooms == 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                var thirdsearched = secondsearched.Where(c => c.floor == property.floor).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city != null && property.district == null && property.m2 != 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                var thirdsearched = secondsearched.Where(c => c.stateId == property.stateId).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city != null && property.district == null && property.m2 == 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var thirdsearched = secondsearched.Where(c => c.floor == property.floor).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city != null && property.district == null && property.m2 == 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var thirdsearched = secondsearched.Where(c => c.stateId == property.stateId).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city != null && property.district == null && property.m2 == 0 && property.numberofrooms == 0 && property.floor != 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.floor == property.floor).ToList();
                var thirdsearched = secondsearched.Where(c => c.stateId == property.stateId).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city == null && property.district != null && property.m2 != 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                var thirdsearched = secondsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city == null && property.district != null && property.m2 != 0 && property.numberofrooms == 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                var thirdsearched = secondsearched.Where(c => c.floor == property.floor).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city == null && property.district != null && property.m2 != 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                var thirdsearched = secondsearched.Where(c => c.stateId == property.stateId).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city == null && property.district != null && property.m2 == 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var thirdsearched = secondsearched.Where(c => c.floor == property.floor).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city == null && property.district != null && property.m2 == 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var thirdsearched = secondsearched.Where(c => c.stateId == property.stateId).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city == null && property.district != null && property.m2 == 0 && property.numberofrooms == 0 && property.floor != 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.floor == property.floor).ToList();
                var thirdsearched = secondsearched.Where(c => c.stateId == property.stateId).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city == null && property.district == null && property.m2 != 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                var thirdsearched = secondsearched.Where(c => c.floor == property.floor).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city == null && property.district == null && property.m2 != 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                var thirdsearched = secondsearched.Where(c => c.stateId == property.stateId).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }
            else if (property.city == null && property.district == null && property.m2 == 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var secondsearched = firstsearched.Where(c => c.floor == property.floor).ToList();
                var thirdsearched = secondsearched.Where(c => c.stateId == property.stateId).ToList();

                if (thirdsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(thirdsearched);
            }

            /* 4 lü arama*/
            /* ----------------------------------------------------------------------------------------------------------------------------------------------------------- */
            else if (property.city != null && property.district != null && property.m2 != 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                var thirdsearched = secondsearched.Where(c => c.m2 == property.m2).ToList();
                var fourthsearched = thirdsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                if (fourthsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fourthsearched);
            }
            else if (property.city != null && property.district != null && property.m2 != 0 && property.numberofrooms == 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                var thirdsearched = secondsearched.Where(c => c.m2 == property.m2).ToList();
                var fourthsearched = thirdsearched.Where(c => c.floor == property.floor).ToList();
                if (fourthsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fourthsearched);
            }
            else if (property.city != null && property.district != null && property.m2 != 0 && property.numberofrooms == 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                var thirdsearched = secondsearched.Where(c => c.m2 == property.m2).ToList();
                var fourthsearched = thirdsearched.Where(c => c.stateId == property.stateId).ToList();
                if (fourthsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fourthsearched);
            }
            else if (property.city != null && property.district == null && property.m2 != 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var thirdsearched = secondsearched.Where(c => c.m2 == property.m2).ToList();
                var fourthsearched = thirdsearched.Where(c => c.floor == property.floor).ToList();
                if (fourthsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fourthsearched);
            }
            else if (property.city != null && property.district == null && property.m2 != 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var thirdsearched = secondsearched.Where(c => c.m2 == property.m2).ToList();
                var fourthsearched = thirdsearched.Where(c => c.stateId == property.stateId).ToList();
                if (fourthsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fourthsearched);
            }
            else if (property.city != null && property.district == null && property.m2 == 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var thirdsearched = secondsearched.Where(c => c.floor == property.floor).ToList();
                var fourthsearched = thirdsearched.Where(c => c.stateId == property.stateId).ToList();
                if (fourthsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fourthsearched);
            }
            else if (property.city == null && property.district != null && property.m2 != 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                var thirdsearched = secondsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var fourthsearched = thirdsearched.Where(c => c.floor == property.floor).ToList();
                if (fourthsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fourthsearched);
            }
            else if (property.city == null && property.district != null && property.m2 != 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                var thirdsearched = secondsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var fourthsearched = thirdsearched.Where(c => c.stateId == property.stateId).ToList();
                if (fourthsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fourthsearched);
            }
            else if (property.city == null && property.district != null && property.m2 == 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.floor == property.floor).ToList();
                var thirdsearched = secondsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var fourthsearched = thirdsearched.Where(c => c.stateId == property.stateId).ToList();
                if (fourthsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fourthsearched);
            }
            else if (property.city == null && property.district == null && property.m2 != 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.m2 == property.m2).ToList();
                var secondsearched = firstsearched.Where(c => c.floor == property.floor).ToList();
                var thirdsearched = secondsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var fourthsearched = thirdsearched.Where(c => c.stateId == property.stateId).ToList();
                if (fourthsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fourthsearched);
            }
            /* 5 li arama*/
            /* ----------------------------------------------------------------------------------------------------------------------------------------------------------- */
            else if (property.city == null && property.district != null && property.m2 != 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.district == property.district).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                var thirdsearched = secondsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var fourthsearched = thirdsearched.Where(c => c.floor == property.floor).ToList();
                var fifthsearched = firstsearched.Where(c => c.stateId == property.stateId).ToList();
               

                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fifthsearched);
            }
            else if (property.city != null && property.district == null && property.m2 != 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.m2 == property.m2).ToList();
                var thirdsearched = secondsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var fourthsearched = thirdsearched.Where(c => c.floor == property.floor).ToList();
                var fifthsearched = firstsearched.Where(c => c.stateId == property.stateId).ToList();


                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fifthsearched);
            }
            else if (property.city != null && property.district != null && property.m2 == 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                var thirdsearched = secondsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var fourthsearched = thirdsearched.Where(c => c.floor == property.floor).ToList();
                var fifthsearched = firstsearched.Where(c => c.stateId == property.stateId).ToList();


                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fifthsearched);
            }
            else if (property.city != null && property.district != null && property.m2 != 0 && property.numberofrooms == 0 && property.floor != 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                var thirdsearched = secondsearched.Where(c => c.m2 == property.m2).ToList();
                var fourthsearched = thirdsearched.Where(c => c.floor == property.floor).ToList();
                var fifthsearched = firstsearched.Where(c => c.stateId == property.stateId).ToList();


                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fifthsearched);
            }
            else if (property.city != null && property.district != null && property.m2 != 0 && property.numberofrooms != 0 && property.floor == 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                var thirdsearched = secondsearched.Where(c => c.m2 == property.m2).ToList();
                var fourthsearched = thirdsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var fifthsearched = firstsearched.Where(c => c.stateId == property.stateId).ToList();


                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fifthsearched);
            }
            else if (property.city != null && property.district != null && property.m2 != 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId == 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                var thirdsearched = secondsearched.Where(c => c.m2 == property.m2).ToList();
                var fourthsearched = thirdsearched.Where(c => c.floor == property.floor).ToList();
                var fifthsearched = firstsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();


                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(fifthsearched);
            }

            /* 6 lı arama*/
            /* ----------------------------------------------------------------------------------------------------------------------------------------------------------- */
            else if (property.city != null && property.district != null && property.m2 != 0 && property.numberofrooms != 0 && property.floor != 0 && property.stateId != 0)

            {
                var firstsearched = db.Properties.Where(c => c.city == property.city).ToList();
                var secondsearched = firstsearched.Where(c => c.district == property.district).ToList();
                var thirdsearched = secondsearched.Where(c => c.m2 == property.m2).ToList();
                var fourthsearched = thirdsearched.Where(c => c.numberofrooms == property.numberofrooms).ToList();
                var fifthsearched = firstsearched.Where(c => c.floor == property.floor).ToList();
                var sixthsearched = fifthsearched.Where(c => c.stateId == property.stateId).ToList();

                if (secondsearched.Count == 0)
                {
                    ViewBag.message = "Criterias does not match!";
                }
                return View(sixthsearched);
            }

            
                ViewBag.message = "You must enter at least one criteria!";
           

            return View();
        }

        
       
    }
}
