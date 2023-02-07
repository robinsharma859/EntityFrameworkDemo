using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Controllers
{
    public enum ResponseStatus
    {
        Success,
        Error,
        Conflict,
        NotFound,
        NoContent,
        Created,
        BadRequest,
        InternalServerError
    }

    public struct ErrorModel
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }

    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
            this.Errors = new List<ErrorModel>();
        }
        public T Result { get; set; }
        public string Identifier { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public List<ErrorModel> Errors { get; set; }
        public ServiceResponse<T> AddError(string errorCode, string errorMessage)
        {
            this.Errors.Add(new ErrorModel { ErrorCode = errorCode, Message = errorMessage });
            return this;
        }
    }
    //public class ServiceResponse
    //{
    //    public ServiceResponse()
    //    {
    //        this.Errors = new List<ErrorModel>();
    //    }
    //    public dynamic Result { get; set; }
    //    public string Identifier { get; set; }
    //    public ResponseStatus ResponseStatus { get; set; }
    //    public List<ErrorModel> Errors { get; set; }
    //    public ServiceResponse AddError(string errorCode, string errorMessage)
    //    {
    //        this.Errors.Add(new ErrorModel { ErrorCode = errorCode, Message = errorMessage });
    //        return this;
    //    }
    //}
}