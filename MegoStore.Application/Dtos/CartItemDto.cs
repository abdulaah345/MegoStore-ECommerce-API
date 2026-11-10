using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Application.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal Unitprice { get; set; }

        public int Qunatity { get; set; }

        public decimal subtotal  { get; set; }

    }
}
