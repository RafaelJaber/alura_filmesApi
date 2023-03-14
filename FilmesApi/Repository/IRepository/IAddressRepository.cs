using FilmesApi.Data.Dtos;
using FluentResults;

namespace FilmesApi.Repository.IRepository
{
    /// <summary>
    /// Interface IAddress
    /// </summary>
    public interface IAddressRepository
    {
        /// <inheritdoc cref="System.String.IndexOf(char)" />
        IEnumerable<ReadAddressDto> FindAll(int skip, int take);
        /// <inheritdoc cref="System.String.IndexOf(char)" />
        ReadAddressDto? FindById(Guid uid);
        /// <inheritdoc cref="System.String.IndexOf(char)" />
        ReadAddressDto Create(CreateAddressDto dto);

        /// <inheritdoc cref="System.String.IndexOf(char)" />
        Result Update(Guid uid, UpdateAddressDto dto);
        /// <inheritdoc cref="System.String.IndexOf(char)" />
        Result Delete(Guid uid);
    }
}
