using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using MvcUmbraco.Models;
using System.Data.Linq.Mapping;

namespace MvcUmbraco.Models
{
    public class SqlQueryModel : RenderModel
    {
        public SqlQueryModel(IPublishedContent content, CultureInfo culture) : base (content, culture )
        {
        }
        
        public SqlQueryModel(IPublishedContent content) : base(content)
        {
        }

        public string oneValue { get; set; }
        public List<country> oneRow { get; set; }
        public List<country> oneColumn { get; set; }
        public List<country> multipleRows { get; set; }
        public string aggregates { get; set; }
        public string aggregatesDecimal { get; set; }
        public List<country> groupBy { get; set; }
        public List<country> joinTable { get; set; }
        public List<country> randomOrder { get; set; }
    }
}