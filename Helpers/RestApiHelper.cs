using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadJokesDegreedCodeChallenge.Helpers
{
    public class RestApiHelper : IRestApiHelper
    {
        public async Task<string> GetRequest(string baseUrl, string endpoint, IList<Parameter> parameters, IDictionary<string, string> headers)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(endpoint, Method.GET);

            if (parameters != null)
                foreach (var p in parameters) request.AddParameter(p);
                    request.AddHeaders(headers);

            var response = await client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
