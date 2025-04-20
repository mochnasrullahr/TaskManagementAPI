using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<User>? Users { get; set; }
    }
}