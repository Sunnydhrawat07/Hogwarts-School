using System;
using System.Collections.Generic;
using System.Linq;
using UserAPI.Models;



namespace UserAPI.Services
{
    public class TeacherService:ITeacherService
    {
         public UserContext _Teacherlist;
        
        public TeacherService(UserContext Teacherlist)
        {
            _Teacherlist=Teacherlist;
        }
        public List<Teacher> GetTeachers() 
       {
           return _Teacherlist.Teachers.ToList();
       }
        public void AddTeacher(Teacher teacher)
        {
            DateTime dob;
            if(string.IsNullOrEmpty(teacher.FirstName))
                throw new Exception("First Name shouldn't be empty");

            if(teacher.ContactNumber.Length != 10)
                throw new Exception("Contact Number should be of ten digits");

            if(!DateTime.TryParse(teacher.DateOfBirth.ToShortDateString(), out dob ))
                throw new Exception("Date Of Birth should be a date");
            // && !string.IsNullOrEmpty(teacher.LastName) &&
            //  !string.IsNullOrEmpty(teacher.Gender) && !string.IsNullOrEmpty(teacher.ContactNumber) &&
            //  teacher.ContactNumber.Length == 10 && string.IsNullOrEmpty(teacher.Qualification) &&
            //  teacher.Experience >= 0 || string.IsNullOrEmpty(teacher.Address)
            _Teacherlist.Teachers.Add(teacher);
            _Teacherlist.SaveChanges();         
        }   
        public Teacher GetbyId(int id)  
        {
            if(id>0)
            {

            
            var Teacher =_Teacherlist.Teachers.Find(id);
            return Teacher;
            }
            else
            {
                 throw new ArgumentNullException("Id should be greater than zero!");
            }
        }  
        public void UpTeacher(int id, Teacher tc)
        {

if(id>0)
{


            var teacher =_Teacherlist.Teachers.Find(id);
               teacher.FirstName=tc.FirstName;
               teacher.LastName=tc.LastName;               
               teacher.Qualification=tc.Qualification;
               teacher.DateOfBirth=tc.DateOfBirth;
               teacher.Address=tc.Address;
               teacher.Experience=tc.Experience;
               teacher.ContactNumber=tc.ContactNumber;
               teacher.Gender=tc.Gender;
               _Teacherlist.SaveChanges();
}
else
{
 throw new ArgumentNullException("Id should be greater than zero!");
}
        }

        public  void PartialUpdtTeacher(int id, TeacherPatch tc)
        {
            var teacher =_Teacherlist.Teachers.Find(id);
            teacher.Address=tc.Address;
            teacher.Experience=tc.Experience;
            teacher.ContactNumber=tc.ContactNumber;
            teacher.Qualification=tc.Qualification;
            _Teacherlist.SaveChanges();
        }
        public bool DelTeacher(int id)
        {
            if(id>0)
            {
                  var p=_Teacherlist.Teachers.Find(id);
                if(p!=null)
                {
                    _Teacherlist.Remove(p);
                    
                    _Teacherlist.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                

                throw new ArgumentNullException("Id should be greater than zero");
            }
            
        
}

        public void UplAssessmnt(Assessment assessment)
        {
            var item = _Teacherlist.Teachers.Find(assessment.TeacherId);
            if(item != null)
            {
                _Teacherlist.Assessments.Add(assessment);
                _Teacherlist.SaveChanges();
            }
            else
                throw new Exception("The Teacher doesn't exist");
        }  
         public void UploadResult(StudentResult studentResult)
        {
            var studentdata =  _Teacherlist.Students.Find(studentResult.StudentId);
            var assessmentdata = _Teacherlist.Assessments.Find(studentResult.AssessmentId);
            if(studentdata == null)
                throw new Exception("The Student doesn't exist");
            if(assessmentdata == null)
                throw new Exception("The Assessment doesn't exist");
            _Teacherlist.StudentResults.Add(studentResult);
            _Teacherlist.SaveChanges();
         
        }

      
    }
}









//_Teacherlist.Remove(p.FirstName);
              //_Teacherlist.Remove(p.LastName);
              //_Teacherlist.Remove(p.DateOfBirth);
              //_Teacherlist.Remove(p.ContactNumber);
              //_Teacherlist.Remove(p.Address);
              //_Teacherlist.Remove(p.Gender);
              //_Teacherlist.Remove(p.Experience);