using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using MvcUmbraco.Models;
using Umbraco.Web;

namespace MvcUmbraco.Controllers
{
    public class ContactController : RenderMvcController
    {
        //
        // GET: /Contact/
        // Won't Allow Spaces
        public ActionResult Contact(RenderModel model)
        {
            var contactModel = new ContactInfoModel(model.Content, model.CurrentCulture);

            // Properties
            contactModel.Address = model.Content.GetPropertyValue<string>("address");
            contactModel.BodyText = model.Content.GetPropertyValue<string>("bodyText");

            // Changed from View to CurrentTemplate
            return CurrentTemplate(contactModel);

        }
    }
}
