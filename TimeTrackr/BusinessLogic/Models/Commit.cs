using System;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class Commit : ISinglePkModel
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public virtual Project Project { get; set; }
    }
}
