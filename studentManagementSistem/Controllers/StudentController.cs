using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Db;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{

    private readonly StudentDbContext _Db;


    public StudentController()
    {
        _Db = new StudentDbContext();
    }

    // GET: api/<StudentController>
    [HttpGet("students")]
    public List<Students> Getallstudents()
    {
        return _Db.Students.ToList();
    }

    [HttpPost("addstudent")]
    public void AddStudent(Students st)
    {
        _Db.Students.Add(st);
        _Db.SaveChanges();
    }

    [HttpDelete("deletestudent")]
    public bool DeleteStudent(int id)
    {
        var student = _Db.Students.FirstOrDefault(x => x.Id == id);
        if (student != null)
        {
            _Db.Students.Remove(student);
            _Db.SaveChanges();
            return true;
        }
        return false;
    }

    [HttpPut("updatestudent")]
public bool UpdateStudentEmail(int id, string newEmail)
    {
        var student = _Db.Students.FirstOrDefault(x => x.Id == id);
        if (student != null)
        {
            student.Name = newEmail;
            student.Email = newEmail;
            _Db.SaveChanges();
            return true;
        }
        return false;
    }
}







