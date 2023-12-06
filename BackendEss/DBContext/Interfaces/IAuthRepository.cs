using BackendEss.Dtos.Auth;
using BackendEss.Dtos.Project;
using BackendEss.Model;

namespace BackendEss.DBContext.Interfaces
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(AppUsers appUsers , string password , List<AddProjectDTO> projects) ;
        Task<ServiceResponse<AuthDTO>> Login(string username ,string password) ;
        Task<bool> UserExist(string username ) ;
    }
}
