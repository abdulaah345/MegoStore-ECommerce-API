using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int  OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
        [Range(1, 999999)]
        public int Quantity { get; set; }
        [Range(0.01, 999999)]
        public decimal UnitPrice { get; set; }

        


    }
}
