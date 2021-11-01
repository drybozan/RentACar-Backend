using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        [Key]
        public int rental_id { get; set; }
        public int car_id { get; set; }
        public int customer_id { get; set; }
        public DateTime? rent_date { get; set; } //Datetime = Values cannot be null -- Datetime? = Nullable Datetime (Values can be null)
        public DateTime? return_date { get; set; }
    }
}
