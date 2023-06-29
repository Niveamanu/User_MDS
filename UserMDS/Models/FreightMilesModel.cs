namespace UserMDS.Models
{
    public class FreightMilesModel
    {
        public int Id { get; set; }  
        public string Index { get; set; }
        public int prev_stop_zip {get;set;}
        public int next_stop_zip { get; set; }
        public double miles { get; set; }
        public string mileage_src { get; set; }
        public string first { get; set; }
        public string second { get; set; }    
        public DateTime revised { get; set; }
        public string domain { get; set; }
        public string maintained_by { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string? modified_by { get; set; }
        public DateTime? modified_date { get; set; }
    }
}
