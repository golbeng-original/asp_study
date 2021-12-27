using System;
namespace ex1.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Secret { get; set; }
    }

    public class TodoItemDTO
    {
        public TodoItemDTO() {}

        public TodoItemDTO(TodoItem modelItem)
        {
            this.Id = modelItem.Id;
            this.Name = modelItem.Name;
            this.IsComplete = modelItem.IsComplete;
        }


        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
