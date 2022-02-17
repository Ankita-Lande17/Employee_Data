using System.ComponentModel.DataAnnotations;

namespace EmployeeData.Models
{
    public class Registration
    {
        [Required]
        [MaxLength(50)]
        public string FirstName
        {
            get;
            set;
        }
        [Required]
        [MaxLength(50)]
        public string LastName
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
        [Required]
        [MaxLength(50)]
        public string Password
        {
            get;
            set;
        }
        [Required]
        [MaxLength(30)]
        [EmailAddress]
        public string Email
        {
            get;
            set;
        }
        [Required]
        [MaxLength(10)]
        public string Contact
        {
            get;
            set;
        }
    }
}
