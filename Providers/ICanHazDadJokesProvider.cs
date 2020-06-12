using DadJokesDegreedCodeChallenge.Helpers;
using DadJokesDegreedCodeChallenge.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadJokesDegreedCodeChallenge.Providers
{
    public class ICanHazDadJokesProvider : IICanHazDadJokesProvider
    {
        #region Private fields
        private readonly IRestApiHelper _restApiHelper;
        private readonly AppSettings _appSettings;
        #endregion

        #region Constructors
        public ICanHazDadJokesProvider(IOptions<AppSettings> appSettings) : this(appSettings, new RestApiHelper())
        {

        }

        public ICanHazDadJokesProvider(IOptions<AppSettings> appSettings, IRestApiHelper restApiHelper)
        {
            _appSettings = appSettings.Value;
            _restApiHelper = restApiHelper;
        }

        public async Task<DadJokeResponseModel> GetRandomJoke()
        {
            var response = await _restApiHelper.GetRequest(_appSettings.IchdjBaseUrl, _appSettings.IchdjRandomJokeEndpoint, null,
                new Dictionary<string, string> { { "Accept", "application/json" } });

            return JsonConvert.DeserializeObject<DadJokeResponseModel>(response);
        }

        public async Task<MultipleDadJokesResponseModel> SearchJoke(string term)
        {
            var response = await _restApiHelper.GetRequest(_appSettings.IchdjBaseUrl, _appSettings.IchdjSearchJokeEndpoint, 
                new List<Parameter> { 
                    new Parameter("limit", 30, ParameterType.QueryString),
                    new Parameter("term", term, ParameterType.QueryString)
                },
                new Dictionary<string, string> { { "Accept", "application/json" } });

            var result = JsonConvert.DeserializeObject<MultipleDadJokesResponseModel>(response);
            result.Results.Sort((x, y) => x.Size.CompareTo(y.Size));
            return result;
        }
        #endregion
    }
}
