using Microsoft.AspNetCore.Mvc;
using SportsEventManager.Models;
using SportsEventManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsEventManager.Controllers
{
    public class SportsEventManagerController : Controller
    {
        private IEventRepository _eventRepository;

        private IFootballRepository _footballRepository;

        public SportsEventManagerController(IEventRepository eventRepository, IFootballRepository footballRepository)
        {
            _eventRepository = eventRepository;

            _footballRepository = footballRepository;
        }

        [HttpPost]
        [Route("api/event/create")]
        public async Task<IActionResult> CreateEvent([FromBody]Event ev)
        {
            try
            {              
                return Ok(_eventRepository.Create(ev));
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
        }


        [HttpPost]
        [Route("api/football/create")]
        public async Task<IActionResult> CreateFootballEvent([FromBody]Football ev)
        {
            try
            {
                _footballRepository.Create(ev);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

    }
}
