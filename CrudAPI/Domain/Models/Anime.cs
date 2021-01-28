using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Producer { get; set; }
        public string Thumbnail { get; set; }
        public bool Istreaming { get; set; }
        //[Display(Name = "Release Date")]
       // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //[DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
       
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
