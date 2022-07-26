using Microsoft.EntityFrameworkCore;
using VideoCourseProject.db.Interfaces;
using VideoCourseProject.db.Models;

namespace VideoCourseProject.db.Repositories;

public class CartsDbRepository : ICartRepository
{
    private readonly DatabaseContext _databaseContext;

    public CartsDbRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public Cart? TryGetByUserId(string userId)
    {
        return _databaseContext.Carts
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefault(x => x.UserId == userId);
    }

    public void Add(Product product, string userId)
    {
        var cart = TryGetByUserId(userId);
        if (cart == null)
        {
            var newCart = new Cart
            {
                UserId = userId
            };

            newCart.Items = new List<CartItem>
            {
                new CartItem
                {
                    Amount = 1,
                    Product = product,
                    Cart = newCart
                }
            };
            
            _databaseContext.Carts.Add(newCart);
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
                    Amount = 1,
                    Product = product,
                    Cart = cart
                });
            }
        }

        _databaseContext.SaveChanges();
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

        _databaseContext.SaveChanges();
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

        _databaseContext.SaveChanges();
    }

    public void Clear(string userId)
    {
        var cart = TryGetByUserId(userId);
        _databaseContext.Carts.Remove(cart);
        _databaseContext.SaveChanges();
    }
}
