namespace SalesRfp.Models.Domain
{
    public class AddSalesRepInput
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string SourcePlant { get; set; }
        public string SourceGeography { get; set; }
        public string Scenario { get; set; }
        public double ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public string MarketClass { get; set; }
        public double Units { get; set; }
        public double WeeklyCaseVolume { get; set; }
        public double SixthWeekVolume { get; set; }
    }
}
