using System.Net.Http;

namespace ProjectAgileBoard.API.Strategy
{
    public class EstimationStrategyFactory : IEstimationStrategyFactory
    {
        private readonly IHttpClientFactory _httpFactory;

        public EstimationStrategyFactory(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        public IEstimationStrategy GetStrategy(string type) =>
        type.ToLower() switch
        {
            "fibonacci" => new FibonacciAPIStrategy(_httpFactory),
            "random" => new RandomAPIStrategy(_httpFactory),
            _ => throw new ArgumentException($"Tipo inválido: {type}")
        };
    }
}
