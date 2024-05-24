using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class EmployeeController : Controller
{
    public IActionResult Index()
    {
        return View();

    }
[HttpPost]
public IActionResult Index(Employee ps )
{
    string str0utput ="Xin chao" + ps.EmployeeId + "-" + ps.FullName + "-" + ps.Age + "-" + ps.Luong;
    ViewBag.infoEmployee = str0utput;
    return View();

}
}
}