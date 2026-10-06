using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public String UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        public DateTime OrderDate { get; set; }
        [Required, MaxLength(250)]
        public String  Address { get; set; }
        [Range(0.01, 999999)]
        public decimal TotalPrice { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }   




    }
}
