using GameCatalogue.DTO;
using GameCatalogue.Models;
using GameCatalogue.Repositories;

namespace GameCatalogue.Service
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeveloperService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Developer> GetDeveloperByIdAsync(int id)
        {
            return _unitOfWork.Developers.GetByIdAsync(id);
        }

        public Task<IEnumerable<Developer>> GetAllDevelopersAsync()
        {
            return _unitOfWork.Developers.GetAllAsync();
        }

        public async Task CreateDeveloperAsync(Developer developer)
        {
            await _unitOfWork.Developers.AddAsync(developer);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateDeveloperAsync(Developer developer)
        {
            await _unitOfWork.Developers.UpdateAsync(developer);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteDeveloperAsync(int id)
        {
            await _unitOfWork.Developers.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }


        public async Task<DeveloperDto> GetDeveloperWithGamesAsync(int developerId)
        {
            var developer = await _unitOfWork.Developers.GetDeveloperWithGamesAsync(developerId);

            if (developer == null)
            {
                return null; 
            }

            var developerDto = new DeveloperDto
            {
                DeveloperId = developer.DeveloperId,
                Name = developer.Name,
                Country = developer.Country,
                Email = developer.Email,
                Games = developer.GameDevelopers.Select(gd => new GameDto
                {
                    GameId = gd.Game.GameId,
                    Title = gd.Game.Title,
                    Genre = gd.Game.Genre,
                    Price = gd.Game.Price,
                    ReleaseDate = gd.Game.ReleaseDate
                }).ToList()
            };

            return developerDto;
        }
    }
}
