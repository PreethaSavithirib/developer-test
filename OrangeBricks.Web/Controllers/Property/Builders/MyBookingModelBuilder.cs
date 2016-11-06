using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class MyBookingModelBuilder
    {
        private IOrangeBricksContext _context;
        public MyBookingModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public List<BookingListViewModel> Build(string buyerId)
        {
            var booking = _context.Bookings.Where(o => o.Buyer_Id == buyerId)
                .Select(o => new BookingListViewModel {  Buyer_Id = o.Buyer_Id, BookingId =o.BookingId, BookingStatus=o.BookingStatus, ViewDate = o.ViewDate})
                .ToList();
            return booking;
        }
    }
}