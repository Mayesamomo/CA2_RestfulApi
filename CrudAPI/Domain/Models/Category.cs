using CrudAPI.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Models
{
    public class Category
    {
      
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public IList<Anime> Animes { get; set; } = new List<Anime>();
    }
}
