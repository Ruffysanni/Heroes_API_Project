using Heroes_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Heroes_API.Services.HeroServices
{
    public interface IHeroServices
    {
        Task<List<Hero>> GetAllHeroes();
        Task<Hero> GetHeroById(int id);
        Task<List<Hero>> AddHero(Hero hero);
        Task<List<Hero>> UpdateHero(int id, Hero updateHero);
        Task<List<Hero>> DeleteHero(int id);
    }
}
