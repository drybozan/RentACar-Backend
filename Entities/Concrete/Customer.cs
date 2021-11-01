using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        [Key]
        public int customer_id { get; set; }
        public int user_id { get; set; }
        public string company_name { get; set; }
    }
}
