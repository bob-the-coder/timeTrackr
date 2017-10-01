using System;
using BusinessLogic.Interfaces;
using Newtonsoft.Json;

namespace BusinessLogic.Models
{
    public class Commit : ISinglePkModel
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid ProjectId { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public string Description { get; set; }
        [JsonIgnore]
        public DateTime From { get; set; }
        [JsonIgnore]
        public DateTime To { get; set; }

        [JsonIgnore]
        public virtual Project Project { get; set; }
    }
}
