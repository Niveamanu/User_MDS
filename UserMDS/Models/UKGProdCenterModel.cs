using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserMDS.Models
{
    
    public class UKGProdCenterModel
    {
 
        public int Id { get; set; }
        public string Plant { get; set; }
        public string Cost_Center { get; set; }
        public int Shift { get; set; }
        public string? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public string? Modified_By { get; set; }
        public DateTime? Modified_Date { get; set; }
    }
}
