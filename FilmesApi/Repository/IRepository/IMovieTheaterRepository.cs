using FilmesApi.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmesApi.Repository.IRepository
{
    public interface IMovieTheaterRepository
    {
        IEnumerable<ReadMovieTheaterDto> FindAll(int skip, int take);
        IEnumerable<ReadMovieTheaterDto> FindByByAddress(Guid addressUid);
        ReadMovieTheaterDto FindById(Guid uid);
        ReadMovieTheaterDto Create(CreateMovieTheaterDto dto);
        bool Update(Guid uid, UpdateMovieTheaterDto dto);
        bool Delete(Guid uid);
    }
}
