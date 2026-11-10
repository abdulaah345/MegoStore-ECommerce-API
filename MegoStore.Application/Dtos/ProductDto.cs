using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Application.Dtos
{
    public class ProductDto
    {
        [Required]
        [MaxLength(100)]

        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [Range(0.01, 999999)]
        public decimal Price { get; set; }
        [Range(0, 9999)]
        public int Stock { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}
