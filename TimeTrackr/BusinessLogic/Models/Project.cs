using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class Project : ISinglePkModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string GitUsername { get; set; }
        public string GitRepo { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
        public virtual DataLayer.User User { get; set; }
    }
}
