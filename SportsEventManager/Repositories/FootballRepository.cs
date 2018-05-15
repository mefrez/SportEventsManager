using Microsoft.EntityFrameworkCore;
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
        List<Football> Get(Football ev);
    }
    public class FootballRepository : IFootballRepository
    {
        private DbSet<Football> _dbSet;

        private DbContext _dbContext;

        public FootballRepository(DbSet<Football> dbSet, DbContext dbContext)
        {
            _dbSet = dbSet;
            _dbContext = dbContext;
        }

        public void Create(Football ev)
        {
            _dbSet.Add(ev);

            _dbContext.SaveChanges();

        }

        public List<Football> Get(Football ev)
        {
            return _dbSet.ToList();
        }
    }
}
