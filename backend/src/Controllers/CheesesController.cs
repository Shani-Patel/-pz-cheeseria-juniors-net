using Microsoft.AspNetCore.Mvc;
using Pz.Cheeseria.Api.Models;
using System.Threading.Tasks;

namespace Pz.Cheeseria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheesesController : ControllerBase
    {
        private readonly IOrgDbContext _orgDbContext;
        private readonly ICheeseService _cheeseService;

        public CheesesController(IOrgDbContext orgDbContext, ICheeseService cheeseService)
        {
            _orgDbContext = orgDbContext;
            _cheeseService = cheeseService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Cheese[]), 200)]
        public async Task<IActionResult> GetCheeses()
        {
            return Ok(await _cheeseService.GetCheese());
        }

        [HttpGet(Urls.V1.Dbo.Cheese.GetCheesesbyId, Name = nameof(GetCheesesbyId))]
        [ProducesResponseType(typeof(Cheese[]), 200)]
        public async Task<Cheese> GetCheesesbyId(int id)
        {
            return await _cheeseService.GetCheeseById(id);
        }

        [HttpPut(Urls.V1.Dbo.Cheese.SetCart, Name = nameof(SetCart))]
        [ProducesResponseType(typeof(Cheese[]), 200)]
        public async Task SetCart(CreateCartRequest cartRequest)
        {
            await _cheeseService.CreateCart(cartRequest);
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(Cheese[]), 200)]
        //public async Task<Cheese> GetRecentPurchase()
        //{
        //    Cheese ch = new Cheese();

        //    return ch;
        //}
    }
}