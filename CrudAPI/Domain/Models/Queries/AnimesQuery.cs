using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Models.Queries
{
    
    public class AnimesQuery : Query //inherit the Query class
    {

        public int? CategoryId { get; set; }
        //anime list with the categories
        public AnimesQuery(int? categoryId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            CategoryId = categoryId;
        }

    }
}
