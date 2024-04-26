using ApiCreditSimulator.Shared.Bases;
using Microsoft.EntityFrameworkCore;

namespace ApiCreditSimulator.Shared.Entities;

[Index(nameof(Nickname), IsUnique = true)]
public class User : BaseEntity
{
    public string Nickname { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
