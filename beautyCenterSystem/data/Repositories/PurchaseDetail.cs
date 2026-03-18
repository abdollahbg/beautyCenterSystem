public class PurchaseDetail
{
    public int DetailID { get; set; } 
    public int InvoiceID { get; set; }
    public int MaterialID { get; set; }
    public string MaterialName { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalAmount => Quantity * UnitPrice;
    public PurchaseDetail() { }
}