using LiveVideo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LiveVideo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost("save")]
        public async Task<IActionResult> SaveVideo([FromBody] VideoData videoData)
        {
            var filePath = Path.Combine("wwwroot", "videos", $"{videoData.User}_{DateTime.Now.Ticks}.webm");
            await System.IO.File.WriteAllBytesAsync(filePath, Convert.FromBase64String(videoData.Data));
            return RedirectToAction("Index");
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
