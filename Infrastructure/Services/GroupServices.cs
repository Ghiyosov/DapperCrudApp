using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class GroupServices: IGroup
{
    private readonly DapperContext _context;

    public GroupServices()
    {
        _context = new DapperContext();
    }
    public List<Group> GetGroups()
    {
        var sql = @"select * from Group";
        var groups = _context.GetConnection().Query<Group>(sql).ToList();
        return groups;
    }

    public Group GetGroupById(int id)
    {
        var sql = @"select * from Group where GroupId = @Id";
        var group = _context.GetConnection().QueryFirstOrDefault<Group>(sql, new { Id = id });
        return group;
    }

    public bool AddGroup(Group group)
    {
        var sql = @"insert into Group(GroupName,CorseId,StartDate,EndDate)
                    values(@GroupName,@CorseId,@StartDate,@EndDate)";
        var result = _context.GetConnection().Execute(sql, group);
        return result > 0;
    }

    public bool UpdateGroup(Group group)
    {
         var sql = @"update Group set GroupName=@GroupName,CorseId=@CorseId,StartDate=@StartDate,EndDate=@EndDate where GroupId = @GroupId";
         var result = _context.GetConnection().Execute(sql, group);
         return result > 0;
    }

    public bool DeleteGroup(int id)
    {
        var sql = @"delete from Group where GroupId = @GroupId";
        var result = _context.GetConnection().Execute(sql, new { GroupId = id });
        return result > 0;
    }
}