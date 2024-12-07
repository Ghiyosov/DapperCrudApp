using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class MentorGroupService:IMentorGroup
{
    private DapperContext _context;

    public MentorGroupService()
    {
        _context = new DapperContext();
    }


    public List<MentorGroup> GetMentorGroup()
    {
        var sql = @"select * from MentorGroup";
        var mentorgroup = _context.GetConnection().Query<MentorGroup>(sql);
        return mentorgroup.ToList();
    }

    public MentorGroup GetMentorGroupById(int id)
    {
        var sql = @"select * from MentorGroup where MentorGroupId = @Id";
        var mentorGroup = _context.GetConnection().QueryFirstOrDefault<MentorGroup>(sql, new { MentorGroupId = id });
        return mentorGroup;
    }

    public bool AddMentorGroup(MentorGroup mentorGroup)
    {
        var sql = @"insert into MentorGroup(MentorId,GroupId)values(@MentorId,@GroupId)";
        return _context.GetConnection().Execute(sql, mentorGroup) > 0;
    }

    public bool UpdateMentorGroup(MentorGroup mentorGroup)
    {
        var sql = @"update MentorGroup set MentorId=@MentorId where MentorGroupId = @MentorGroupId where MentorGroupId = @MentorGroupId";
        return _context.GetConnection().Execute(sql, mentorGroup) > 0;
    }

    public bool DeleteMentorGroup(int id)
    {
        var sql = @"delete from MentorGroup where MentorGroupId = @Id";
        return _context.GetConnection().Execute(sql, new { Id = id }) > 0;
    }
}