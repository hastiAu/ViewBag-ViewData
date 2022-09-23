using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SO73752000.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SO73752000.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ActiveEmailResult result)
        {
            switch (result)
            {
                case ActiveEmailResult.Error:
                    ModelState.AddModelError("CustomError", "You Have Error ");
                    ViewData["AlertClass"] = "alert-danger";
                    break;

                case ActiveEmailResult.NotActive:
                    ModelState.AddModelError("CustomError", "You Are not Active. ");
                    ViewData["AlertClass"] = "alert-warning";
                    break;

                case ActiveEmailResult.Success:
                    ModelState.AddModelError("CustomError", "You Are Active ");
                    ViewData["AlertClass"] = "alert-success";
                    break;
            }

            return View();
        }


        public async Task<IActionResult> ActiveEmailAccount(ActiveEmailResult result)
        {
            if (ModelState.IsValid)

            {
         
                switch (result)
                {
                    case ActiveEmailResult.Error:
                        ModelState.AddModelError("CustomError", "کاربر عزیز، درخواست شما با خطا مواجه شد. ");
                      

                        break;

                    case ActiveEmailResult.NotActive:
                        ModelState.AddModelError("CustomError", "کاربر عزیز، حساب شما فعال نمی باشد. ");
                       
                        break;

                    case ActiveEmailResult.Success:
                        ModelState.AddModelError("CustomError", "کاربر عزیز، حساب شما با موفقیت فعال شد. ");
                
                        break;

                }

                ViewBag.active = result;

            }


            return View();

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
