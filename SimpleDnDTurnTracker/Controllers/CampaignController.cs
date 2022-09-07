using Microsoft.AspNetCore.Mvc;
using SimpleDnDTurnTracker.Features;
using SimpleDnDTurnTracker.Features.Campaign;

namespace SimpleDnDTurnTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly IRequestHandler<CreateCampaignRequest, bool> _createCampaignRequestHandler;

        public CampaignController(IRequestHandler<CreateCampaignRequest, bool> createCampaignRequestHandler)
        {
            _createCampaignRequestHandler = createCampaignRequestHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var test = await _createCampaignRequestHandler.HandleRequest(new CreateCampaignRequest());
            return Ok(test);
        }
    }
}