namespace UserMDS.Models
{
    public class ManualKPIMetricsValueModel
    {
        public int Id { get; set; } 
        public DateTime effective_date_from { get; set; }
        public int business_unit { get; set; }
        public string lhl_loc { get; set; }    
        public int weekly_overhead_pnw_eq_fsc_noc { get; set; }
        public double weekly_overhead_projection { get; set; }

        public double weekly_overhead_other { get; set; }

        public string domain { get; set; }
        public string maintained_by { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string? modified_by { get; set; }
        public DateTime? modified_date { get; set; }
    }
}
