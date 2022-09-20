using Microsoft.AspNetCore.Mvc;
using CampaignCompanionAPI.Controllers.HttpRequests;
using CampaignCompanionAPI.Data.Entities;
using CampaignCompanionAPI.Features;
using CampaignCompanionAPI.Features.Campaigns;

namespace CampaignCompanionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly IRequestHandler<CreateCampaignRequest, Campaign> _createCampaignRequestHandler;
        private readonly IRequestHandler<GetAllCampaignsRequest, List<Campaign>> _getAllCampaignsRequestHandler;
        private readonly IRequestHandler<UpdateCampaignRequest, Campaign> _updateCampaignRequestHandler;
        private readonly IRequestHandler<GetCampaignsWithUserIdRequest, List<Campaign>> _getCampaignWithUserIdRequestHandler;
        private readonly IRequestHandler<GetCampaignRequest, Campaign?> _getCampaignRequestHandler;
        public CampaignController(IRequestHandler<CreateCampaignRequest, Campaign> createCampaignRequestHandler,
                                  IRequestHandler<GetAllCampaignsRequest, List<Campaign>> getAllCampaignsRequestHandler,
                                  IRequestHandler<UpdateCampaignRequest, Campaign> updateCampaignRequestHandler,
                                  IRequestHandler<GetCampaignsWithUserIdRequest, List<Campaign>> getCampaignWithUserIdRequestHandler,
                                  IRequestHandler<GetCampaignRequest, Campaign?> getCampaignRequestHandler)
        {
            _createCampaignRequestHandler = createCampaignRequestHandler;
            _getAllCampaignsRequestHandler = getAllCampaignsRequestHandler;
            _updateCampaignRequestHandler = updateCampaignRequestHandler;
            _getCampaignWithUserIdRequestHandler = getCampaignWithUserIdRequestHandler;
            _getCampaignRequestHandler = getCampaignRequestHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var campaigns = await _getAllCampaignsRequestHandler.HandleRequest(new GetAllCampaignsRequest());
            return Ok(campaigns);
        }

        [HttpGet("{campaignId}")]
        public async Task<IActionResult> Get([FromRoute] Guid campaignId)
        {
            var campaign = await _getCampaignRequestHandler.HandleRequest(new GetCampaignRequest{CampaignId = campaignId});
            return Ok(campaign);
        }

        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetUserCampaigns([FromRoute] string userId)
        {
            var campaigns = await _getCampaignWithUserIdRequestHandler.HandleRequest(new GetCampaignsWithUserIdRequest{UserId = userId});
            return Ok(campaigns);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCampaignHttpRequest createCampaignHttpRequest)
        {
            var campaign = await _createCampaignRequestHandler.HandleRequest(new CreateCampaignRequest{Name = createCampaignHttpRequest.Name, UserId = createCampaignHttpRequest.UserId});
            return Ok(campaign);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]UpdateCampaignHttpRequest updateCampaignHttpRequest)
        {
            var campaign = await _updateCampaignRequestHandler.HandleRequest(new UpdateCampaignRequest{Id = id, Name = updateCampaignHttpRequest.Name, Description = updateCampaignHttpRequest.Description});
            return Ok(campaign);
        }
    }
}