﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [Route("api/football/update")]
        public async Task<IActionResult> UpdateFootballEvent([FromBody]Football ev)
        {
            Football football = new Football();

            try
            {
                football = _footballRepository.Update(ev);

                return Ok(football);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        [Route("api/tennis/update")]
        public async Task<IActionResult> UpdateTennisEvent([FromBody]Tennis ev)
        {
            Tennis tennis = new Tennis();

            try
            {
                tennis = _tennisRepository.Update(ev);

                return Ok(tennis);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


        [HttpPost]
        [Route("api/volleyball/update")]
        public async Task<IActionResult> UpdateVolleyballEvent([FromBody]Volleyball ev)
        {
            Volleyball volleyball = new Volleyball();

            try
            {
                volleyball = _volleyballRepository.Update(ev);

                return Ok(volleyball);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


        [HttpGet]
        [Route("api/football/get")]
        public async Task<IActionResult> GetFootballEvents()
        {
            try
            {               
                return Ok(_footballRepository.Get());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet]
        [Route("api/football/get/{id}")]
        public async Task<IActionResult> GetFootballEvent(int id)
        {
            try
            {
                return Ok(_footballRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet]
        [Route("api/tennis/get")]
        public async Task<IActionResult> GetTennisEvents()
        {
            try
            {
                return Ok(_tennisRepository.Get());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet]
        [Route("api/tennis/get/{id}")]
        public async Task<IActionResult> GetTennisEventById(int id)
        {
            try
            {
                return Ok(_tennisRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


        [HttpGet]
        [Route("api/volleyball/get")]
        public async Task<IActionResult> GetVolleyballEvents()
        {
            try
            {
                return Ok(_volleyballRepository.Get());
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet]
        [Route("api/volleyball/get/{id}")]
        public async Task<IActionResult> GetVolleyballEventById(int id)
        {
            try
            {
                return Ok(_volleyballRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }



    }
}
