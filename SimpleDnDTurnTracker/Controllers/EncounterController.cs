using Microsoft.AspNetCore.Mvc;
using SimpleDnDTurnTracker.Controllers.HttpRequests;
using SimpleDnDTurnTracker.Data.Entities;
using SimpleDnDTurnTracker.Features;
using SimpleDnDTurnTracker.Features.Encounters;

namespace SimpleDnDTurnTracker.Controllers
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