using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class EmployeeeController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Index(Employeee bc)
        {
            string str0utput ="Xin chao" + bc.Name + "-" + bc.Tuoi + "-" + bc.sodienthoai +"-"+ bc.Address;
             ViewBag.infoShow = str0utput;
             return View();
        }




    }
}
