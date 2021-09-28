using Pz.Cheeseria.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pz.Cheeseria.Api.Controllers
{
    public interface ICheeseService
    {
        Task<List<Cheese>> GetCheese();

        Task<List<Cheese>> CreateCart(CreateCartRequest request);
    }
}