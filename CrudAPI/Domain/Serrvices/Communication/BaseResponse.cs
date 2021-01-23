using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Serrvices.Communication
{
    public abstract class BaseResponse<T>
    {
        //responses will inherit the abstract for this purpose:
        //The abstraction defines a Success property, which will tell whether 
        //the requests were completed successfully,
        //and a Message property, that will have the error message if something fails.

        //it is in the Domain folder since it has relationship with the models
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
       // public T Resource { get; private set; }

        //protected BaseResponse(T resource)
        //{
        //    Success = true;
        //    Message = string.Empty;
        //    Resource = resource;
        //}
        //protected BaseResponse(string message)
        //{
        //    Success = false;
        //    Message = message;
        //    Resource = default;
        //}
        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
