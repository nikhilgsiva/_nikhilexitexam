namespace TodoApp.API.Models
{
    public class Todo
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? IsCompletedDate {get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
