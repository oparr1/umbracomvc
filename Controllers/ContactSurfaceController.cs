using MvcUmbraco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using umbraco;
using Umbraco.Web.Mvc;

namespace MvcUmbraco.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        [HttpPost]
        public ActionResult ContactForm(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                // Message
                var sb = new StringBuilder();
                sb.AppendFormat("<p>Email: {0}</p>", model.CEmail);
                sb.AppendFormat("<p>Message: {0}</p>", model.Message);

                // Subject - Contact Us + Name
                var msg = new MailMessage();
                msg.Subject = "Contact Us - " + (model.FirstName + " " + model.LastName);

                // "From", "To", 
                library.SendMail("email", "email", msg.Subject, sb.ToString(), true);

                TempData["noticeOne"] = "Thank you for contacting us. We shall get back to you shortly!";
                return CurrentUmbracoPage();
            }
            else
            {
                TempData["noticeTwo"] = "Failed to submit your message. Please try again.";
                return CurrentUmbracoPage();
            }
        }
    }
}
