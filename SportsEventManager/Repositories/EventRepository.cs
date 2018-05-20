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
        Event Create(Event ev);

        void Start(int id);

        void End(int id);
    }

    public class EventRepository : IEventRepository
    {
        private ApplicationDbContext _dbContext;

        public EventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Event Create(Event ev)
        {
            _dbContext.EventDbSet.Add(ev);

            _dbContext.SaveChanges();

            return ev;
            
        }

        public void Start(int id)
        {
            Event ev = _dbContext.EventDbSet.ToList().FirstOrDefault(x => x.Id == id);

            ev.Started = DateTime.Now;

            _dbContext.EventDbSet.Update(ev);

            _dbContext.SaveChanges();
        }

        public void End(int id)
        {
            Event ev = _dbContext.EventDbSet.ToList().FirstOrDefault(x => x.Id == id);

            ev.Ended = DateTime.Now;

            _dbContext.EventDbSet.Update(ev);

            _dbContext.SaveChanges();

        }


    }
}
