namespace ConsolidatedService.Models
{
    public class DailyConsolidated
    {
        public DateTime Date { get; set; }
        public decimal TotalCredits { get; set; }
        public decimal TotalDebits { get; set; }
        public decimal Balance { get; set; }
    }

}
