namespace MS.UI.DtoLayer.OrderDtos.OrderOrderingDtos;

public class ResultOrderingByUserIdDto
{
    public int OrderingId { get; set; }
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
