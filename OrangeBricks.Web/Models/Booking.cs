using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public DateTime ViewDate { get; set; }

        //public int Property_Id {get;set;}
        public BookingStatus BookingStatus { get; set; }

        public string Buyer_Id { get; set;}


    }
}