using FilmesApi.Data.Dtos;

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
        bool Update(Guid uid, UpdateAddressDto dto);
        /// <inheritdoc cref="System.String.IndexOf(char)" />
        bool Delete(Guid uid);
    }
}
