using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class BookingListViewModel
    {
        public int BookingId { get; set; }
        public DateTime ViewDate { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public string Buyer_Id { get; set; }
    }
}