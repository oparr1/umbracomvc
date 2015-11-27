using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using MvcUmbraco.Models;
using Umbraco.Web;
using System.Data.Linq.Mapping;

namespace MvcUmbraco.Controllers
{
    public class SqlQueryController : RenderMvcController
    {
        //
        // GET: /SqlQueryModel/
        [ActionName("Umb_SqlQuery")]
        public ActionResult SqlQuery(RenderModel model)
        {
            var sqlQueryModel = new SqlQueryModel(model.Content, model.CurrentCulture);

            // Properties
            // sqlQueryModel.oneValue = model.Content.GetPropertyValue<string>("oneValue");

            // Models add new class - linq to sql - inside SqlQueryDataContext
            SqlQueryDataContext db = new SqlQueryDataContext();

            // One Value
            sqlQueryModel.oneValue = (from p in db.countries
                                     where p.Name == "United Kingdom"
                                     select p.Name).Single();

            // One Row
            sqlQueryModel.oneRow = (from p in db.countries
                                 where p.Name == "United Kingdom"
                           select new country { Code = p.Code, Name = p.Name, Continent = p.Continent, Region = p.Region, SurfaceArea = p.SurfaceArea, Population = p.Population, LifeExpectancy = p.LifeExpectancy }).ToList();

            // One Column - Done
            sqlQueryModel.oneColumn = (from p in db.countries
                                           orderby p.Name ascending
                                           select new country {Name = p.Name}).Take(20).ToList();

            // Multiple Rows
            sqlQueryModel.multipleRows = (from p in db.countries
                                 where p.Name == "Netherlands" || p.Name == "United Kingdom" || p.Name == "Spain"
                                 select new country { Code = p.Code, Name = p.Name, Continent = p.Continent, Region = p.Region, SurfaceArea = p.SurfaceArea, Population = p.Population, LifeExpectancy = p.LifeExpectancy }).ToList();       

            // Aggregate
            sqlQueryModel.aggregates = (from p in db.countries
                                                where p.Continent == "Europe"
                                        select p.LifeExpectancy).Average().ToString();
            sqlQueryModel.aggregatesDecimal = String.Format("{0:0.00}", Decimal.Parse((sqlQueryModel.aggregates)));

            // Group By
            sqlQueryModel.groupBy = (from p in db.countries 
                                        group p by new {p.Continent, p.Region} into g
                                        orderby g.Count() descending
                                        select new country { Continent = g.Key.Continent, Region = g.Key.Region, Count = g.Count()}).ToList();

            // Join Table
            var joinQuery =
                from p in db.countries
                join c in db.countrylanguages on p.Code equals c.CountryCode
                select new country()
                {
                    Name = p.Name,
                    Continent = p.Continent,
                    IsOfficial = c.IsOfficial,
                    Language = c.Language,
                };

            var groups = joinQuery.Where(i => i.Continent == "Europe").Where(i => i.IsOfficial == "T").GroupBy(x => x.Name);

            sqlQueryModel.joinTable = groups.Select(group =>
                new country
                {
                    Name = group.Key,
                    Language = String.Join(",", group.Select(x => x.Language).ToArray()),
                }).ToList();
                                                  
            // Random Order
            sqlQueryModel.randomOrder = (from p in db.countries.AsEnumerable()
                                         where p.Name.StartsWith("C")
                                         orderby Guid.NewGuid()
                                         select new country { Name = p.Name }).ToList();

            // Changed from View to CurrentTemplate
            return CurrentTemplate(sqlQueryModel);

        }
    }
}
