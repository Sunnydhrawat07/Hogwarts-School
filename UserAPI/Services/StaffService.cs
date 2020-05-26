using System;
using System.Collections.Generic;
using UserAPI.Models;
using System.Linq;




namespace UserAPI.Services
{
    public class StaffService:IStaffService
    {
         List<StudentProspect> Actpros = new List<StudentProspect>();
        public UserContext _Stafflist;
        public StaffService(UserContext Stafflist)
        {
            _Stafflist=Stafflist;
        }
        public List<Staff> GetStaff() 
       {
           return _Stafflist.Staff.ToList();
       }
          public bool AddStaff(Staff staff)
        {
            DateTime dob;
             if(string.IsNullOrEmpty(staff.FirstName))
                throw new Exception("First Name shouldn't be empty");

                  if(staff.ContactNumber.Length != 10)
                throw new Exception("Contact Number should be of ten digits");

            if(!DateTime.TryParse(staff.DateOfBirth.ToShortDateString(), out dob ))
                throw new Exception("Date Of Birth should be a date");

            _Stafflist.Staff.Add(staff);
            _Stafflist.SaveChanges();
            return true;

        }
        public Staff GetbyId(int id)  
        {
            if(id>0){

            
            var staff =_Stafflist.Staff.Find(id);
            return staff;
            }
            else
            {
                 throw new ArgumentNullException("Id should be greater than zero!");
            }
        }  
        public bool UpStaff(int id, Staff st)
        {
            if(id > 0)
            {
                var Staff =_Stafflist.Staff.Find(id);
               Staff.FirstName=st.FirstName;
               Staff.LastName=st.LastName;               
               Staff.Role=st.Role;
               Staff.DateOfBirth=st.DateOfBirth;
               Staff.Address=st.Address;
               Staff.ContactNumber=st.ContactNumber;
               _Stafflist.SaveChanges();
               return true;
            }
            else
            {
                throw new ArgumentNullException("Id should be greater than zero!");
            }

        }

        public  bool PartialUpdtStaff(int id, StaffPatch st)
        {
            var Staff =_Stafflist.Staff.Find(id);
            Staff.Address=st.Address;
            Staff.ContactNumber=st.ContactNumber;
            Staff.Role=st.Role;
            _Stafflist.SaveChanges();
            return true;
           
        }
        public bool DelStaff(int id)
        {
            var p=_Stafflist.Staff.Find(id);
          
           _Stafflist.Remove(p);

             // _Stafflist.Remove(p.FirstName);
             // _Stafflist.Remove(p.LastName);
             // _Stafflist.Remove(p.DateOfBirth);
             // _Stafflist.Remove(p.ContactNumber);
             //_Stafflist.Remove(p.Address);
             //_Stafflist.Remove(p.Role);


            //     p.FirstName = string.Empty;
            //    p.LastName = string.Empty;
            // p.DateOfBirth = DateTime.MinValue;
            //    p.ContactNumber = string.Empty;
            //   p.Address = string.Empty;
            //   p.Role = string.Empty;



            _Stafflist.SaveChanges();
            return true;
        }
       
         public bool AddProspect(StudentProspect studentProspect)
        {
            studentProspect.Status = studentProspect.Status.ToUpper();
            if(!studentProspect.Status.Equals("ACTIVE") && !studentProspect.Status.Equals("PASSIVE"))
                throw new Exception("Status should be Active or Passive");
            if(studentProspect.DateOfBirth > DateTime.Now)
                throw new Exception("Date Of Birth can't be more than present day");
            TimeSpan difference = DateTime.Now.Subtract(studentProspect.DateOfBirth);
            var days= difference.Days;
            if((days/365)>=5)
            {
            _Stafflist.StudentProspects.Add(studentProspect);
            _Stafflist.SaveChanges();
            return true;
            }
            else
                throw new Exception("Age should be more than 5 years");
        } 
        
        public List<StudentProspect> GetProspect(string status)
        {
            status = status.ToUpper();
            if(status.Equals("ACTIVE") || status.Equals("PASSIVE"))
            {
                var student = _Stafflist.StudentProspects.Where( item => item.Status == status).ToList();
                return student;
            }
            else
                throw new Exception("Status input should be Active or Passive");

    }

        public string GetProspectCount(string status)
        {
            
          status = status.ToUpper();
            if(status.Equals("ACTIVE") || status.Equals("PASSIVE"))
            {
                int prospectCount = _Stafflist.StudentProspects.Where( item => item.Status == status).Count();
                return $"The total no of {status} prospect(s) is {prospectCount}";
            }
            else
                throw new Exception("Status input should be Active or Passive");  
        }
    }
}




