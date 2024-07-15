using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace firstCoreapp.Models
{
    public class item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        
        [ForeignKey("cat")]
        [Required]
        public int categoryID { get; set; }

        public string? imagepath { get; set; }

        [NotMapped]
        public IFormFile? clientFile { get; set; }

      public category? cat { get; set; }
    }

    //fluent api insteadof data annotation
    //public class itemvalidator : AbstractValidator<item>
    //{
    //    public itemvalidator()
    //    {
    //        RuleFor(x => x.Name).NotEmpty();
    //    }
    //}
}
