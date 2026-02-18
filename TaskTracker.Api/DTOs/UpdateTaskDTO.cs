using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Api.DTOs
{
    public class UpdateTaskDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public string Status { get; set; } = "Open";
    }
}
