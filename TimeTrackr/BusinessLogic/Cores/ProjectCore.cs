using BusinessLogic.ModelCore;
using BusinessLogic.Models;
using DataLayer.Implementation.Repositories;

namespace BusinessLogic.Cores
{
    public class ProjectCore : BaseSinglePkCore<ProjectRepository, Project, DataLayer.Project>
    {
    }
}
