using System;
using System.Collections.Generic;

namespace BusinessLogic.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
        public virtual DataLayer.User User { get; set; }
    }
}
