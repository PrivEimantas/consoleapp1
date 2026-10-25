using System.ComponentModel.DataAnnotations;


namespace FakeAPI.Core.V1.Models
{

    public class DataRequest
    {

        [Required] public ProductType ProductType { get; set; } 
        
        [Required] public Direction Direction { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal QuantityMwh { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal PricePerMwh { get; set; }
        
        
        [Required] public DateOnly DeliveryDate { get; set; }
        
        [Required] public string CounterParty { get; set; }
        
    }
    
    
    


}