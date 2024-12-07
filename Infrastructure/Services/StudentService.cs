using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class StudentService: IStudent
{
    readonly DapperContext _context;

    public StudentService()
    {
        _context = new DapperContext();
    }


    public List<Student> GetStudents()
    {
        return _context.GetConnection().Query<Student>("SELECT * FROM Student").ToList();

    }

    public Student GetStudentById(int id)
    {
        return _context.GetConnection().QueryFirstOrDefault<Student>("SELECT * FROM Student WHERE StudentId = @Id", new { Id = id });
    }

    public bool AddStudent(Student student)
    {
        return _context.GetConnection().Execute("INSERT INTO Student(FirstName,LastName,Email,Phone,Address,BirthDate)", student) > 0;
    }

    public bool UpdateStudent(Student student)
    {
        return _context.GetConnection().Execute("update Student set FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, Address=@Address, BirthDate=@BirthDate where StudentId=@StudentId", student) > 0;
    }

    public bool DeleteStudent(int id)
    {
        return _context.GetConnection().Execute("delete from Student where StudentId=@StudentId", new { StudentId = id }) > 0;
    }
}