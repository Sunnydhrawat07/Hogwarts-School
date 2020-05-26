using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace CourseAPI.Models
{
public class Course
{

[Key]
public int CourseId{get;set;}

[Required]
[Column(TypeName="Varchar(30)")]
public string CourseName{get;set;}

[Column(TypeName="Varchar(100)")]
public string CoursePreRequisites { get; set; }

[Column(TypeName="varchar(500)")]
public string CourseDescription { get; set; }

[Column(TypeName="int")]
public int Credits { get; set; }

}
}


