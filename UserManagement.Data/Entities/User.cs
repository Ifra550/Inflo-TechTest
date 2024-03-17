using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models;

public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [MinLength(2)]
    [Required(ErrorMessage = "Min length is 2")]
    public string Forename { get; set; } = default!;

    [MinLength(2)]
    [Required(ErrorMessage = "Min length is 2")]
    public string Surname { get; set; } = default!;

    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
    public string Email { get; set; } = default!;
    public bool IsActive { get; set; }

    [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$")]
    [Required(ErrorMessage = "Date of Birth is missing or incorrect.")]
    public string DateOfBirth { get; set;} = default!;
}
