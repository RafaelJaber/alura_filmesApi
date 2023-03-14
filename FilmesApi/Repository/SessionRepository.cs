using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Repository.IRepository;

namespace FilmesApi.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public SessionRepository(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IEnumerable<ReadSessionDto> FindAll(int skip, int take)
        {
            return _mapper.Map<List<ReadSessionDto>>(
                _context.Sessions
                    .ToList()
                    .Skip(skip)
                    .Take(take)
                );
        }

        public ReadSessionDto? FindById(Guid movieUid, Guid movieTUid)
        {
            Session session = _context.Sessions
                .FirstOrDefault( 
                    session => 
                        session.MovieId == movieUid && session.MovieTheaterId == movieTUid
                )!;
            if (session == null) return null;
            return _mapper.Map<ReadSessionDto>(session);
        }

        public ReadSessionDto Create(CreateSessionDto dto)
        {
            Session session = _mapper.Map<Session>(dto);
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return _mapper.Map<ReadSessionDto>(session);
        }
    }
}
