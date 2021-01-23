using CrudAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Resources
{
    public class AnimeResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Producer { get; set; }
        public string Thumbnail { get; set; }
        public bool Istreaming { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Category Category { get; set; }
    }
}
