using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadJokesDegreedCodeChallenge.Helpers
{
    public interface IRestApiHelper
    {
        Task<string> GetRequest(string baseUrl, string endpoint, IList<Parameter> parameters, IDictionary<string, string> headers);
    }
}
