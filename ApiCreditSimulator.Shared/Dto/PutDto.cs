namespace ApiCreditSimulator.Shared.Dto;

public class PutDto<T>
{
    public int Id { get; set; }
    public T? Entity { get; set; }
}
