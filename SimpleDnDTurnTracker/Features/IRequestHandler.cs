namespace SimpleDnDTurnTracker.Features
{
    public interface IRequestHandler<in TRequest, TReturn>
    {
        public Task<TReturn> HandleRequest(TRequest request);
    }
}
