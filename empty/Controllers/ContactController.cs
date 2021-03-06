﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using empty.Models;
using System.Net.Mail;
using System.Net;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace empty.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send(ContactMessageViewModel contactMessage)
        {
            SmtpClient client = new SmtpClient("poczta.o2.pl", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("gaijin00@o2.pl", "Pa$$w0rd2");
            client.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("gaijin00@o2.pl");
            mailMessage.To.Add("razudoks@gmail.com");
            mailMessage.Body = contactMessage.Content + Environment.NewLine + Environment.NewLine + contactMessage.SenderEmail;
            mailMessage.Subject = contactMessage.Title;
            client.Send(mailMessage);

            return RedirectToAction(nameof(Show), contactMessage);
        }

        public IActionResult Show(ContactMessageViewModel contactMessage)
        {
            return View(contactMessage);
        }
    }
}
