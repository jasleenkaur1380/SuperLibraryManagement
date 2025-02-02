using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.DAL.Context;
using Library.DTO.DBModels;

namespace SuperLibraryManagement.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            try
            {
              var ex=  DapperContext.ExeQueryList<Student>("select *from student");
            }
            catch (Exception ex)
            {   

                throw;
            }
            return View();
        } 
         
    }
}