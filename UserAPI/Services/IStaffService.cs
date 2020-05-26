using System.Collections.Generic;
using UserAPI.Models;


namespace UserAPI.Services
{
public interface IStaffService
{
 List<Staff> GetStaff();
bool AddStaff(Staff staff);
Staff GetbyId(int id);
bool UpStaff(int id, Staff st);
bool PartialUpdtStaff(int id, StaffPatch st);
bool DelStaff(int id);
bool AddProspect(StudentProspect studentProspect);
List<StudentProspect> GetProspect(string status);

string  GetProspectCount(string status);

}
}

