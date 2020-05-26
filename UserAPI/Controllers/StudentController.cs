using UserAPI.Services;
using UserAPI.Models;
using Microsoft.AspNetCore.Mvc;
using CourseAPI.Services;
using System.Collections.Generic;
using System;
using CourseAPI.Models;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController:ControllerBase
    {
         public ICourseService _ICourseService;
        public IStudentService _IStudentService;
        public StudentController(ICourseService ICourseService,IStudentService IStudentService)
        {
             this._ICourseService =ICourseService;
        _IStudentService=IStudentService;
        }

 [HttpGet("CourseDetails")]
public ActionResult Get()
{
    List<Course> CourseData=this._ICourseService.GetCourses();
      if(CourseData.Count>0)
       {
           return Ok(CourseData);
      } 
      else
      {
           return NotFound();
      }   
}

[HttpGet("AllStudentsDetails")]
public ActionResult GetAllStudents()
{
    List<Student> StudentData=this._IStudentService.GetStudents();
    if(StudentData.Count>0)
    {

    
            return Ok(StudentData);
    }
    else{
        return NotFound();
    }
}

[HttpPost("AddStudentDetails")]
 public ActionResult Post(Student student)
        {
             try
    {
          this._IStudentService.AddStudent(student);    
    }
    catch(Exception ex)
    {
              return BadRequest(ex.Message);
    }
    finally
    {

    }
            return Ok();
            
        }
        
[HttpGet("GetStudentDetails/{id}")]
public ActionResult Get(int id)
{
             try
    {
        var item =  this._IStudentService.GetbyId(id);
        if(item!=null)
        {
              return Ok(item);
        }
        else 
        {
              return NotFound();
        }
    }
   
    catch(Exception ex)
    {
             return BadRequest(ex.Message);
    }
    finally
    {

    }
           
            
    }
        
[HttpPut("UpdateStudentDetails/{id}")]
public ActionResult Put(int id,Student st)
{
    try
    {
            this._IStudentService.UpStud(id,st);
    }
    catch(Exception ex)
    {
            return BadRequest(ex.Message);
    }
            return Ok();               
}

[HttpPatch("PartialUpdateStudent/{id}")]
public ActionResult PutPar(int id,StudentPatch st)
{
            this._IStudentService.PartialUpStud(id,st);
            return Ok();               
}

[HttpDelete("DeleteStudentDetails/{id}")]
public ActionResult Delete(int id)
{
        if(id>=1)
        {
             this._IStudentService.DelStudent(id);
           return Ok();
        }
        else
        {
                 return BadRequest();
        }

}
        
}
}

