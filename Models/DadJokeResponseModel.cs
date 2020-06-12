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
                var wordCount = Joke.Split(' ').Length;
                if (wordCount < 10) return JokeSize.Short;
                if (wordCount < 20) return JokeSize.Medium;
                return JokeSize.Long;
            }
        }
    }
}
