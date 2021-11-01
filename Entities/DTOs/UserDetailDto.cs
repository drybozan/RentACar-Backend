using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs
{
    public class UserDetailDto
    {
        [Key]
        public int userss_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
    }
}
