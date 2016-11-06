using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookingViewCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public BookingViewCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public ResultModel<Booking> Handle(BookingViewCommand command)
        {
            var property = _context.Properties.Find(command.PropertyId);
            BookingStatus status;
            var bookingView = new Booking
            {
                Buyer_Id = command.BuyerId,
                ViewDate = command.ViewDate,
                BookingStatus = Enum.TryParse<BookingStatus>(command.BookingStatus, out status) ? status : BookingStatus.Requested
            };
            if (property.Bookings == null)
            {
                property.Bookings = new List<Booking>();
            }
            property.Bookings.Add(bookingView);
            _context.SaveChanges();
            return new ResultModel<Booking> { Entity = bookingView, Status = true };
        }
    }
}