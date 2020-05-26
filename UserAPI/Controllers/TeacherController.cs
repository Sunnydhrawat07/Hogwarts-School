using Microsoft.AspNetCore.Mvc;
using UserAPI.Services;
using UserAPI.Models;
using System;
using System.Collections.Generic;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController:ControllerBase
{
     public ITeacherService _ITeacherService;
        public TeacherController(ITeacherService ITeacherService)
    {
        this._ITeacherService=ITeacherService;
    }
    
[HttpGet("AllTeachersDetails")]
public ActionResult GetTeachers()
{
            List<Teacher> teachersData = this._ITeacherService.GetTeachers();
            if(teachersData.Count > 0)
                return Ok(teachersData);
            else
                return NotFound();
}

[HttpPost("AddTeacherDetails")]
public ActionResult Post([FromBody]Teacher teacher)
{
            try
            {
                 this._ITeacherService.AddTeacher(teacher);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
                 return Ok();
}
        
[HttpGet("GetTeacherDetails/{id}")]
public ActionResult Get(int id)
{
            try
            {
                var teacherData = this._ITeacherService.GetbyId(id);
                
                if(teacherData != null)
                    return Ok(teacherData);
                else
                    return NotFound(); 
            }
            catch(Exception ex)
            {
                 return BadRequest(ex.Message);
            } 
}
        
[HttpPut("UpdateTeacherDetails/{id}")]
public ActionResult Put(int id,Teacher st)
{
            try
            {
                 this._ITeacherService.UpTeacher(id,st);
            }
            catch(Exception ex)
            {
                 return BadRequest(ex.Message);
            }
                 return Ok();               
}

[HttpPatch("PartialUpdtTeacher/{id}")]
public ActionResult PutPar(int id,TeacherPatch tc)
{
             this._ITeacherService.PartialUpdtTeacher(id,tc);
             return Ok();               
}

[HttpDelete("DeleteTeacherDetails/{id}")]
public ActionResult Delete(int id)
{
         try
         {
            bool result = this._ITeacherService.DelTeacher(id);
            if(result)
                return Ok();
            else
                return NotFound("The Id you're trying to delete was not found");
         }
         catch(Exception ex)
         {
             return BadRequest(ex.Message);
         }           
} 

[HttpPost("UploadAssessment")]
public ActionResult PostAssessment(Assessment assessment)
{
            try
            {
                this._ITeacherService.UplAssessmnt(assessment);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
} 

[HttpPost("UploadResult")]
public ActionResult PostResult(StudentResult studentResult)
{
            try
            {
                this._ITeacherService.UploadResult(studentResult);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
} 
        
}
}

