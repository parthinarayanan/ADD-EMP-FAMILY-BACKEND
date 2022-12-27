using Microsoft.AspNetCore.Mvc;
using backend.Models;
namespace backend.Controllers;
[ApiController]
[Route("api/EmpFamilys")]
public class EmpFamilyController : ControllerBase
{
    private readonly EmpfamilyContext DB;
    public EmpFamilyController(EmpfamilyContext db)
    {
        this.DB=db;
    } 
//get all data vivew method
     [HttpGet("GetAllEmp")]
    public IQueryable<Empfamily>GetAllEmp()

    {
        try{
            return DB.Empfamilies;
        }
        catch(System.Exception)
        {
            throw;
        }
    }
//Insert method
    [HttpPost("InsertEmp")]
    public object InsertEmp(Register regobj)
    {
        try
        {
            Empfamily e1 = new Empfamily();
            if(e1.Id == 0)
            {

                e1.EmployeeCode= regobj.RegEmployeeCode;
                e1.DependencyType=regobj.RegDependencyType;
                e1.DependencyDob=regobj.RegDependencyDob;
                e1.Age=regobj.RegAge;
                e1.DependencyOccupation=regobj.RegDependencyOccupation;
                e1.DependencyAadhaarNumber=regobj.RegDependencyAadhaarNumber;
                e1.DependencyPanNumber=regobj.RegDependencyPanNumber;
                
                DB.Empfamilies.Add(e1);
                
                DB.SaveChanges();
                return new Responce{Status="Success",Message=" Added"};
            }
            }
        catch(System.Exception)
        {
          throw;
        }
        return new Responce{Status="Error",Message="Invalid Information"};
        
    }
    //delete method

    [HttpDelete("DeleteEmpDetails/{uid}")]
    public IActionResult DeleteUser(int uid)
    {
        string message = "";
            var user = this.DB.Empfamilies.Find(uid);
            if (user == null)
            {
                return NotFound();
            }

            this.DB.Empfamilies.Remove(user);
            int result = this.DB.SaveChanges();
            if (result > 0)
            {
                message = "User has been sussfully deleted";
            }
            else
            {
                message = "failed";
            }

            return Ok(message);
        }
}