using System.Collections.Generic;
using CourseAPI.Models;


namespace CourseAPI.Services
{

public interface ICourseService
{
List<Course> GetCourses();

Course GetbyId(int id);

bool Addcourse(Course course);

bool UpdateCourse(int id, Course co);

bool Deletecourse(int id);

}
}



