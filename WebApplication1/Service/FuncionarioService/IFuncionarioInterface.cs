using WebApplication1.Models;

namespace WebApplication1.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();

        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel newFuncionario);

        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);

        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editFuncionario);

        Task<ServiceResponse<List<FuncionarioModel>>> DeletFuncionario(int id);

        Task<ServiceResponse<List<FuncionarioModel>>> UnactiveFuncionario(int id);
    }
}
