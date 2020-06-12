using DadJokesDegreedCodeChallenge.Models;
using System.Threading.Tasks;

namespace DadJokesDegreedCodeChallenge.Providers
{
    public interface IICanHazDadJokesProvider
    {
        Task<DadJokeResponseModel> GetRandomJoke();
        Task<MultipleDadJokesResponseModel> SearchJoke(string term);
    }
}
