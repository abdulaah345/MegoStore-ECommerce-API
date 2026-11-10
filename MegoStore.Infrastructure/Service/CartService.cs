using AutoMapper;
using MegoStore.Application.Dtos;
using MegoStore.Application.Interfaces;
using MegoStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Infrastructure.Service
{
    public class CartService : ICartService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public CartService(IUnitofWork unitofWork,IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        public async Task<CartItemDto> AddItemToCartAsync(string userId, AddCartItemsDto dto)
        {
            if (string.IsNullOrEmpty(userId))
                return null;
            var cart=await _unitofWork.Repository<Cart>().GetWithIncludeAsync(c => c.UserId == userId, "Items.Product");
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                await _unitofWork.Repository<Cart>().AddAsync(cart);    
                await _unitofWork.SaveChangesAsync();

            }
            var exetingitem=cart.Items?.FirstOrDefault(i=>i.ProductId==dto.ProductId);
            CartItem item;
            if (exetingitem != null)
            {

                exetingitem.Quantity += dto.Quanity;
                item=exetingitem;
            }
            else
            {
                var product = await _unitofWork.Repository<Product>().GetByIdAsync(dto.ProductId);
                if (product == null)
                    return null;
                var newitem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quanity,
                    Product=product,
                    UnitPrice = product.Price
                };
                await _unitofWork.Repository<CartItem>().AddAsync(newitem);
                item = newitem;
            }
            await _unitofWork.SaveChangesAsync();
                return _mapper.Map<CartItemDto>(item);
        }

        public async Task<bool> ClearCartAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId) )
                return false;
            var cart = await _unitofWork.Repository<Cart>().GetWithIncludeAsync(u => u.UserId == userId, "Items");
            if (cart==null)
                return false;
            foreach(var item in cart.Items.ToList())
            {
               _unitofWork.Repository<CartItem>().Delete(item);
            }
            await _unitofWork.SaveChangesAsync();
            return true;    
        }

        public async Task<CartDto> GetCartAsync(string userId)
        {

            if (string.IsNullOrEmpty(userId))
                return null;

            var cart = await _unitofWork.Repository<Cart>().GetWithIncludeAsync(c => c.UserId == userId, "Items.Product");

            if (cart == null)
            {
                cart=new Cart { UserId = userId };
               await _unitofWork.Repository<Cart>().AddAsync(cart);
               await  _unitofWork.SaveChangesAsync();

            }

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<bool> RemoveItemFromCartAsync(int cartItemId)
        {
            var item=await _unitofWork.Repository<CartItem>().GetByIdAsync (cartItemId);
            if (item == null)
                return false;
            _unitofWork.Repository<CartItem>().Delete(item);
            await _unitofWork.SaveChangesAsync();
            return true;
        }

        public async Task<CartItemDto> UpdateCartItemAsync(int cartItemId, int quantity)
        {
            var updateitem = await _unitofWork.Repository<CartItem>().GetWithIncludeAsync(c => c.Id==cartItemId, "Product");
            if (updateitem == null)
                return null;
            if (quantity == 0)
            {

                _unitofWork.Repository<CartItem>().Delete(updateitem);
                await _unitofWork.SaveChangesAsync();
                return null;

             }
            updateitem.Quantity = quantity;
            await _unitofWork.SaveChangesAsync();
            return _mapper.Map<CartItemDto>(updateitem);
        }
    }
}
