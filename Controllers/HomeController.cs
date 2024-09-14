using Microsoft.AspNetCore.Mvc;
using RSA.Models;
using System.Diagnostics;

namespace RSA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(SecEntity secEntity)
        {
            return View(secEntity);
        }
        public IActionResult GenerateKey(SecEntity details)
        {
            details.KeysLocation = InfoSec.GenerateKey(details.KeyName);

            return RedirectToAction("Index", details);
        }

        public IActionResult Encrypt(SecEntity details)
        {
            (details.CipherText, details.TimeToEncrypt) = InfoSec.Encrypt(details.PlainText, details.KeyName);

            return RedirectToAction("Index", details);
        }

        public IActionResult Decrypt(SecEntity details)
        {
            (details.CipherToPlainText, details.TimeToDecrypt) = InfoSec.Decrypt(details.CipherText, details.KeyName);

            return RedirectToAction("Index", details);
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
