using System;
using BusinessLogic.Interfaces;
using Newtonsoft.Json;

namespace BusinessLogic.Models.Git
{
    public class GitCommitWrapper : ISinglePkModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "commit")]
        public GitCommit Commit { get; set; }
    }
}
