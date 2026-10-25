using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Http;
using FakeAPI.Core.V1.Models;
using FakeAPI.Core.V1.Services;

namespace FakeAPI.V1.Controllers.REST
{
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ApiVersion("1.0")]
    [ApiController]
    public class TradesController(ITradeRepository tradeRepository, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        [Route("/api/v1/trades/")]
        public async Task<ActionResult> GetTrade(
            [FromBody, Required] DataRequest request,
            CancellationToken cancellationToken = default )
        {
            try
            {
                // other validation - i.e dont be 0 for quantity, delivery date not in past 

                if (request.DeliveryDate < DateOnly.FromDateTime(DateTime.Today))
                {
                    return BadRequest(new ProblemDetails
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Title = "Invalid Request",
                        Detail = "Date is in the past"
                    });
                }
                // map to DTO
                var tradeDTO = mapper.MapRequestToDTO(request);
                // add trade
                var response = await tradeRepository.AddAsync(tradeDTO);
                
                // add some logging mechanism
                
                
                return Ok(response);
                
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
                
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return null;
        }
        
        
            
        
    }


}