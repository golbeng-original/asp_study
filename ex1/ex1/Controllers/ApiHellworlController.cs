
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ex1.Controllers
{
    public class Dto
    {
        public int id { get; set; }

        // 최소 5자 
        [MinLength(5)]
        public string text { get; set; }


        public override string ToString()
        {
            return $"id = {id}, text = {text}";
        }

    }

    [ApiController]
    [Route("api/[controller]")] // <- [controller] : routeToken이라고 함. 
    public class ApiHelloworlDemoController : ControllerBase
    {
        // 선택적 route
        // {id?}
        // {id=1234} //default
        // {id:int} // 제약조건 int가 아니면 해당 route로 들어오지 않는다.

        [HttpGet("{id:int}")]
        public IActionResult Index(int id) {

            var content = @$"
<html>
    <body>
        <h1>안녕하세요. - {id}</h1>
    </body>
</htmldonet
";

            // HTML tag가 그대로 표시 된다.
            //return Content(content);

            // html 표현 할수 있는 페이지 response
            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html; charset=utf-8"

            };

            // 200 코드 반
            //return Ok()
        }

        // [FromBody] : body 값을 통해서 본문 내용 가져온다.
        // [FromQuery] : Query
        // [FromRoute] : Route에 정해진 특성 값


        // id 기본 값은 [FromRoute] 이다.
        [HttpGet("index2/{id?}")]
        //[Produces("application/json")] // <- 무조건 Json으로 제공
        public IActionResult Index2([FromRoute]int id, [FromQuery]int query)
        {
            var content = $"id = {id}, query = {query}";

            return Content(content);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Dto body)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest("유효성 검사 실패");
            }


            //return Content(body.ToString());
            return CreatedAtAction(nameof(Index), new { id = body.id }, body);
        }
    }
}
