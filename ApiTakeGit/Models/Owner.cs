using Newtonsoft.Json;

namespace ApiTakeGit.Models
{
    public class Owner
    {
        [JsonProperty("avatar_url")]
        public string avatar_url { get; set; }

    }
}
