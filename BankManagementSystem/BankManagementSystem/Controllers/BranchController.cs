using BankManagementSystem.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BankManagementSystem.Controllers
{
    public class BranchController : Controller
    {
        private Bank_Management_System_Entities bmse = new Bank_Management_System_Entities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(bmse.BRANCHes.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BRANCH aBranch, HttpPostedFileBase BRANCH_MANAGER_PICTURE)
        {
            aBranch.BRANCH_MANAGER_PICTURE = Path.GetFileName(BRANCH_MANAGER_PICTURE.FileName);
            aBranch.BRANCH_MANAGER_JOINDATE = DateTime.Now;

            if (ModelState.IsValid)
            {
                bmse.BRANCHes.Add(aBranch);
                bmse.SaveChanges();
                BRANCH_MANAGER_PICTURE.SaveAs(Server.MapPath("../Uploads/Manager_Picture/" + aBranch.BRANCH_ID.ToString() + "_" + aBranch.BRANCH_MANAGER_PICTURE));
                return RedirectToAction("Index");
            }

            return View(aBranch);
        }

        [HttpGet]
        public ActionResult Edit(int? ID)
        {
            if (ID == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            BRANCH aBranch = bmse.BRANCHes.Find(ID);

            if (aBranch == null)
                return HttpNotFound();

            return View(aBranch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BRANCH aBranch, HttpPostedFileBase ManagerPicture)
        {
            aBranch.BRANCH_MANAGER_PICTURE = Path.GetFileName(ManagerPicture.FileName);
            aBranch.BRANCH_MANAGER_JOINDATE = DateTime.Now;

            if (ModelState.IsValid)
            {
                bmse.Entry(aBranch).State = EntityState.Modified;
                bmse.SaveChanges();                 
                ManagerPicture.SaveAs(Server.MapPath("../../Uploads/Manager_Picture/" + aBranch.BRANCH_ID.ToString() + "_" + aBranch.BRANCH_MANAGER_PICTURE));             
                return RedirectToAction("Index");                
            }

            return View(aBranch);
        }

        [HttpGet]
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            BRANCH aBranch = bmse.BRANCHes.Find(ID);

            if (aBranch == null)
                return HttpNotFound();

            return View(aBranch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ID)
        {
            BRANCH aBranch = bmse.BRANCHes.Find(ID);
            bmse.BRANCHes.Remove(aBranch);
            bmse.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}