using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Models
{
    public class UploadImageModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Select Product Images")]
        public IFormFileCollection ProductImages { get; set; }
    }
}
