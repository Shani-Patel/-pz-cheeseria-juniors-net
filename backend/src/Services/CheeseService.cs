using Microsoft.EntityFrameworkCore;
using Pz.Cheeseria.Api.Controllers;
using Pz.Cheeseria.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pz.Cheeseria.Api.Services
{
    internal class CheeseService : ICheeseService
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

        public async Task<List<Cheese>> CreateCart(CreateCartRequest request)
        {
            using (var context = _orgDbContext.DbContext())
            {
                //foreach (var ab in request.Cart)
                //{
                //    var x = ab.Item1;
                //    var b = ab.Item2;

                //    //context.Cart.Add();
                //}
                //request.Cart.Select(x => x.Item1);

                var sync = await context.Cheese.ToListAsync();
                return sync;
            }
        }
    }
}
