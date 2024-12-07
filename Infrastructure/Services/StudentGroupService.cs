using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class StudentGroupService: IStudentGroup
{
    DapperContext _context;

    public StudentGroupService()
    {
        _context = new DapperContext();
    }
    
    public List<StudentGroup> GetStudentGroups()
    {
        return _context.GetConnection().Query<StudentGroup>("SELECT * FROM StudentGroup").ToList();
    }

    public StudentGroup GetStudentGroupById(int id)
    {
        return _context.GetConnection().QueryFirstOrDefault<StudentGroup>("SELECT * FROM StudentGroup WHERE StudentGroupId = @Id", new { Id = id });
    }

    public bool AddStudentGroup(StudentGroup studentGroup)
    {
        return _context.GetConnection().Execute("insert into StudentGroup(MentorId,GroupId) values(@MentorId,@GroupId)",studentGroup)>0;
    }

    public bool UpdateStudentGroup(StudentGroup studentGroup)
    {
        return _context.GetConnection().Execute("update StudentGroup set MentorId=@MentorId, GroupId=@GroupId where StudentGroupId = @StudentGroupId",studentGroup)>0;
    }

    public bool DeleteStudentGroup(int id)
    {
        return _context.GetConnection().Execute("delete from StudentGroup where StudentGroupId = @StudentGroupId",new { StudentGroupId = id })>0;
    }
}