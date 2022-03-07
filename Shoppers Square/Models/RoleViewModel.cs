using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Models
{
    public class RoleViewModel
    {
        public RoleViewModel() {
            Users = new List<string>();
        }
        [Required]
        public string RoleName { get; set; }
        public string Id { get; set; }

        public List<string> Users { get; set; }
    }
}
