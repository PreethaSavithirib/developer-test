using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Models;
using System.Data.Entity;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    public class BaseCommandHandlerTest
    {
        protected IOrangeBricksContext _context;
        protected IDbSet<Models.Property> _properties;
        [SetUp]
        public void SetUp()
        {
             _context = Substitute.For<IOrangeBricksContext>();
            _properties = Substitute.For<IDbSet<Models.Property>>();
            _context.Properties.Returns(_properties);
        }

        [TearDown]
        public void TearDown()
        {
            if(_context!=null)
            {
                _context = null;

            }
        }

        protected Models.Property GetMockProperty(int propertyId=1, string description="", bool isListedForSale=false)
        {
            return new Models.Property { Id = propertyId, Description = description, IsListedForSale = isListedForSale };
        }
    }
}
