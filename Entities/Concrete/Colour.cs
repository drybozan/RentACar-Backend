using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Colour:IEntity
    {
        [Key]
        public int color_id { get; set; }
        public string color_name { get; set; }
    }
}
