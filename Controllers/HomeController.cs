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
    // Same Name as DocType
    // RenderMvcController for displaying data
    public class HomeController : RenderMvcController
    {
        // Umbraco Template
        // GET: /Home/
        public ActionResult Home(RenderModel model)
        {
            // Get Model
            var homeModel = new HomeModel(model.Content, model.CurrentCulture);

            // Properties
            // header 
            homeModel.Logo = model.Content.GetPropertyValue<string>("logo");
            homeModel.PhoneNumber = model.Content.GetPropertyValue<string>("phoneNumber");

            // slider - dont use numbers
            homeModel.SlideOne = model.Content.GetPropertyValue<string>("slideOne");
            homeModel.SlideOneSmall = model.Content.GetPropertyValue<string>("slideOneSmall");
            homeModel.SlideTwo = model.Content.GetPropertyValue<string>("slideTwo");
            homeModel.SlideTwoSmall = model.Content.GetPropertyValue<string>("slideTwoSmall");
            homeModel.SlideThree = model.Content.GetPropertyValue<string>("slideThree");
            homeModel.SlideThreeSmall = model.Content.GetPropertyValue<string>("slideThreeSmall");

            // main body text
            homeModel.MainHeading = model.Content.GetPropertyValue<string>("mainHeading");
            homeModel.MainBody = model.Content.GetPropertyValue<string>("mainBody");

            // services
            homeModel.ServiceOne = model.Content.GetPropertyValue<string>("serviceOne");
            homeModel.ServiceTwo = model.Content.GetPropertyValue<string>("serviceTwo");
            homeModel.ServiceThree = model.Content.GetPropertyValue<string>("serviceThree");
            homeModel.ServiceFour = model.Content.GetPropertyValue<string>("serviceFour");

            // products
            homeModel.ProductOne = model.Content.GetPropertyValue<string>("productOne");
            homeModel.ProductOneHeading = model.Content.GetPropertyValue<string>("productOneHeading");
            homeModel.ProductOneText = model.Content.GetPropertyValue<string>("productOneText");
            homeModel.ProductTwo = model.Content.GetPropertyValue<string>("productTwo");
            homeModel.ProductTwoText = model.Content.GetPropertyValue<string>("productTwoText");
            homeModel.ProductThree = model.Content.GetPropertyValue<string>("productThree");
            homeModel.ProductThreeText = model.Content.GetPropertyValue<string>("productThreeText");
            homeModel.ProductFour = model.Content.GetPropertyValue<string>("productFour");
            homeModel.ProductFourText = model.Content.GetPropertyValue<string>("productFourText");

            // bundles
            homeModel.BundleOne = model.Content.GetPropertyValue<string>("bundleOne");
            homeModel.BundleTwo = model.Content.GetPropertyValue<string>("bundleTwo");
            homeModel.BundleThree = model.Content.GetPropertyValue<string>("bundleThree");

            // Changed from View to CurrentTemplate
            return CurrentTemplate(homeModel);
        }
    }
}
