using Newtonsoft.Json;

namespace BusinessLogic.Models.Git
{
    public class GitCommit
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "author")]
        public GitAuthor Author { get; set; }

        [JsonProperty(PropertyName = "commiter")]
        public GitCommiter Commiter { get; set; }
    }
}
