using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Repository.IRepository
{
    public interface ISessionRepository
    {
        public IEnumerable<ReadSessionDto> FindAll(int skip, int take);
        public ReadSessionDto? FindById(Guid uid);
        public ReadSessionDto Create(CreateSessionDto dto);
    }
}
