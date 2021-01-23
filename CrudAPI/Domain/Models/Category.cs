using CrudAPI.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public IList<Anime> Animes { get; set; } = new List<Anime>();

        public static explicit operator Category(CategoryResource v)
        {
            throw new NotImplementedException();
        }
    }
}
