using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserAPI.Models
{
public class Teacher
{
         [Key]
        public int TeacherId { get; set; }

        
        [Column(TypeName="varchar(30)")]
        public string FirstName { get; set; }

        [Column(TypeName="varchar(30)")]
        public string LastName { get; set; }

        [Column(TypeName="date")]
        public DateTime DateOfBirth { get;set; }

        [Column(TypeName="varchar(10)")]
        public string Gender { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        [Column(TypeName="varchar(10)")]
        public string ContactNumber { get; set; }

        [Column(TypeName="varchar(30)")]
        public string Qualification { get; set; }

        [Column(TypeName="int")]
        public int Experience { get; set; }

        [Column(TypeName="varchar(150)")]
        public string Address { get; set; }
    }
}