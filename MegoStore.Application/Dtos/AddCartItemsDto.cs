using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Application.Dtos
{
    public class AddCartItemsDto
    {
       public int ProductId { get; set; }
       public int Quanity {  get; set; }

    }
}
