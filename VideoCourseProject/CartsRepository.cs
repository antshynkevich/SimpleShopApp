using VideoCourseProject.Interfaces;
using VideoCourseProject.Models;

namespace VideoCourseProject;

public class CartsRepository : ICartRepository
{
    private List<Cart> _carts = new();

    public Cart? TryGetByUserId(string userId)
    {
        return _carts.FirstOrDefault(x => x.UserId == userId);
    }

    public void Add(Product product, string userId)
    {
        var cart = TryGetByUserId(userId);
        if (cart == null)
        {
            var newCart = new Cart
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Items = new List<CartItem>
                {
                    new CartItem()
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Product = product
                    }
                }
            };

            _carts.Add(newCart);
        }
        else
        {
            var existingCartItem = cart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (existingCartItem != null)
            {
                existingCartItem.Amount++;
            }
            else
            {
                cart.Items.Add(new CartItem()
                {
                    Id = Guid.NewGuid(),
                    Amount = 1,
                    Product = product
                });
            }
        }
    }

    public void DecreaseAmount(Guid itemId, string userId)
    {
        var cart = TryGetByUserId(userId);
        var existingCartItem = cart?.Items?.FirstOrDefault(x => x.Id == itemId);
        if (existingCartItem == null)
        {
            return;
        }

        existingCartItem.Amount--;
        if (existingCartItem.Amount == 0 && cart?.Items != null)
        {
            cart.Items.Remove(existingCartItem);
        }
    }

    public void IncreaseAmount(Guid itemId, string userId)
    {
        var cart = TryGetByUserId(userId);
        var existingCartItem = cart?.Items?.FirstOrDefault(x => x.Id == itemId);
        if (existingCartItem == null)
        {
            return;
        }

        if (existingCartItem.Amount > 99)
        {
            return;
        }

        existingCartItem.Amount++;
    }

    public void Clear(string userId)
    {
        var cart = TryGetByUserId(userId);
        _carts.Remove(cart);
    }
}
