using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BankManagementSystem.Models;

namespace BankManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private Bank_Management_System_Entities bmse = new Bank_Management_System_Entities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(bmse.DEPARTMENTs.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


    }
}