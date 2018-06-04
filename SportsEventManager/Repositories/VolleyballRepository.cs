using Microsoft.EntityFrameworkCore;
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

        Volleyball GetById(int id);

        Volleyball Update(Volleyball volleyball);
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
            return _dbContext.VolleyballDbSet.Include("Event").ToList();
        }

        public Volleyball GetById(int id)
        {
            return _dbContext.VolleyballDbSet.Include("Event").Where(x => x.Id == id).FirstOrDefault();
        }


        public Volleyball Update(Volleyball volleyball)
        {
            _dbContext.VolleyballDbSet.Update(volleyball);

            _dbContext.SaveChanges();

            return volleyball;
        }
    }
}
