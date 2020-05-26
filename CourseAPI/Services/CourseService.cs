using System;
using System.Collections.Generic;
using CourseAPI.Models;
using System.Linq;



namespace CourseAPI.Services
{
public class CourseService:ICourseService
{
public CourseContext _CourseList;
public CourseService(CourseContext CourseList)
{
            _CourseList=CourseList;
}
        
public List<Course> GetCourses()
{
            return _CourseList.Courses.ToList();
}

public Course GetbyId(int id)  
{
        if(id>0)
        {
             var course =_CourseList.Courses.Find(id);
             return course;
        }
        else
        {
             throw new ArgumentNullException("Id should be greater than zero!");
        }
}

public bool Addcourse(Course course)
{

        if(string.IsNullOrEmpty(course.CourseName))
        
             throw new Exception("First Name shouldn't be empty");
             _CourseList.Courses.Add(course);
             _CourseList.SaveChanges();
             return true;
        
}

public bool UpdateCourse(int id, Course co)
{
       if (id > 0)
       {

             var course =_CourseList.Courses.Find(id);
       if(course!= null)
       {
             course.CourseName=co.CourseName;
             course.CoursePreRequisites=co.CoursePreRequisites;
             course.CourseDescription=co.CourseDescription;               
             course.Credits=co.Credits;
             _CourseList.SaveChanges();
             return true;
       }
       else 
       {
             throw new Exception("There are no courses for this id");
       }
       }
       else 
       {
             throw new ArgumentNullException("Id should be greater than zero!");
       }
              
}

public bool Deletecourse(int id)
{
       if(id > 0)
       {

             var p=_CourseList.Courses.Find(id);
       if(p != null)
        {
           _CourseList.Remove(p);
           _CourseList.SaveChanges();
           return true;
        }
        else
        {
            throw new Exception("The id you are trying to delete is not present");
        }
        }
       else
        {
           throw new ArgumentNullException("Id should be greater than zero!");
        }

}

        // IEnumerable<Course> ICourseService.GetCourses()
        // {
        //     throw new NotImplementedException();
        // }
    }
}

