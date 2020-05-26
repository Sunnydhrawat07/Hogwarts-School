using System.Collections.Generic;
using UserAPI.Models;


namespace UserAPI.Services
{
public interface ITeacherService
{
List<Teacher> GetTeachers();
void AddTeacher(Teacher teacher);
Teacher GetbyId(int id);
void UpTeacher(int id, Teacher tc);
void PartialUpdtTeacher(int id, TeacherPatch tc);
bool DelTeacher(int id);
void UplAssessmnt(Assessment assessment);
void UploadResult(StudentResult studentResult);
        
}
}

