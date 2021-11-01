using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        [Key]
        public int card_id { get; set; }
        public int customer_id { get; set; }
        public string fullname { get; set; }
        public int card_number { get; set; }
        public int card_exp_month { get; set; }
        public int card_exp_year { get; set; }
        public int cvv { get; set; }
        public string card_type { get; set; }
        public int card_limit { get; set; }
    }
}
