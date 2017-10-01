using Newtonsoft.Json;

namespace BusinessLogic.Models.Git
{
    public class GitCommitWrapper
    {
        [JsonProperty(PropertyName = "commit")]
        public GitCommit Commit { get; set; }
    }
}
