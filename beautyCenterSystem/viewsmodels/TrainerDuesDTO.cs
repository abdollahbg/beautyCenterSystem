namespace beautyCenterSystem.viewsmodels
{
    public class TrainerDuesDTO
    {
        public int TrainerID { get; set; }
        public string TrainerName { get; set; }
        public decimal TotalBaseAmount { get; set; }
        public decimal TotalCommissionAmount { get; set; }
        public decimal TotalDues { get; set; }
        public int UnpaidSubscriptionsCount { get; set; }
    }
}
