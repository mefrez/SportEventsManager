using Microsoft.EntityFrameworkCore;
using SportsEventManager.Data;
using SportsEventManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsEventManager.Repositories
{
    public interface IFootballRepository
    {
        void Create(Football ev);
        List<Football> Get();
        Football GetById(int id);

        Football Update(Football football);
    }
    public class FootballRepository : IFootballRepository
    {
        private ApplicationDbContext _dbContext;

        public FootballRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Football ev)
        {
            _dbContext.FootballDbSet.Add(ev);

            _dbContext.SaveChanges();

        }

        public List<Football> Get()
        {
            return _dbContext.FootballDbSet.Include("Event").ToList();
        }

        public Football GetById(int id)
        {
            return _dbContext.FootballDbSet.Include("Event").Where(x => x.Id == id).FirstOrDefault();
        }

        public Football Update(Football football)
        {
            _dbContext.FootballDbSet.Update(football);

            _dbContext.SaveChanges();

            return football;
        }
    }
}
