using Microsoft.AspNetCore.Mvc;
using SimpleDnDTurnTracker.Controllers.HttpRequests;
using SimpleDnDTurnTracker.Data.Entities;
using SimpleDnDTurnTracker.Features;
using SimpleDnDTurnTracker.Features.Campaigns;

namespace SimpleDnDTurnTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly IRequestHandler<CreateCampaignRequest, Campaign> _createCampaignRequestHandler;

        public CampaignController(IRequestHandler<CreateCampaignRequest, Campaign> createCampaignRequestHandler)
        {
            _createCampaignRequestHandler = createCampaignRequestHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCampaignHttpRequest createCampaignHttpRequest)
        {
            var campaign = await _createCampaignRequestHandler.HandleRequest(new CreateCampaignRequest{Name = createCampaignHttpRequest.Name});
            return Ok(campaign);
        }
    }
}