namespace ProjectAgileBoard.API.Strategy
{
    public interface IEstimationStrategyFactory
    {
        IEstimationStrategy GetStrategy(string type);
    }
}
