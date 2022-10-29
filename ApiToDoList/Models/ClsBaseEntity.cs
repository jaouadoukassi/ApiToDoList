using System.ComponentModel.DataAnnotations;

namespace ApiToDoList.Models
{
    public class ClsBaseEntity
    {
        [Required]
        public int Id { get; set; }
        public string? CreateTasks { get; set; } 
        public DateTime? CreatedAtTime { get; set; } = DateTime.Now;
        public string? UpdateTasks { get; set; }
        public DateTime? UpDateAtTime { get; set; } = DateTime.Now;
        public string? DeleteTasks { get; set; }
        public DateTime? DeletedAtTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
