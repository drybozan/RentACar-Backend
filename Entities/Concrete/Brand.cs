
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        [Key]
        public int brand_id { get; set; }
        public string brand_name { get; set; }
    }
}
