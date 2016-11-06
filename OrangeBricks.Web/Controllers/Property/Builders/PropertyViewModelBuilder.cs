using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class PropertyViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public PropertyViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to map db Model to View Model.
        /// </summary>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public PropertyViewModel Build(int propertyId)
        {
            var property = _context.Properties.Find(propertyId);
            return new PropertyViewModel
            {
                 Id = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                NumberOfBedrooms = property.NumberOfBedrooms,
                Description = property.Description               
            };
        }
    }
}