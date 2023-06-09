﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WebUI.Models.Mail;

namespace WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel adminMailViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("MimozaOtelAdmin", "manisamimozahotel@gmail.com"); //Kimden
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", adminMailViewModel.ReceiverMail);  //Kime
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = adminMailViewModel.Body;   //İçerik
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = adminMailViewModel.Subject;
            SmtpClient client = new SmtpClient();            //using Mailkiti kullandık
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("manisamimozahotel@gmail.com", "gxlbhihigwtcrnib");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();

        }
    }
}
