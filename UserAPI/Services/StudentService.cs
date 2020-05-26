using System;
using System.Collections.Generic;
using UserAPI.Models;
using System.Linq;


namespace UserAPI.Services
{
    public class StudentService:IStudentService
    {
         public UserContext _Studentlist;
        public StudentService(UserContext Studentlist)
        {
            _Studentlist=Studentlist;
        }
        public List<Student> GetStudents() 
       {
           return _Studentlist.Students.ToList();
       }
        public void AddStudent(Student student)
        {
             DateTime dob;
             if(string.IsNullOrEmpty(student.FirstName))
                throw new Exception("First Name shouldn't be empty");

                  if(student.ContactNumber.Length != 10)
                throw new Exception("Contact Number should be of ten digits");

            if(!DateTime.TryParse(student.DateOfBirth.ToShortDateString(), out dob ))
                throw new Exception("Date Of Birth should be a date");
            _Studentlist.Students.Add(student);
            _Studentlist.SaveChanges();
         
        }   
        public Student GetbyId(int id)  
        {
            if(id>0)
            {

            
            var Pro =_Studentlist.Students.Find(id);
            return Pro;
            }
             else
            {
                 throw new ArgumentNullException("Id should be greater than zero!");
            }
        }  
        public void UpStud(int id, Student st)
        {
            if(id>0)
            {
            
            

            var student =_Studentlist.Students.Find(id);
             // pt.ProductId=pr.ProductId;
               student.FirstName=st.FirstName;
               student.LastName=st.LastName;               
               student.FatherName=st.FatherName;
               student.DateOfBirth=st.DateOfBirth;
               student.Address=st.Address;
               student.ContactNumber=st.ContactNumber;
               student.Gender=st.Gender;
               _Studentlist.SaveChanges();
            
               }
               else
            {
                throw new ArgumentNullException("Id should be greater than zero!");
            }
        }

        public  void PartialUpStud(int id, StudentPatch st)
        {
            var student =_Studentlist.Students.Find(id);
            student.Address=st.Address;
            student.ContactNumber=st.ContactNumber;
            _Studentlist.SaveChanges();
        }
        public void DelStudent(int id)
        {
            var p=_Studentlist.Students.Find(id);
            _Studentlist.Remove(p);
            _Studentlist.SaveChanges();

              //_Studentlist.Remove(p.FirstName);
              //_Studentlist.Remove(p.LastName);
              //_Studentlist.Remove(p.DateOfBirth);
              //_Studentlist.Remove(p.ContactNumber);
              //_Studentlist.Remove(p.Address);
              //_Studentlist.Remove(p.FatherName);
              //_Studentlist.Remove(p.Gender);
              
        }

     
    }
}