using AutoMapper;
using BasicApi.Data;
using BasicApi.Data.DTOs.UserDTO;
using BasicApi.Interface;
using ProjectApi.Data;
using ProjectApi.Data.DTOs.UserDTO;
using ProjectApi.Models;


namespace ProjectApi.Repositorios
{
    public class UserRepository : IUser
    {

        private readonly Context _context;
        private readonly IMapper _mapper;

        public UserRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public User CreateUser(CreateUserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);


            if (user.Password != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public ReadUserDTO? BuscarUserPorId(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) return null;

            return _mapper.Map<ReadUserDTO?>(user);

        }

        public List<ReadUserDTO> BuscarTodosUsuarios()
        {
            var user = _context.Users.ToList();
            return _mapper.Map<List<ReadUserDTO>>(user);
        }

        public void ExcluirUserPorID(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges(true);
            }
            else
            {
                StatusCodes.Status404NotFound.ToString("Time não encontrado");
            }
        }



    }
}
