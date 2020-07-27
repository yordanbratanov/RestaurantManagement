using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Models.Common
{
    public class RestaurantListParams : PagingParams
    {
        public string OrderBy { get; set; }

        public bool IsDescending { get; set; }
    }
}
