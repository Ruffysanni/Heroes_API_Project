using Heroes_API.Model;
using Heroes_API.Services.HeroServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Heroes_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroServices _heroServices;

        public HeroController(IHeroServices heroServices)
        {
            _heroServices = heroServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> GetAllHeroes()
        {
            return await _heroServices.GetAllHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHeroById(int id)
        {
            var result = await _heroServices.GetHeroById(id);
            if (result == null)
            {
                return NotFound("Hero not found.");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Hero>>> AddHero([FromBody]Hero hero)
        {
            var result = await _heroServices.AddHero(hero);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Hero>>> UpdateHero(int id, Hero updateHero)
        {
            var result = await _heroServices.UpdateHero(id, updateHero);
            if (result == null)
            {
                return NotFound("Hero not found.");
            }
            return Ok(result);
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Hero>>> DeleteHero(int id)
        {
            var result = await _heroServices.DeleteHero(id);
            if(result == null)
            {
                return NotFound("Hero not found.");
            }
            return Ok(result);
        }
    }
}
