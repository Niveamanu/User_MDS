﻿namespace UserMDS.Models.DTO
{
    public class AddRevisedCustToDetailsDTO
    {
        public int Id { get; set; }
        public int business_unit { get; set; }
        public int cust_no { get; set; }
        public int cust_no_revised { get; set; }
        public string domain { get; set; }
        public string maintained_by { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string? modified_by { get; set; }
        public DateTime? modified_date { get; set; }
    }
}
