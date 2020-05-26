using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserAPI.Models
{

public class StudentPatch
{
        
[Column(TypeName="varchar(150)")]
public string Address { get; set; }
[MaxLength(10)]
[MinLength(10)]
[Column(TypeName="varchar(10)")]
public string ContactNumber { get; set; }
        
}
}

