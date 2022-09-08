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
        private readonly IRequestHandler<GetAllCampaignsRequest, List<Campaign>> _getAllCampaignsRequestHandler;
        private readonly IRequestHandler<UpdateCampaignRequest, Campaign> _updateCampaignRequestHandler;
        public CampaignController(IRequestHandler<CreateCampaignRequest, Campaign> createCampaignRequestHandler,
                                  IRequestHandler<GetAllCampaignsRequest, List<Campaign>> getAllCampaignsRequestHandler,
                                  IRequestHandler<UpdateCampaignRequest, Campaign> updateCampaignRequestHandler)
        {
            _createCampaignRequestHandler = createCampaignRequestHandler;
            _getAllCampaignsRequestHandler = getAllCampaignsRequestHandler;
            _updateCampaignRequestHandler = updateCampaignRequestHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var campaigns = await _getAllCampaignsRequestHandler.HandleRequest(new GetAllCampaignsRequest());
            return Ok(campaigns);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCampaignHttpRequest createCampaignHttpRequest)
        {
            var campaign = await _createCampaignRequestHandler.HandleRequest(new CreateCampaignRequest{Name = createCampaignHttpRequest.Name});
            return Ok(campaign);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Guid id, [FromBody]UpdateCampaignHttpRequest updateCampaignHttpRequest)
        {
            var campaign = await _updateCampaignRequestHandler.HandleRequest(new UpdateCampaignRequest{Id = id, Name = updateCampaignHttpRequest.Name});
            return Ok(campaign);
        }
    }
}