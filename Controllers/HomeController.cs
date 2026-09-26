using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TqkLesson11_Db.Models;

namespace TqkLesson11_Db.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult HvtAbout()
        {
            ViewBag.HoTen = "Trần Quốc Khánh";
            ViewBag.MaSV = "2410900043";
            ViewBag.Lop = "K24CNT2";
            return View();
        }

        // Giữ URL cũ nếu đã được sử dụng ở nơi khác.
        public IActionResult TqkAbout() => RedirectToAction(nameof(HvtAbout));

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}