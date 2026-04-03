using System;

namespace beautyCenterSystem
{
    public class Material
    {
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }

        // التعديلات الجديدة لدعم الكافيتيريا والمخزن
        public decimal SalePrice { get; set; }     // سعر البيع للزبون
        public int StockQuantity { get; set; }     // الكمية المتوفرة في المخزن
        public bool IsCaffeteriaItem { get; set; } // هل هي مادة تباع في الكافيتيريا؟
    }
}