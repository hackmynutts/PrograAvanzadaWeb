namespace ProjectAgileBoard.API.Strategy
{
    public interface IEstimationStrategy
    {
        Task<int> GetEstimationAsync();
    }
}
