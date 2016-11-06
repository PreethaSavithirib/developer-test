using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using System;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
   public class BookingViewCommandHandlerTest : BaseCommandHandlerTest
    {
        private BookingViewCommandHandler _handler;
        [SetUp]
        public void Setup()
        {
            base.SetUp();
            _handler = new BookingViewCommandHandler(_context);
        }
        [Test]
        public void HandleShouldAddValidDateBooking()
        {
            //Arrange
            var command = new BookingViewCommand();
            var property = GetMockProperty(1, "TestProperty");

            _properties.Find(1).Returns(property);
            command.ViewDate = DateTime.Now;
            command.PropertyId = 1;
            //Actaul
            var result = _handler.Handle(command);
            //Assert
            Assert.IsTrue(result.Status);
        }

    }
}
