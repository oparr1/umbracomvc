using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace MvcUmbraco.Models
{
    public class HomeModel : RenderModel
    {
        public HomeModel(IPublishedContent content, CultureInfo culture) : base (content, culture )
        {
        }

        public HomeModel(IPublishedContent content) : base(content)
        {
        }

        public string Logo { get; set; }
        public string PhoneNumber { get; set; }

        public string SlideOne { get; set; }
        public string SlideOneSmall { get; set; }
        public string SlideTwo { get; set; }
        public string SlideTwoSmall { get; set; }
        public string SlideThree { get; set; }
        public string SlideThreeSmall{ get; set; }

        public string MainHeading { get; set; }
        public string MainBody { get; set; }

        public string ServiceOne { get; set; }
        public string ServiceTwo { get; set; }
        public string ServiceThree { get; set; }
        public string ServiceFour { get; set; }

        public string ProductOne { get; set; }
        public string ProductOneHeading { get; set; }
        public string ProductOneText { get; set; }
        public string ProductTwo { get; set; }
        public string ProductTwoText { get; set; }
        public string ProductThree { get; set; }
        public string ProductThreeText { get; set; }
        public string ProductFour { get; set; }
        public string ProductFourText { get; set; }

        public string BundleOne { get; set; }
        public string BundleTwo { get; set; }
        public string BundleThree { get; set; }

    }
}