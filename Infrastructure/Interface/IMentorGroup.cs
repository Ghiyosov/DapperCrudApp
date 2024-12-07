using Infrastructure.Models;

namespace Infrastructure.Interface;

public interface IMentorGroup
{
    List<MentorGroup> GetMentorGroup();
    MentorGroup GetMentorGroupById(int id);
    bool AddMentorGroup(MentorGroup mentorGroup);
    bool UpdateMentorGroup(MentorGroup mentorGroup);
    bool DeleteMentorGroup(int id);
    
}