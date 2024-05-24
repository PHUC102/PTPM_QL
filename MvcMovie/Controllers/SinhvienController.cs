using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
 public class SinhvienController : Controller
 {
    public IActionResult Index()
    {
        return View();



    }
    [HttpPost]
    public IActionResult Index(Sinhvien sv)
    {
       string str0utput ="Xin chao" + sv.SinhvienId + "-" + sv.DiaChi + "-" + sv.Tuoi + "-" + sv.SDT;
       ViewBag.infoSinhvien = str0utput;

       return View();


    }
    
    

 }
}