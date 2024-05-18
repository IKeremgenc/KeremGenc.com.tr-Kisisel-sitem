using KeremCvTemplate.Entites.Dtos.EmailDtos;
using KeremCvTemplate.Mvc.Models;
using KeremCvTemplate.service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KeremCvTemplate.Mvc.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IMailService _mailService;

        public HomeController(IMailService mailService)
        {
            _mailService = mailService;
        }
   

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactSend(EmailSendDto emailSendDto)
        {
            if (ModelState.IsValid)
            {
                var result = _mailService.SendContactEmail(emailSendDto);
                if (result.ResultStatus == Shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
                {
                    TempData["Message"] = "Mesajınız için teşekkür ederiz. Gün içinde size dönüş yapacağız.";
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Mesaj gönderilirken bir hata oluştu.");
            }
           
            return View(emailSendDto);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
