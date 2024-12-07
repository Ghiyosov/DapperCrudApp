using System.Reflection.Metadata.Ecma335;

namespace Infrastructure.Models;

public class Group
{
    public int GroupId { get; set; }
    public string GroupName { get; set; }
    public int CorseId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}