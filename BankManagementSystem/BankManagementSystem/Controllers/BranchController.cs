using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BankManagementSystem.Controllers
{
    public class BranchController : Controller
    {
        private Bank_Management_System_Entities bms = new Bank_Management_System_Entities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(bms.BRANCHes.ToList());
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
            aBranch.BRANCH_MANAGER_PICTURE = System.IO.Path.GetFileName(BRANCH_MANAGER_PICTURE.FileName);
            aBranch.BRANCH_MANAGER_JOINDATE = DateTime.Now;

            if (ModelState.IsValid)
            {
                bms.BRANCHes.Add(aBranch);
                bms.SaveChanges();
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

            BRANCH aBranch = bms.BRANCHes.Find(ID);

            if (aBranch == null)
                return HttpNotFound();

            return View(aBranch);
        }
    }
}