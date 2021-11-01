using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int car_id { get; set; }
        public int color_id { get; set; }
        public int brand_id { get; set; }

        public string car_name { get; set; }
        public string  brand_name{ get; set; }
        public string color_name { get; set; }
        public double daily_price { get; set; }
        public int model_year { get; set; }

    }
}
