using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        [Column("Ordering")]
        public int Order { get; set; }
        public string? Url { get; set; }
    }
}