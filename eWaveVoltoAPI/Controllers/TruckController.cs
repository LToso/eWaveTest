using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eWaveVolvoAPI.Models.Entities;
using eWaveVolvoAPI.Repositories;

namespace eWaveVolvoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly ITruckRepository repos;
        public TruckController(ITruckRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return Ok(repos.List());
            else
                return Ok(repos.Select(id));
        }

        [HttpPost]
        public IActionResult Post(TruckObj truck)
        {
            if (repos.Insert(truck))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(TruckObj truck)
        {
            if (repos.Update(truck))
                return Ok();

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (repos.Delete(id))
                return Ok();

            return BadRequest();
        }
    }
}
