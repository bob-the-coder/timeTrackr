using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class AuthToken : ISinglePkModel
    {
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
