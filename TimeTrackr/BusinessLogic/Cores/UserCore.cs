using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.ModelCore;
using BusinessLogic.Models;
using BusinessLogic.Util;
using DataLayer.Implementation.Repositories;

namespace BusinessLogic.Cores
{
    public class UserCore : BaseSinglePkCore<UserRepository, User, DataLayer.User>
    {
        public static async Task<User> GetByEmailAndPasswordAsync(string email, string password)
        {
            var passwordHash = PasswordHasher.GetPasswordHash(password);
            var possibleUser = await GetListAsync(
                    user => user.Email.ToLower().Equals(email.ToLower())
                    && user.Password == passwordHash)
                .ConfigureAwait(false);

            if (possibleUser.Any() && possibleUser.Count == 1)
            {
                return possibleUser[0];
            }

            return null;
        }
    }
}
