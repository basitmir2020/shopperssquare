using System.Collections.Generic;

namespace Shoppers_Square.Models
{
    public class UserEmailOptions
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<KeyValuePair<string,string>> Placeholder { get; set; }
    }
}
