using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Nationality { get; set; }
    }
}
