using beautyCenterSystem.data.Repositories;
using System;
using System.Collections.Generic;

public class PurchaseInvoice
{
    public int InvoiceID { get; set; }
    public string SupplierName { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int PaidFromSafeID { get; set; }
    public int IssuedBy { get; set; }
    public string Notes { get; set; }

    // --- خصائص إضافية للعرض فقط (Navigation Properties) ---
    // هذه الخصائص يتم تعبئتها من استعلام الـ JOIN في الـ Repository
    public string SafeName { get; set; } // لعرض اسم الخزنة بدلاً من رقمها
    public string IssuedByName { get; set; } // لعرض اسم المستخدم الذي أنشأ الفاتورة

    // ربط الفاتورة بتفاصيلها
    public List<PurchaseDetail> Details { get; set; } = new List<PurchaseDetail>();
}