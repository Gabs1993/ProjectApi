using BasicApi.Data.DTOs.TimeDTO;
using ProjectApi.Models;


namespace BasicApi.Interface
{
    public interface ITime
    {
        Time CriarTime(CreateTimeDTO createTimeDTO);

        ReadTimeDTO BuscarTimePorId(Guid id);

        List<ReadTimeDTO> BuscarTodosOsTimes();

        void ExluirTimes(Guid id);
    }
}
