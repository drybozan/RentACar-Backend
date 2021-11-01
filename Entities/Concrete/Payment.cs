using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        [Key]
        public int payment_id { get; set; }
        public int customer_id { get; set; }
        public int amount { get; set; }
    }
}
