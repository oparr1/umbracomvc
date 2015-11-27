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
    public class SubscribeController : RenderMvcController
    {
        //
        // GET: /Subscribe/
        // Won't Allow Spaces
        public ActionResult Subscribe(RenderModel model)
        {
            var subscribeModel = new SubscribeThanksModel(model.Content, model.CurrentCulture);

            // Properties
            subscribeModel.BodyText = model.Content.GetPropertyValue<string>("bodyText");

            // Changed from View to CurrentTemplate
            return CurrentTemplate(subscribeModel);

        }
    }
}
