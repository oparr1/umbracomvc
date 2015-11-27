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
    public class AboutUsController : RenderMvcController
    {
        //
        // GET: /AboutUs/
        // Won't Allow Spaces
        // Use Umb_ to make it harder for users to land on alternate template until solution is found
        public ActionResult Umb_AboutUs(RenderModel model)
        {
            var aboutUsModel = new AboutUsModel(model.Content, model.CurrentCulture);

            // Properties
            aboutUsModel.BodyText = model.Content.GetPropertyValue<string>("bodyText");
            aboutUsModel.QuoteOne = model.Content.GetPropertyValue<string>("quoteOne");
            aboutUsModel.QuoteTwo = model.Content.GetPropertyValue<string>("quoteTwo");

            // Changed from View to CurrentTemplate
            return CurrentTemplate(aboutUsModel);
        }
    }
}
