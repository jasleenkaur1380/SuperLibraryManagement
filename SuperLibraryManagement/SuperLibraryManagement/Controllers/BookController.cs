using Library.BAL.Interface;
using Library.BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperLibraryManagement.Controllers
{
    public class BookController : Controller
    {
        //private readonly IBook _repo;


        //public BookController(IBook repo)
        //{
        //    _repo = repo;
        //}
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayBook()
        {
            BookServices bookServices = new BookServices();
            bookServices.GetallBooks();

            return View();
        }
        
    }
}