using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Resources
{
    public class QueryResource
    {
        public int Page { get; set; } // page object
        public int ItemsPerPage { get; set; } // list of items in each page 
    }
}
