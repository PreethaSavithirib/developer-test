using System.Data.Entity;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class ListPropertyCommandHandlerTest :BaseCommandHandlerTest
    {
        private ListPropertyCommandHandler _handler;        

        [SetUp]
        public void SetUp()
        {
            base.SetUp();    
            _handler = new ListPropertyCommandHandler(_context);
        }

        [Test]
        public void HandleShouldUpdatePropertyToBeListedForSale()
        {
            // Arrange
            var command = new ListPropertyCommand
            {
                PropertyId = 1
            };

            var property = GetMockProperty(description: "Test Property");            

            _properties.Find(1).Returns(property);

            // Act
            _handler.Handle(command);

            // Assert
            _context.Properties.Received(1).Find(1);
            _context.Received(1).SaveChanges();
            Assert.True(property.IsListedForSale);
        }
    }
}
