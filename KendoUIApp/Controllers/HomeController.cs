using KendoUIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Contact(EmailModel e)
    {
        if (ModelState.IsValid)
        {

            StringBuilder message = new StringBuilder();
            MailAddress from = new MailAddress(e.Email.ToString());
            message.Append("Name: " + e.Name + "\n");
            message.Append("Email: " + e.Email + "\n");
            message.Append("Telephone: " + e.Telephone + "\n\n");
            message.Append(e.Message);

            MailMessage mail = new MailMessage();

            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.mail.yahoo.com";
            smtp.Port = 465;

            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("jasonromerovt@yahoo.com", "KileyM2003");

            smtp.Credentials = credentials;
            smtp.EnableSsl = true;

            mail.From = from;
            mail.To.Add("jasonromerovt@yahoo.com");
            mail.Subject = "Test enquiry from " + e.Name;
            mail.Body = message.ToString();

            smtp.Send(mail);
        }
        return View();
    }
    public ActionResult Social()
    {
        return View();
    }
    public ActionResult About()
    {
        return View();
    }
}
