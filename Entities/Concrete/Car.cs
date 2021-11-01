using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        [Key]
        public int car_id { get; set; }
        public int brand_id { get; set; }
        public int color_id { get; set; }
        public string car_name { get; set; }
        public int model_year { get; set; }
        public double daily_price { get; set; }
       
    }
}
