using Infrastructure.Models;

namespace Infrastructure.Interface;

public interface ICourse
{
    List<Course> GetCourses();
    Course GetCourseById(int id);
    bool AddCourse(Course course);
    bool UpdateCourse(Course course);
    bool DeleteCourse(int id);
}