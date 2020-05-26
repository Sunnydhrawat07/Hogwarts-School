using System;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.Services;
using System.Collections.Generic;



namespace UserAPI.Controllers
{

[ApiController]
[Route("[controller]")]
public class StaffController:ControllerBase
{
public IStaffService _IStaffService;

public StaffController(IStaffService IStaffService)
{
            this._IStaffService=IStaffService;
}

[HttpGet("WholeStaffDetails")]
public ActionResult GetStaff()
{
List<Staff> StaffData=this._IStaffService.GetStaff();

        if (StaffData.Count>0)
                {
                     return Ok(StaffData);
                }
        else
                {
                     return NotFound();
                }
}          

[HttpPost("AddnewStaff")]
public ActionResult Post(Staff staff)
{
    try
    {
              this._IStaffService.AddStaff(staff);
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
        
[HttpGet("StaffDetails/{id}")]
public ActionResult Get(int id)
{
    try
    {
        var item = this._IStaffService.GetbyId(id);
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

[HttpPut("UpdateStaffDetails/{id}")]
public ActionResult Put(int id,[FromBody]Staff st)
{
    try
    {
         this._IStaffService.UpStaff(id,st);
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

[HttpPatch("PartialUpdateStaff/{id}")]
public ActionResult Putpar(int id,[FromBody]StaffPatch st)
{
            this._IStaffService.PartialUpdtStaff(id,st);
            return Ok();               
}

[HttpDelete("DeleteStaffDetails/{id}")]
 public ActionResult Delete(int id)
{
            if(id >= 1)
            {
                this._IStaffService.DelStaff(id);
                return Ok();
            }
            else return BadRequest();
}

[HttpPost("AddProspectDetails")]
public ActionResult AddProspect(StudentProspect StudentProspect )
{
            try
            {
                bool result = this._IStaffService.AddProspect(StudentProspect);
                if(result)
                    return Ok();
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

[HttpGet("GetProspectDetails/{status}")]
public ActionResult GetProspect(string status)
{
             List<StudentProspect> item = this._IStaffService.GetProspect(status);
             if(item.Count > 0)
                return Ok(item);
             else
                return NotFound("No Active Student Prospects found");
}
[HttpGet("GetTotalStautsCount/{status}")]
public ActionResult GetProspectCount(string status)
{
try
{



string item = this._IStaffService.GetProspectCount(status);
return Ok(item);
}
catch(Exception ex)
{
return BadRequest(ex.Message);
}
finally
{

}


}

}
}




