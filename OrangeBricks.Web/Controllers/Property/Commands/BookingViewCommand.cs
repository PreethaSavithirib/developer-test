using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookingViewCommand : RootCommand
    {
        public int BookingId { get; set; }
        public DateTime ViewDate { get; set; }        
        public string BuyerId { get; set; }        
        public string BookingStatus { get; set; }
    }
}