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

    [HttpGet("students")]
    public List<Students> GetAllStudents()
    {
        return _Db.Students.ToList();
    }

    [HttpGet("student/{id}")]
    public Students GetStudentById(int id)
    {
        return _Db.Students.FirstOrDefault(x => x.Id == id);
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
    public bool UpdateStudent(Students st)
    {
        var student = _Db.Students.FirstOrDefault(x => x.Id == st.Id);

        if (student != null)
        {
            student.Name = st.Name;
            student.Surname = st.Surname;
            student.Email = st.Email;
            student.PersonalNumber = st.PersonalNumber;
            student.Address = st.Address;

            _Db.SaveChanges();
            return true;
        }

        return false;
    }

    [HttpPut("updateemail")]
    public bool UpdateStudentEmail(int id, string newEmail)
    {
        var student = _Db.Students.FirstOrDefault(x => x.Id == id);

        if (student != null)
        {
            student.Email = newEmail;
            _Db.SaveChanges();
            return true;
        }

        return false;
    }
}





