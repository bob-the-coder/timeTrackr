using BusinessLogic.ModelCore;
using BusinessLogic.Models;
using DataLayer.Implementation.Repositories;

namespace BusinessLogic.Cores
{
    public class CommitCore : BaseSinglePkCore<CommitRepository, Commit, DataLayer.Commit>
    {
    }
}
