using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Repository.IRepository;

namespace FilmesApi.Repository
{
    /// <summary>
    /// Classe que herda de IAddressRepository para servir a aplicação
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;
        
        /// <summary>
        /// Construtor Padrão
        /// </summary>
        public AddressRepository(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        /// <inheritdoc />
        public IEnumerable<ReadAddressDto> FindAll(int skip, int take)
        {
            return _mapper.Map<List<ReadAddressDto>>(
                _context.Addresses
                    .ToList()
                    .Skip(skip)
                    .Take(take)
            );
        }

        /// <inheritdoc />
        public ReadAddressDto? FindById(Guid uid)
        {
            Address address = _context.Addresses
                .FirstOrDefault(ad => ad.Uid == uid)!;
            if (address == null) return null;
            return _mapper.Map<ReadAddressDto>(address);
        }

        /// <inheritdoc />
        public ReadAddressDto Create(CreateAddressDto dto)
        {
            Address address = _mapper.Map<Address>(dto);
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return _mapper.Map<ReadAddressDto>(address);
        }

        /// <inheritdoc />
        public bool Update(Guid uid, UpdateAddressDto dto)
        {
            Address address = _context.Addresses
                .FirstOrDefault(ad => ad.Uid == uid)!;
            if (address == null) return false;
            _mapper.Map(dto, address);
            _context.SaveChanges();
            return true;
        }

        /// <inheritdoc />
        public bool Delete(Guid uid)
        {
            Address address = _context.Addresses
                .FirstOrDefault(ad => ad.Uid == uid)!;
            if (address == null) return false;
            _context.Remove(address);
            _context.SaveChanges();
            return true;
        }
    }
}
