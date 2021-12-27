using System;
using Microsoft.AspNetCore.Mvc;
using ex1.Components;

namespace ex1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PointController : ControllerBase
    {
        private IPointRepository _repository;

        public PointController(IPointRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            //var myPoint = _repository.GetTotalPointByUserId();
            //var json = new { Point = myPoint };

            var point = _repository.GetTotalPointByUserId(1);

            return Ok(new { point = point});
        }


        [HttpGet]
        [Route("{userId:int}")]
        public IActionResult Get(int userId)
        {
            //_repository.GetTotalPointByUserId(userId);
            return Ok();
        }
    }

    //[ApiController]
    [Route("api/[controller]")]
    public class PointServiceController : ControllerBase
    {
        private IPointRepository _repository;

        public PointServiceController(IPointRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var json = new { point = _repository.GetTotalPointByUserId(1) };
            return Ok(json);
        }

        [HttpGet]
        [Route("{userId:int}")]
        public IActionResult Get(int userId)
        {
            var json = new { point = _repository.GetTotalPointByUserId(userId) };
            return Ok(json);
        }
    }


    public class PointLogController : ControllerBase
    {

    }

    //[ApiController]
    [Route("api/[controller]")]
    public class PointLogServiceController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var json = new { point = 1234 };
            return Ok(json);
        }
    }

    [Route("api/[controller]")]
    public class PointStatusServiceController : ControllerBase
    {
        private IPointRepository _repository;

        public PointStatusServiceController(IPointRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var point = _repository.GetPointStatusByUser();

            return Ok(point);
        }

    }
}
