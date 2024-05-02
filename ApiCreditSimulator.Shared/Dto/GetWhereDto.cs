using System.Linq.Expressions;

namespace ApiCreditSimulator.Shared.Dto;

public class GetWhereDto<T>
{
    public Expression<Func<T, bool>>? Predicate { get; set; }
}
