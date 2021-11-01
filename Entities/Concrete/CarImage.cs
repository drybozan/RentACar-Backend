using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
   public class CarImage:IEntity
    {
        [Key]
        public int image_id { get; set; }
        public int car_id { get; set; }
        public string image_path { get; set; }
        public DateTime date { get; set; }
    }
}
