using System.ComponentModel.DataAnnotations;

namespace ex1.Controllers
{
    public class Value
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Text 속성은 필수 입력입니다.")]
        public string Text { get; set; }
    }

}