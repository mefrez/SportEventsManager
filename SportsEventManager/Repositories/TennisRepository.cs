using Microsoft.EntityFrameworkCore;
using SportsEventManager.Data;
using SportsEventManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsEventManager.Repositories
{
    public interface ITennisRepository
    {
        void Create(Tennis ev);
        List<Tennis> Get();
        Tennis GetById(int id);

        Tennis Update(Tennis tennis);
    }
    public class TennisRepository : ITennisRepository
    {
        private ApplicationDbContext _dbContext;

        public TennisRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Tennis ev)
        {
            _dbContext.TennisDbSet.Add(ev);

            _dbContext.SaveChanges();

        }

        public List<Tennis> Get()
        {
            return _dbContext.TennisDbSet.Include("Event").ToList();
        }

        public Tennis GetById(int id)
        {
            return _dbContext.TennisDbSet.Include("Event").Where(x => x.Id == id).FirstOrDefault();
        }

        public Tennis Update(Tennis tennis)
        {
            _dbContext.TennisDbSet.Update(tennis);

            _dbContext.SaveChanges();

            return tennis;
        }
    }
}
