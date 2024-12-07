using Infrastructure.Models;

namespace Infrastructure.Interface;

public interface IStudent
{
    List<Student> GetStudents();
    Student GetStudentById(int id);
    bool AddStudent(Student student);
    bool UpdateStudent(Student student);
    bool DeleteStudent(int id);
}