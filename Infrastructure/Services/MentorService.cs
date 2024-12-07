using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class MentorService:IMentor
{
    private readonly DapperContext _context;

    public MentorService()
    {
        _context = new DapperContext();
    }


    public List<Mentor> GetMentors()
    {
        return _context.GetConnection().Query<Mentor>("SELECT * FROM Mentor").ToList();
    }

    public Mentor GetMentorById(int id)
    {
        return _context.GetConnection().QueryFirstOrDefault<Mentor>("SELECT * FROM Mentor WHERE MentorId = @Id", new { Id = id });
    }

    public bool AddMentor(Mentor mentor)
    {
        return _context.GetConnection().Execute("INSERT INTO Mentor(FirstName,LastName,Email,Phone,Address,BirthDate)", mentor) > 0;
    }

    public bool UpdateMentor(Mentor mentor)
    {
        return _context.GetConnection().Execute("update Mentor set FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, Address=@Address, BirthDate=@BirthDate where MentorId=@MentorId", mentor) > 0;
    }

    public bool DeleteMentor(int id)
    {
        return _context.GetConnection().Execute("delete from Mentor where MentorId=@MentorId", new { MentorId = id }) > 0;
    }
}