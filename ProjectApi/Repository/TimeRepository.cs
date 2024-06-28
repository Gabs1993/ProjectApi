using AutoMapper;
using BasicApi.Data;
using BasicApi.Data.DTOs.TimeDTO;
using BasicApi.Interface;
using ProjectApi.Data;
using ProjectApi.Models;


namespace BasicApi.Repositorios
{
    public class TimeRepository : ITime
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TimeRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Time CriarTime(CreateTimeDTO createTimeDTO)
        {

            if (_context.Times.Any(t => t.NomeTime == createTimeDTO.NomeTime))
            {
                throw new Exception("Já existe um time com este nome.");
            }

            var newTime = _mapper.Map<Time>(createTimeDTO);

            _context.Add(newTime);
            _context.SaveChanges();

            return newTime;
        }

        public ReadTimeDTO? BuscarTimePorId(Guid id)
        {
            var time = _context.Times.FirstOrDefault(t => t.Id == id);
            if (time == null) return null;

            return _mapper.Map<ReadTimeDTO>(time);
        }

        public List<ReadTimeDTO> BuscarTodosOsTimes()
        {
            var times = _context.Times.ToList();
            return _mapper.Map<List<ReadTimeDTO>>(times);
        }

        public void ExluirTimes(Guid id)
        {
            var time = _context.Times.FirstOrDefault(t => t.Id == id);
            if (time != null)
            {
                _context.Times.Remove(time);
                _context.SaveChanges();
            }
            else
            {
                StatusCodes.Status404NotFound.ToString("Time não encontrado");
            }
        }
    }
}
