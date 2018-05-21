using SportsEventManager.Data;
using SportsEventManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsEventManager.Repositories
{
    public interface IVolleyballRepository
    {
        void Create(Volleyball ev);

        List<Volleyball> Get();
    }

    public class VolleyballRepository : IVolleyballRepository
    {
        private ApplicationDbContext _dbContext;

        public VolleyballRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Volleyball ev)
        {
            _dbContext.VolleyballDbSet.Add(ev);

            _dbContext.SaveChanges();

        }

        public List<Volleyball> Get()
        {
            return _dbContext.VolleyballDbSet.ToList();
        }
    }
}
