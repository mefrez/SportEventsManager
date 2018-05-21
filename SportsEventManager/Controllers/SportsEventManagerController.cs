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

        private IVolleyballRepository _volleyballRepository;

        private ITennisRepository _tennisRepository;

        public SportsEventManagerController(IEventRepository eventRepository, IFootballRepository footballRepository, IVolleyballRepository volleyballRepository, ITennisRepository tennisRepository)
        {
            _eventRepository = eventRepository;

            _footballRepository = footballRepository;

            _volleyballRepository = volleyballRepository;

            _tennisRepository = tennisRepository;
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
        [HttpPost]
        [Route("api/tennis/create")]
        public async Task<IActionResult> CreateTennisEvent([FromBody]Tennis ev)
        {
            try
            {
                _tennisRepository.Create(ev);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost]
        [Route("api/volleyball/create")]
        public async Task<IActionResult> CreateVolleyballEvent([FromBody]Volleyball ev)
        {
            try
            {
                _volleyballRepository.Create(ev);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

    }
}
