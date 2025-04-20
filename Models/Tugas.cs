using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementAPI.Models
{
    public class Tugas
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // Contoh: "Belum dimulai", "Sedang dikerjakan", "Selesai"

        [ForeignKey("Assignee")]
        public int? AssigneeId { get; set; } // Nullable foreign key
        public virtual User Assignee { get; set; }

        [ForeignKey("Creator")]
        [Required]
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }
    }

}