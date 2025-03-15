namespace MS.Cargo.EntityLayer.Concrete;

public class CargoOperation
{
    public int CargoOperationId { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationDate { get; set; }
}
