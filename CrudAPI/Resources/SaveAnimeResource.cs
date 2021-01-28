using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Resources
{
    public class SaveAnimeResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Producer { get; set; }

        [Required]
        public string Thumbnail { get; set; }

        [Required]
        public bool Istreaming { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int CategoryId { get; set; }
       
    }
}
