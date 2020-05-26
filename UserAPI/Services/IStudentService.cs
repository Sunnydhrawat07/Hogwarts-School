using System.Collections.Generic;
using UserAPI.Models;


namespace UserAPI.Services
{
public interface IStudentService
{
List<Student> GetStudents();
void AddStudent(Student student);
Student GetbyId(int id);
void UpStud(int id, Student st);
void DelStudent(int id);
void PartialUpStud(int id, StudentPatch st);

}
}

