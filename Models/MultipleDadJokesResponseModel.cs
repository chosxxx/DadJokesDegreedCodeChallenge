using Newtonsoft.Json;
using System.Collections.Generic;

namespace DadJokesDegreedCodeChallenge.Models
{
    public class MultipleDadJokesResponseModel
    {
        public List<DadJokeResponseModel> Results { get; set; }
        public int Status { get; set; }
        [JsonProperty("total_jokes")]
        public int TotalJokes { get; set; }
    }
}
