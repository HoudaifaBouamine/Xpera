using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace App.API.Entities
{
    //[Index(nameof(Email), IsUnique = true)]
    public class User
    {

        [Key]
        [Column(nameof(User_Id))]
        public int User_Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [MinLength(1)]
        public string FirstName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(20)")]
        [MinLength(1)]
        public string LastName { get; set; } = string.Empty;
        
        [Column(TypeName = "nvarchar(100)")]
        [MinLength(1)]
        public string Email { get; set; } = string.Empty;


        [Column(TypeName = "nvarchar(100)")]
        [MinLength(1)]
        public string HashedPassword { get; set; } = string.Empty;


        
    }
}
