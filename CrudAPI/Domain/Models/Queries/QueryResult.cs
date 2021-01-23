using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Models.Queries
{
    //listing pages if there is more than one page 
    public class QueryResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; } = 0;
    }
}
