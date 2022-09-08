using SimpleDnDTurnTracker.Data.Entities;
using SimpleDnDTurnTracker.Data.Repositories;

namespace SimpleDnDTurnTracker.Features.Encounters
{
    public class IncreaseEncounterRoundRequest
    {
        public Guid EncounterId { get; set; }
    }
    public class IncreaseEncounterRoundRequestHandler: IRequestHandler<IncreaseEncounterRoundRequest, Encounter?>
    {
        private readonly IRepository<Encounter> _encounterRepository;
        public IncreaseEncounterRoundRequestHandler(IRepository<Encounter> encounterRepository)
        {
            _encounterRepository = encounterRepository;
        }

        public async Task<Encounter?> HandleRequest(IncreaseEncounterRoundRequest request)
        {
            var encounter = await _encounterRepository.Get(request.EncounterId);
            if (encounter == null)
                return null;

            encounter.Round++;
            await _encounterRepository.Update(encounter);

            return encounter;
        }
    }
}
