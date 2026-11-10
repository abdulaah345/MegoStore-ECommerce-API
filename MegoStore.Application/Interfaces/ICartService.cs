using MegoStore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Application.Interfaces
{
    public interface ICartService
    {
        
            Task<CartDto> GetCartAsync(string userId);
            Task<CartItemDto> AddItemToCartAsync(string userId, AddCartItemsDto dto);
            Task<CartItemDto> UpdateCartItemAsync(int cartItemId, int quantity);
            Task<bool> RemoveItemFromCartAsync(int cartItemId);
            Task<bool> ClearCartAsync(string userId);
        
    }
}
