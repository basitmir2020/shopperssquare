using System.Collections.Generic;

namespace Shoppers_Square.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Error { get; set; }
        public string Token { get; set; }
    }
}
