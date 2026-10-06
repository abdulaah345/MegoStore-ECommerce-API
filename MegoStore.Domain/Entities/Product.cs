using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Range(0,99999)]
        public int Stock{ get; set; }
        public int  CategoryId { get; set; }

        public Category Category { get; set; }
        [Required]
        [Range(0.01, 999999)]
        public decimal Price { get; set; }  


        
    }
}
