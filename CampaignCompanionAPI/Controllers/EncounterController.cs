using Microsoft.AspNetCore.Mvc;
using CampaignCompanionAPI.Controllers.HttpRequests;
using CampaignCompanionAPI.Data.Entities;
using CampaignCompanionAPI.Features;
using CampaignCompanionAPI.Features.Encounters;

namespace CampaignCompanionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncounterController : ControllerBase
    {
        private readonly IRequestHandler<CreateEncounterRequest, Encounter?> _createEncounterRequestHandler;
        private readonly IRequestHandler<IncreaseEncounterRoundRequest, Encounter?> _increaseEncounterRoundRequestHandler;
        public EncounterController(IRequestHandler<CreateEncounterRequest, Encounter?> createEncounterRequestHandler,
                                   IRequestHandler<IncreaseEncounterRoundRequest, Encounter?> increaseEncounterRoundRequestHandler)
        {
            _createEncounterRequestHandler = createEncounterRequestHandler;
            _increaseEncounterRoundRequestHandler = increaseEncounterRoundRequestHandler;
        }

        [HttpPut]
        public async Task<IActionResult> Create([FromBody] CreateEncounterHttpRequest request)
        {
            var encounter = await _createEncounterRequestHandler.HandleRequest(new CreateEncounterRequest{Name = request.Name, CampaignId = request.CampaignId});
            return Ok(encounter);
        }

        [HttpPost]
        public async Task<IActionResult> IncreaseRound([FromQuery] Guid id)
        {
            var encounter = await _increaseEncounterRoundRequestHandler.HandleRequest(new IncreaseEncounterRoundRequest{EncounterId = id});
            return Ok(encounter);
        }
    }
}