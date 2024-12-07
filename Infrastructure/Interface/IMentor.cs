using Infrastructure.Models;

namespace Infrastructure.Interface;

public interface IMentor
{
    List<Mentor> GetMentors();
    Mentor GetMentorById(int id);
    bool AddMentor(Mentor mentor);
    bool UpdateMentor(Mentor mentor);
    bool DeleteMentor(int id);
}