using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserAPI.Models
{
public class StaffPatch
{
        
[Required]
[MinLength(10)]
[MaxLength(10)]
[Column(TypeName="varchar(10)")]
public string ContactNumber { get; set; }

[Required]
[Column(TypeName="varchar(150)")]
public string Address { get; set; }

[Required]
[Column(TypeName="varchar(30)")]
public string Role { get; set; }
        
}
}

