using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuikAid_T.Models;
using QuikAid_T.ViewModels;

namespace QuikAid_T.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Dashboard()
        {

            using (LoginDBEntities db = new LoginDBEntities())
            {
                return View(db.clientTables.ToList());

            }

        }
        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Create(clientTable c)
        {
            try
            {


                c.SSN = c.SSN.ToString();
                c.DOB = DateTime.Now;

                using (LoginDBEntities dbm = new LoginDBEntities())
                {

                    dbm.clientTables.Add(c);
                    dbm.SaveChanges();
                }
                return RedirectToAction("Dashboard", "Home");

            }
            catch
            {
                return RedirectToAction("Dashboard", "Home");

            }


            }

        public ActionResult DateRange(DateRangeViewModel dateRangeViewModel = null)
        {
            //using (LoginDBEntities db = new LoginDBEntities())
            //{
            //    DateRangeViewModel dateRangeViewModel = new DateRangeViewModel();
            //    dateRangeViewModel.ClientTable = db.clientTables.ToList();
            //    return View(dateRangeViewModel);
            //}
            return View();
        }
        [HttpPost]
        public ActionResult DateRangeO(DateRangeViewModel dateRangeViewModel)
        {
            var strt = dateRangeViewModel.FromDate;
            var end = dateRangeViewModel.ToDate;
            LoginDBEntities dbm = new LoginDBEntities();

            IEnumerable<clientTable> signatures = from p in dbm.clientTables
                                                  where p.DOB >= strt.Date && p.DOB <= end.Date
                                                  select p;

            dateRangeViewModel.ClientTable = signatures.ToList();

            return View("DateRange", dateRangeViewModel);
        }

        public ActionResult Edit(int id)
        {
            using (LoginDBEntities dbm = new LoginDBEntities())
            {
                return View(dbm.clientTables.Where(x => x.clientID == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Edit(int id, clientTable c)
        {
            try
            {
                using (LoginDBEntities dbm = new LoginDBEntities())
                {
                    dbm.Entry(c).State = EntityState.Modified;
                    dbm.SaveChanges();
                }



                return RedirectToAction("Dashboard", "Home");

            }
            catch (Exception e)
            {

                return RedirectToAction("Dashboard", "Home");
            }
        }

        public ActionResult Delete(int id)
        {
            using (LoginDBEntities dbm = new LoginDBEntities())
            {
                return View(dbm.clientTables.Where(x => x.clientID == id).FirstOrDefault());
            }

        }
        [HttpPost]

        public ActionResult Delete(int id, FormCollection colection)
        {
            try
            {
                using (LoginDBEntities dbm = new LoginDBEntities())
                {
                    clientTable c = dbm.clientTables.Where(x => x.clientID == id).FirstOrDefault();
                    dbm.clientTables.Remove(c);
                    dbm.SaveChanges();
                }



                return RedirectToAction("Dashboard", "Home");

            }
            catch (Exception e)
            {

                return RedirectToAction("Dashboard", "Home");
            }
        }

        public ActionResult AddPh()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPh(phoneTable p)
        {
            {
                try
                {

                    using (LoginDBEntities dbm = new LoginDBEntities())
                    {
                        dbm.phoneTables.Add(p);
                        dbm.SaveChanges();
                    }
                    return RedirectToAction("Dashboard", "Home");

                }
                catch (Exception e)
                {
                    return RedirectToAction("Dashboard", "Home");

                }


            }
        }

        public ActionResult GetData()
        {
            LoginDBEntities dbm = new LoginDBEntities();




            IEnumerable<MyClass> signatures = from p in dbm.phoneTables
                                             join c in dbm.clientTables on p.clientID equals c.clientID
                                             group p.phoneNumber by c.fname into g
                                             select new MyClass
                                             {
                                                 CountOfClients = g.Count(),
                                                 FirstName = g.Key
                                             };





            //g.GroupData = groupData;
            //var dg= data.Select(x=> new)
            return View(signatures);
            }
        ////public class Grp
        ////{
        ////    public Var GroupData { get; set; }
        ////}

        //public ActionResult Index()
        //{
        //    //string query = "SELECT c.firstName, c.lastName, p.clientID, COUNT(p.phoneNumber) TotalOrders";
        //    //query += " FROM phoneTable p join clientTable c GROUP BY c.firstName, c.lastName, p.clientID";



        //    return View();
        //}

        public ActionResult Detail(int id)
        {
            using (LoginDBEntities db = new LoginDBEntities())
            {
                return View(db.clientTables.Where(x => x.clientID == id).FirstOrDefault());

            }
        }


        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}