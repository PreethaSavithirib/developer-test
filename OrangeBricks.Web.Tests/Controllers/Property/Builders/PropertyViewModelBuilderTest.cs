using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Tests.Controllers.Property.Builders
{
    [TestFixture]
    public class PropertyViewModelBuilderTest : BaseModelBuilderTest
    {
        protected IDbSet<Models.Property> _properties;
        [SetUp]
        public void Setup()
        {
            base.SetUp();
            _properties = Substitute.For<IDbSet<Models.Property>>();
           //_context.Properties.Returns(_properties);
           
        }
        [Test]
        public void BuildShouldReturnValidViewModel()
        {
            //Arrange
            var expectedModel = new PropertyViewModel
            {
                Description = "TestDesc",
                Id = 1,
                NumberOfBedrooms = 3
            };
            var property = new Models.Property { Id = 1, Description = "TestDesc", NumberOfBedrooms = 3 };
            _context.Properties.Find(1).Returns(property);
            var build = new PropertyViewModelBuilder(_context);
            //Actual
            var actual = build.Build(1);
            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedModel.NumberOfBedrooms, actual.NumberOfBedrooms);
            Assert.AreEqual(expectedModel.Id, actual.Id);
        }
    }
}
