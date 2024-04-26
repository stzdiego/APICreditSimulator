using System.ComponentModel.DataAnnotations.Schema;
using ApiCreditSimulator.Shared.Bases;

namespace ApiCreditSimulator.Shared.Entities;

public class Credit : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public int Term { get; set; }
    public decimal Rate { get; set; }
    public decimal MonthlyFee { get; set; }
    public decimal Total { get; set; }


    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

}
