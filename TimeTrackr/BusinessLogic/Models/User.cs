using System.Collections.Generic;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class User : ISinglePkModel
    {
        public System.Guid Id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
