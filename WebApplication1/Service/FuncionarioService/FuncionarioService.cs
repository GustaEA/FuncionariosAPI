using Microsoft.EntityFrameworkCore;
using WebApplication1.DataContext;
using WebApplication1.Models;

namespace WebApplication1.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly AppDbContext _context;
        public FuncionarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel newFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                if (newFuncionario == null) { 
                    serviceResponse.data = null;
                    serviceResponse.message = "Informar dados.";
                    serviceResponse.sucsses = false;

                    return serviceResponse;
                }

                _context.Add(newFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.data = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
                serviceResponse.sucsses = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeletFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.id == id);

                if (funcionario == null) 
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Usuário não encontrado";
                    serviceResponse.sucsses = false;
                }
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.data = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
                serviceResponse.sucsses = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionarioModel = _context.Funcionarios.FirstOrDefault(x => x.id == id);
                
                if(serviceResponse.data == null)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Usuário não localizado";
                    serviceResponse.sucsses = false;
                }

                serviceResponse.data = funcionarioModel;
            }
            catch (Exception ex)
            {

                serviceResponse.message = ex.Message;
                serviceResponse.sucsses = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.data = _context.Funcionarios.ToList();
                if (serviceResponse.data.Count.Equals(0))
                {
                    serviceResponse.message = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {

                serviceResponse.message = ex.Message;
                serviceResponse.sucsses = false;    
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UnactiveFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.id == id);

                if (funcionario == null)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Usuário não localizado";
                    serviceResponse.sucsses = false;
                }

                funcionario.active = false;
                funcionario.changeDate = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.data = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.message = ex.Message;
                serviceResponse.sucsses = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.id == editFuncionario.id);
                if (funcionario == null)
                {
                    serviceResponse.data = null;
                    serviceResponse.message = "Usuário não localizado";
                    serviceResponse.sucsses = false;
                }

                funcionario.changeDate = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(editFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.data = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.message = ex.Message;
                serviceResponse.sucsses = false;
            }

            return serviceResponse;
        }
    }
}
