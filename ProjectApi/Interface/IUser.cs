using BasicApi.Data.DTOs.UserDTO;
using ProjectApi.Data.DTOs.UserDTO;
using ProjectApi.Models;


namespace BasicApi.Interface
{
    public interface IUser
    {
        User CreateUser(CreateUserDTO userDTO);

        ReadUserDTO BuscarUserPorId(Guid id);

        List<ReadUserDTO> BuscarTodosUsuarios();

        void ExcluirUserPorID(Guid id);
    }
}
