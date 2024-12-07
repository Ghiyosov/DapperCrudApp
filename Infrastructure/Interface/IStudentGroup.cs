using Infrastructure.Models;

namespace Infrastructure.Interface;

public interface IStudentGroup
{
    List<StudentGroup> GetStudentGroups();
    StudentGroup GetStudentGroupById(int id);
    bool AddStudentGroup(StudentGroup studentGroup);
    bool UpdateStudentGroup(StudentGroup studentGroup);
    bool DeleteStudentGroup(int id);
}