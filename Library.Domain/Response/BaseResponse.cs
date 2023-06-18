using Library.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string? Description { get; set; } // Error information 
        public StatusCode StatusCode { get; set; } // Error status codes
        public T Data { get; set; } // Our task result
    }

    public interface IBaseResponse<T>
    {
        T Data { get; }
        StatusCode StatusCode { get; }
    }
}
