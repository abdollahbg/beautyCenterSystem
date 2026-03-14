public class PurchaseDetail
{
    public int InvoiceID { get; set; }
    public int MaterialID { get; set; }
    public string MaterialName { get; set; } // تأكد أن هذا الاسم يطابق DataPropertyName في الجدول
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalAmount => Quantity * UnitPrice;
    // لا تحذف هذا السطر، هو مفتاح الحل لظهور السطر الفارغ
    public PurchaseDetail() { }
}