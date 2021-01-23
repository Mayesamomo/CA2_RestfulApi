using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Resources
{
    public class AnimesQueryResource : QueryResource //inheret QueryResource class
    {
        public int? CategoryId { get; set; }
    }
}
