using System;
using Microsoft.AspNetCore.Mvc;
using CourseAPI.Services;
using CourseAPI.Models;

//Namespace
namespace CourseAPI.Controllers
{
//Defining of Route
[ApiController]
[Route("[controller]")]

public class CourseController:ControllerBase
{

public ICourseService _ICourseService;
         
public CourseController(ICourseService ICourseService)
{
            this._ICourseService=ICourseService;
}

//GET api/values
[HttpGet("CourseDetails/{id}")]
public ActionResult Get(int id)
{
    try
          {
               var item = this._ICourseService.GetbyId(id);
               if(item != null)
                 return Ok(item);
               else
                 return NotFound();
          } 
     catch(Exception ex)
          {
                 return BadRequest(ex.Message);
          }
    finally
          {

          }
}
         
//Post api/values
[HttpPost("AddnewCourseDetails")]
public ActionResult Post(Course course)
{
     try
          {
               bool result= this._ICourseService.Addcourse(course);
               if(result)
               {
                  return Ok();
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

//PUT api/values
[HttpPut("UpdateCourseDetails/{id}")]
public ActionResult Put(int id,[FromBody]Course co)
{
    try
         {
               this._ICourseService.UpdateCourse(id,co);
         }
    catch(Exception ex)
         {
               return BadRequest(ex.Message);//this was giving error when executed in swagger and the error was shown in here
         }
    finally
         {

         }
              return Ok();
}

//DELETE api/values
[HttpDelete("DeleteCourseDetails/{id}")]
public ActionResult Delete(int id)
{
    try
         {
               this._ICourseService.Deletecourse(id);
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
}
}
       


        
    




