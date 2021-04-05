
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempManager.Models;

namespace TempManager.Controllers
{
    public class ValidationController : Controller
    {
        private TempManagerContext context;
        public ValidationController(TempManagerContext ctx) => context = ctx;

        public JsonResult CheckDate(string date)
        {
            DateTime dateTime = Convert.ToDateTime(date);
            var check = context.Temps.FirstOrDefault(
                t => t.Date == dateTime);
            if (check == null)
            {
                return Json(true);
            }
            else
            {
                return Json("Date already entered.");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}