using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstCoreapp.Models
{
    public class category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }


       public  ICollection<item>? items { get; set; }

        [NotMapped]
        public IFormFile? clientFile { get; set; }

        public byte[]? dbimage { get; set; }

        [NotMapped]
        public string? imgSrc
        {
            get
            {
                if(dbimage !=null)
                {
                    string base64String = Convert.ToBase64String(dbimage, 0, dbimage.Length);
                    return "data:image/jpg;base64," + base64String;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
