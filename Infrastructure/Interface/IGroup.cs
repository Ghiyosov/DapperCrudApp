using Infrastructure.Models;
namespace Infrastructure.Interface;

public interface IGroup
{
    List<Group> GetGroups();
    Group GetGroupById(int id);
    bool AddGroup(Group group);
    bool UpdateGroup(Group group);
    bool DeleteGroup(int id);
    
}