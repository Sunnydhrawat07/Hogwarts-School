using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserAPI.Models
{
public class StudentProspect
{
[Key]
public int ProspectId { get; set; }

[Required]
[Column(TypeName="varchar(30)")]
public string FirstName { get;  set; }

[Column(TypeName="varchar(30)")]
public string LastName { get; set; }

[Column(TypeName="date")]
public DateTime DateOfBirth { get;set; }

[Column(TypeName="varchar(10)")]
public string Gender { get; set; }

[Column(TypeName="varchar(30)")]
public string FatherName { get; set; }
        
[Column(TypeName="varchar(150)")]
public string Address { get; set; }

[Column(TypeName="varchar(10)")]
public string ContactNumber { get; set; } 

[Column(TypeName="varchar(10)")]
public string Status { get; set; }

}
}

