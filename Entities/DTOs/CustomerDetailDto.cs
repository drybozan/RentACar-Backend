using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto : IDto
    {
        public int customer_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string company_name { get; set; }
    }
}
