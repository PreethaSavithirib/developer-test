using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Property.Builders
{
    public static class ExtentionMethods
    {
        public static IDbSet<T> Initialize<T>(this IDbSet<T> dbSet, IQueryable<T> data) where T : class
        {
            dbSet.Provider.Returns(data.Provider);
            dbSet.Expression.Returns(data.Expression);
            dbSet.ElementType.Returns(data.ElementType);
            dbSet.GetEnumerator().Returns(data.GetEnumerator());
            return dbSet;
        }
    }

    [TestFixture]
    public class PropertiesViewModelBuilderTest : BaseModelBuilderTest
    {      

        [Test]
        public void BuildShouldReturnPropertiesWithMatchingStreetNamesWhenSearchTermIsProvided()
        {
            // Arrange
            var builder = new PropertiesViewModelBuilder(_context);
            var offers = new List<Offer>();
            var properties = new List<Models.Property>{
                new Models.Property{ StreetName = "Smith Street", Description = "", IsListedForSale = true,Offers = offers },
                new Models.Property{ StreetName = "Jones Street", Description = "", IsListedForSale = true,Offers = offers}
            };

            var mockSet = Substitute.For<IDbSet<Models.Property>>()
                .Initialize(properties.AsQueryable());

            _context.Properties.Returns(mockSet);

            var query = new PropertiesQuery
            {
                Search = "Smith Street"
            };

            // Act
            var viewModel = builder.Build(query);

            // Assert
            Assert.That(viewModel.Properties.Count, Is.EqualTo(1));
        }

        [Test]
        public void BuildShouldReturnPropertiesWithMatchingDescriptionsWhenSearchTermIsProvided()
        {
            // Arrange
            var builder = new PropertiesViewModelBuilder(_context);
            var offers = new List<Offer>();
            var properties = new List<Models.Property>{
                new Models.Property{ StreetName = "", Description = "Great location", IsListedForSale = true,Offers = offers },
                new Models.Property{ StreetName = "", Description = "Town house", IsListedForSale = true,Offers = offers }
            };
            
            var mockSet = Substitute.For<IDbSet<Models.Property>>()
                .Initialize(properties.AsQueryable());

            _context.Properties.Returns(mockSet);

            var query = new PropertiesQuery
            {
                Search = "Town"
            };

            // Act
            var viewModel = builder.Build(query);

            // Assert
            Assert.That(viewModel.Properties.Count, Is.EqualTo(1));
            Assert.That(viewModel.Properties.All(p => p.Description.Contains("Town")));
        }
    }
}
