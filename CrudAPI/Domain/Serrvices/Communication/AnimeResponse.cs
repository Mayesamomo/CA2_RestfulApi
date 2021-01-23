using CrudAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Serrvices.Communication
{
    public class AnimeResponse : BaseResponse<Anime>
    {
        //public AnimeResponse(Anime anime) : base(anime) { }

        //public AnimeResponse(string message) : base(message) { }
        public Anime Anime { get; private set; }

        //Private constructor, which is going to pass the success and message parameters to the base class,
        //and also sets the Category property;
        private AnimeResponse(bool success, string message, Anime anime) : base(success, message)
        {
            Anime = anime;
        }

        //This constructor  receives only the category as a parameter.
        //it will create a successful response, 
        //calling the private constructor to set the respective properties;
        public AnimeResponse(Anime anime) : this(true, string.Empty, anime)
        { }

        // this constructor  only specifies the message.
        //This one will be used to create a failure response.
        public AnimeResponse(string message) : this(false, message, null)
        { }
    }
}
