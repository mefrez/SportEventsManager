using Microsoft.EntityFrameworkCore;
using SportsEventManager.Data;
using SportsEventManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsEventManager.Repositories
{
    public interface IEventRepository
    {
        void Create(Event ev);

        void Start(int id);

        void End(int id);
    }

    public class EventRepository : IEventRepository
    {
        private DbSet<Event> _dbSet;

        private DbContext _dbContext;

        public EventRepository(DbSet<Event> dbSet, DbContext dbContext)
        {
            _dbSet = dbSet;
            _dbContext = dbContext;
        }

        public void Create(Event ev)
        {
            _dbSet.Add(ev);

            _dbContext.SaveChanges();
            
        }

        public void Start(int id)
        {
            Event ev = _dbSet.ToList().FirstOrDefault(x => x.Id == id);

            ev.Started = DateTime.Now;
        }

        public void End(int id)
        {
            Event ev = _dbSet.ToList().FirstOrDefault(x => x.Id == id);

            ev.Ended = DateTime.Now;
        }


    }
}
