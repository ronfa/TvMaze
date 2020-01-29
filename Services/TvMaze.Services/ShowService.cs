using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Core.Persistence.Repositories;
using TvMaze.Domain.Models;

namespace TvMaze.Services
{
    public class ShowService : IShowService
    {
        private readonly IShowRespository _showRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShowService(IShowRespository showRepository, IUnitOfWork unitOfWork)
        {
            _showRepository = showRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Show>> ListAsync(PagingParameters pagingParameters)
        {
            return await _showRepository.ListAsync(pagingParameters);
        }
    }
}