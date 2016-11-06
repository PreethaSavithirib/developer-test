using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class PropertiesViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public PropertiesViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public PropertiesViewModel Build(PropertiesQuery query)
        {
            var properties = _context.Properties
                .Where(p => p.IsListedForSale);

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                properties = properties.Where(x => x.StreetName.Contains(query.Search) 
                    || x.Description.Contains(query.Search));
            }
            return new PropertiesViewModel
            {
                Properties = properties
                .Include(o => o.Offers)
                    .ToList()
                    .Select(MapViewModel)
                    .ToList(),

                Search = query.Search
            };
        }

        private static PropertyViewModel MapViewModel(Models.Property property)
        {
            var offers = new List<Common.OfferViewModel>();
            foreach (var o in property.Offers)
            {
                offers.Add(new Common.OfferViewModel { Amount = o.Amount, CreatedAt = o.CreatedAt, Id = o.Id, Status = o.Status.ToString(), OfferedBy= o.OfferedBy });
            }

            return new PropertyViewModel
            {
                Id = property.Id,
                StreetName = property.StreetName,
                Description = property.Description,
                NumberOfBedrooms = property.NumberOfBedrooms,
                PropertyType = property.PropertyType,
                Offers = offers
                };
        }
    }
}