using Pz.Cheeseria.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pz.Cheeseria.Api.Controllers
{
    public interface ICheeseService
    {
        Task<List<Cheese>> GetCheese();

        Task CreateCart(CreateCartRequest request);

        Task<Cheese> GetCheeseById(int id);
    }
}