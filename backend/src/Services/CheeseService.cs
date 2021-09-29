using Microsoft.EntityFrameworkCore;
using Pz.Cheeseria.Api.Controllers;
using Pz.Cheeseria.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pz.Cheeseria.Api.Services
{
    public class CheeseService : ICheeseService
    {
        private readonly IOrgDbContext _orgDbContext;

        public CheeseService(IOrgDbContext orgDbContext) 
        {
            _orgDbContext = orgDbContext;
        }

        public async Task<List<Cheese>> GetCheese()
        {
            using (var context = _orgDbContext.DbContext())
            {
                var sync = await context.Cheese.ToListAsync();
                return sync;
            }
        }

        public async Task CreateCart(CreateCartRequest request)
        {
            using (var context = _orgDbContext.DbContext())
            {

                var totalPrice = request.TotalPrice;
                var totalQuantity = request.TotalQuantity;

                Orders requestOrder = new Orders {
                    total_price = totalPrice,
                    total_quantity = totalQuantity,
                    description = "",
                    CreatedUtc = DateTime.UtcNow
                };

                context.Orders.Add(requestOrder);
                await context.SaveChangesAsync();

                var order = context.Orders.OrderByDescending(x => x.CreatedUtc).FirstAsync();
                var order_id = order.Id;

                foreach (var ab in request.Cart)
                {
                    var cheese_id = ab.Item1;
                    var quantity = ab.Item2;

                    Cart cart = new Cart
                    {
                        Cheese_id = cheese_id,
                        Quantity = quantity,
                        Order_id = order_id,
                    };

                    context.Cart.Add(cart);
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task<Cheese> GetCheeseById(int id)
        {
            using (var context = _orgDbContext.DbContext())
            {
                try
                {
                    var cheese = await context.Cheese.Where(x => x.Id == id).FirstOrDefaultAsync();
                    return cheese;
                }
                catch (Exception e) {
                    Console.WriteLine("Cannot find cheese with id:" + id + " ", e.Message);
                    return null;
                }
            }
        }
    }
}
