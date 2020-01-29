using System.Threading.Tasks;

namespace TvMaze.Core.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}