using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace MvcUmbraco.Models
{
    public class TextPageModel : RenderModel
    {
        public TextPageModel(IPublishedContent content, CultureInfo culture) : base (content, culture )
        {
        }

        public TextPageModel(IPublishedContent content) : base(content)
        {
        }

        public string BodyText { get; set; }
    }
}