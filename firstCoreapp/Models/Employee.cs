using System.ComponentModel.DataAnnotations;

namespace firstCoreapp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? age { get; set; }
        public decimal? salary { get; set; }



    }
}
