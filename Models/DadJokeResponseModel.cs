using Newtonsoft.Json;

namespace DadJokesDegreedCodeChallenge.Models
{
    public enum JokeSize
    {
        Short,
        Medium,
        Long
    }

    public class DadJokeResponseModel
    {
        public string Id { get; set; }
        public string Joke { get; set; }
        public int Status { get; set; }

        [JsonProperty("Size")]
        public string SizeDescription
        {
            get
            {
                return Size.ToString();
            }
        }

        [JsonIgnore]
        public JokeSize Size
        {
            get
            {
                if (Joke.Length < 50) return JokeSize.Short;
                if (Joke.Length < 100) return JokeSize.Medium;
                return JokeSize.Long;
            }
        }
    }
}
