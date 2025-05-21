using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment_1_Exam_Week_1.Data.Entities
{
    [Table("UserDetail", Schema = "dbo")]
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "User Id")]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "User Full Name")]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "User Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(12)")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "varchar(12)")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
