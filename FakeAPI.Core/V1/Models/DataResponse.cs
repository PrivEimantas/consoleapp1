using System.ComponentModel.DataAnnotations;

namespace FakeAPI.Core.V1.Models

{

    public class DataResponse
    {
        [Required] public string Id  { get; set; }
        [Required] public string Product { get; set; }
        [Required] public string Direction { get; set; }
        [Required] public string QuantityMwh { get; set; }
        [Required] public string PricePerMwh { get; set; }
        [Required] public DateOnly DeliveryDate { get; set; }
        [Required] public string CounterParty { get; set; }
        [Required] public DateOnly CreatedAt { get; set; }
    }


}