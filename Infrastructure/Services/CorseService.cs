using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class CorseService: ICourse
{
    private readonly DapperContext _context;

    public CorseService()
    {
        _context = new DapperContext();
    }
    
    public List<Course> GetCourses()
    {
        var sql = @"select * from Course";
        var courses =  _context.GetConnection().Query<Course>(sql).ToList();
        return courses;
    }

    public Course GetCourseById(int id)
    {
        var sql = @"select * from Course where CourseId = @Id";
        var course = _context.GetConnection().QueryFirstOrDefault<Course>(sql, new { Id = id });
        return course;
    }

    public bool AddCourse(Course course)
    {
        var sql = @$"insert into Course(CourseName,CourseDescription)
                    values (@Name,@Description)";
        var result = _context.GetConnection().Execute(sql, course);
        return result > 0;
    }

    public bool UpdateCourse(Course course)
    {
        var sql = $@"update Course set CourseName = @Name,CourseDescription = @Description where CourseId = @CourseId";
        var result = _context.GetConnection().Execute(sql, course);
        return result > 0;
    }

    public bool DeleteCourse(int id)
    {
        var sql = $@"delete from Course where CourseId = @Id";
        var result = _context.GetConnection().Execute(sql, new { Id = id });
        return result > 0;
    }
}