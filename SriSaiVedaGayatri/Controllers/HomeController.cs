using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using SriSaiVedaGayatri.Models;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace SriSaiVedaGayatri.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Service()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Astrology")]
        public ActionResult Astrology_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Astrology")]
        public ActionResult Astrology_Post(Astrology astrology)
        {
            if (ModelState.IsValid)
            {
                Email email = new Email();
                email.fromEmail = astrology.Email;
                email.mailSubject = "Astrology";
                email.mailMessage = "FullName : " + astrology.FullName + "<br/>"
                                    + "Place Of Birth :" + astrology.PlaceOfBirth + "<br/>"
                                    + "Date Of Birth : " + astrology.DateOfBirth + "<br/>"
                                    + "Time Of Birth :" + astrology.TimeOfBirth + "<br/>"
                                    + "Phone Number : " + astrology.PhoneNumber + "<br/>"
                                    + "Email : " + astrology.Email;
                                    
                SendEmail(email);
            }
            else
            {
                return View();
            }
            return View("Index");
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Links()
        {
            return View();
        }
        
        [HttpGet]
        [ActionName("Contact")]
        public ActionResult Contact_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Contact")]
        public ActionResult Contact_Post(Contact contact)
        {
            if (ModelState.IsValid)
            {
                Email email = new Email();
                email.fromEmail = contact.Email;
                email.mailSubject = contact.Subject;
                email.mailMessage = "From : " + contact.FirstName + ", " + contact.LastName + "<br/>" 
                                              + "Phone : " + contact.PhoneNumber + "<br/>"
                                              + "Email : "+contact.Email+ "<br/><br/>" + contact.Message;
                SendEmail(email);
            }
            else
            {
                return View();
            }
            return View("Index");
        }

        public void SendEmail(Email email)
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(email.fromEmail);
            mailMessage.To.Add("saipriest@hotmail.com");
            mailMessage.CC.Add("vrksharma@sripooja.com");
            mailMessage.CC.Add("vrkspooja@hotmail.com");
            //mailMessage.Bcc.Add("praveendhatrika@gmail.com");
            mailMessage.Subject = email.mailSubject;
            mailMessage.Body = email.mailMessage;
            mailMessage.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Host = "relay-hosting.secureserver.net";
            client.Port = 25;
            
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = false;
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential
            {
                UserName = "vrksharma@sripooja.com",
                Password = "Sripooja2580"
            };

            
            client.Send(mailMessage);
        }
    }
}