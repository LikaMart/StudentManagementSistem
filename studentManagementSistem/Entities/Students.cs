using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Entities
{
    [Table("Students")]
    public class Students
    {
        [Key]
        public int Id { get; set; }

        [Required ]
        public string Name { get; set; }
        
        public string Email { get; set; }

        [Required ]
        public string PersonalNumber { get; set; }
        public string Address { get; set; }
    }
}
