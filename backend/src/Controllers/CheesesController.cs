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
            var abc = HttpContext.Request.Path;
            var result = await _cheeseService.GetCheese();
            return Ok(result);
        }

        /// <summary>
        /// Get all cheese by Id
        /// </summary>
        /// <param name="id">id of the cheese to get</param>
        /// <returns></returns>
        /// <response code="200">OK</response>
        //[HttpGet(Urls.V1.Dbo.Cheese.GetById, Name = nameof(GetCheesesbyId))]
        //[ProducesResponseType(typeof(Cheese[]), 200)]
        //public async Task<Cheese> GetCheesesbyId(int id)
        //{
        //    Cheese ch = new Cheese();
        //    return ch;
        //}

        //[HttpGet(Urls.V1.Dbo.Cheese.SetCart, Name = nameof(SetCart))]
        //[ProducesResponseType(typeof(Cheese[]), 200)]
        //public async Task<IActionResult> SetCart(CreateCartRequest cartRequest)
        //{
        //    var result = await _cheeseService.CreateCart(cartRequest);
        //    Cheese ch = new Cheese();
        //    return Ok(ch);
        //    //return ch;
        //}

        [HttpPut(Urls.V1.Dbo.Cheese.SetCart, Name = nameof(SetCart))]
        [ProducesResponseType(typeof(Cheese[]), 200)]
        public async Task<IActionResult> SetCart(int id)
        {
            //var result = await _cheeseService.CreateCart(cartRequest);
            Cheese ch = new Cheese();
            return Ok(ch);
            //return ch;
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(Cheese[]), 200)]
        //public async Task<Cheese> GetRecentPurchase()
        //{
        //    Cheese ch = new Cheese();

        //    return ch;
        //}

        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(Cheese))]
        //[ProducesResponseType(400)]
        //public async Task<ActionResult<Cheese>> GetCheese1()
        //{

        //    //return Ok();
        //    return await _cheeseService.GetCheese1();
        //}
    }
}