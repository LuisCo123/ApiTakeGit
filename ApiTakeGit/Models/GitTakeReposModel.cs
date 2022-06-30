using Newtonsoft.Json;
namespace ApiTakeGit.Models
{
    public class GitTakeReposModel
    {
        [JsonProperty("full_name")]
        public String full_name { get; set; }

        [JsonProperty("description")]
        public String description { get; set; }
        
        [JsonProperty("owner")]
        public Owner owner { get; set; }

        [JsonProperty("language")]
        public String language { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }
    }
   
}
