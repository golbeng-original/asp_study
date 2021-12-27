using System;
using ex1.Components;
using Microsoft.AspNetCore.Mvc;

namespace ex1.Controllers
{
    //
    [Route("api/[controller]")]
    public class FiveServiceController : ControllerBase
    {
        private IFiveRepositry _repository;

        public FiveServiceController(IFiveRepositry repositry)
        {
            _repository = repositry;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAll();

            return Ok(result);
        }
    }
}