using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserAPI.Models
{
public class StudentResult
{
[Key]
public int StudentResultId { get; set; }
[ForeignKey("Assessments")]
public int AssessmentId { get; set; }

[ForeignKey("Students")]
public int StudentId { get; set; }

[Column(TypeName="varchar(30)")]
public string FirstName { get; set; }

[Column(TypeName="varchar(30)")]
public string LastName { get; set; }

[Column(TypeName="varchar(50)")]
public string Remarks { get; set; }

}
}


