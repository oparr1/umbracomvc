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
    public class TextPageController : RenderMvcController
    {
        //
        // GET: /TextPage/
        // Won't Allow Spaces
        public ActionResult Subscribe(RenderModel model)
        {
            var textPageModel = new TextPageModel(model.Content, model.CurrentCulture);

            // Properties
            textPageModel.BodyText = model.Content.GetPropertyValue<string>("bodyText");

            // Changed from View to CurrentTemplate
            return CurrentTemplate(textPageModel);

        }
    }
}
