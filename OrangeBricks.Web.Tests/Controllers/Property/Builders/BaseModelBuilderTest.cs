using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Tests.Controllers.Property.Builders
{
    public class BaseModelBuilderTest
    {
        protected IOrangeBricksContext _context;
       
        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
           
        }
    }
}
