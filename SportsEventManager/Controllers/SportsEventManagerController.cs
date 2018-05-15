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
        private readonly IEventRepository _eventRepository;

        private readonly IFootballRepository _footballRepository;

        public SportsEventManagerController(IFootballRepository footballRepository, IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;

            _footballRepository = footballRepository;
        }

        [HttpPost]
        [Route("api/event/create")]
        public async Task<IActionResult> CreateEvent([FromBody]Event ev)
        {
            _eventRepository.Create(ev);

            return Ok();
        }

    }
}
