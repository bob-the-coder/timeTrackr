using BusinessLogic.Models;
using DataLayer.Implementation.Repositories;

namespace BusinessLogic.ModelCore
{
    public class AuthTokenCore : BaseSinglePkCore<AuthTokenRepository, AuthToken, DataLayer.AuthToken>
    {
    }
}
