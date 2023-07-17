using Heroes_API.DAL;
using Heroes_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Heroes_API.Services.HeroServices
{
    public class HeroServices : IHeroServices
    {
        private readonly DataContext _context;

        public HeroServices(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Hero>> AddHero(Hero hero)
        {

             _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.Heroes.ToListAsync();

        }

        public async Task<List<Hero>> DeleteHero(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.Heroes.ToListAsync();

        }

        public async Task<List<Hero>> GetAllHeroes()
        {
            var heroes = await _context.Heroes.ToListAsync();
            return await _context.Heroes.ToListAsync();

        }

        public async Task<Hero> GetHeroById(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<Hero>> UpdateHero(int id, Hero updateHero)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            hero.FirtName = updateHero.FirtName;
            hero.LastName = updateHero.LastName;
            hero.Place = updateHero.Place;
            hero.UserName = updateHero.UserName;

            await _context.SaveChangesAsync();
            return await _context.Heroes.ToListAsync();
        }
    }
}
