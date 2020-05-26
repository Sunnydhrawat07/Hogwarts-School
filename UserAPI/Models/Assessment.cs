using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserAPI.Models
{

public class Assessment
{
[Key]
public int AssessmentId { get; set; }

[Required]
[Column(TypeName="varchar(30)")]
public string AssessmentName { get; set; }

[Required]
[Column(TypeName="varchar(200)")]
public string AssessmentLink { get; set; }

[Required]
[Column(TypeName="DateTime)")]
public DateTime DeadLine  { get; set; }

[ForeignKey("Teacher")]
public int TeacherId { get; set; }

}
}





//public virtual Teacher Teacher  { get; set; }