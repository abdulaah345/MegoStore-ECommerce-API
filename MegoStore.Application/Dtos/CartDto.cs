using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Application.Dtos
{
    public class CartDto
    {
        public int Id { get; set; }
        public List<CartItemDto> Items { get; set; }

        public decimal Total { get; set; }
    }
}
