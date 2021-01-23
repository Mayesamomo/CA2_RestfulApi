using CrudAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Serrvices.Communication
{
    public class CategoryResponse : BaseResponse<Category>
    {
        public Category Category { get; private set; }

        //Private constructor, which is going to pass the success and message parameters to the base class,
        //and also sets the Category property;
        private CategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }

        //This constructor  receives only the category as a parameter.
        //it will create a successful response, 
       //calling the private constructor to set the respective properties;
        public CategoryResponse(Category category) : this(true, string.Empty, category)
        { }

        // this constructor  only specifies the message.
        //This one will be used to create a failure response.
        public CategoryResponse(string message) : this(false, message, null)
        { }
    }
}
