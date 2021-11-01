using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto
    {
        public int rental_id { get; set; }
        public string customer_name { get; set; }
        public string brand_name { get; set; }
        
        public double daily_price { get; set; }
        public DateTime? rent_date { get; set; }
        public DateTime? return_date { get; set; }
    }
}
