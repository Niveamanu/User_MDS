﻿using System.ComponentModel.DataAnnotations;

namespace UserMDS.Models.DTO
{
    public class AddUKGProdCenterDTO
    {

        public int Id { get; set; }
        public string Plant { get; set; }
        public string Cost_Center { get; set; }
        public int Shift { get; set; }
        public string Updated_By { get; set; }
        public DateTime Updated_Date { get; set; }
    }
}