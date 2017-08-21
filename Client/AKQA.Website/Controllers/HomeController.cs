using AKQA.Website.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKQA.Website
{
    public class HomeController : Controller
    {
        private IConvertToWords _IConvertToWords;

        public HomeController(IConvertToWords IConvertToWords)
        {
            _IConvertToWords = IConvertToWords;
        }
        // GET: Default
        public ActionResult Index()
        {
            //var response = _IConvertToWords.GetConvertedNumber("Dhiraj", "123");
            return View();
        }

        public ActionResult ConvertNumber(ConvertedRequest _details)
        {
            if (ModelState.IsValid)
            {
                var response = _IConvertToWords.GetConvertedNumber(_details.Name, _details.Number);
                return View("Index", response);
            }
            return View("Index");
        }
    }
}