namespace UserMDS.Models.DTO
{
    public class AddCompanyEmployeeBenefitsDTO
    {
        public int Id { get; set; }
        public string plant_unique { get; set; }
        public double? work_home_perc { get; set; }
        public double? insurance_perc { get; set; }
        public double? pr_tax_perc { get; set; }
        public double? pto_perc { get; set; }
        public double? adj_factor_perc { get; set; }
        public double? tot_benefits_perc { get; set; }
        public string domain { get; set; }
        public string maintained_by { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string? modified_by { get; set; }
        public DateTime? modified_date { get; set; }
    }
}
