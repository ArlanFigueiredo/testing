using Teste.Communication.Model.User;
using Teste.Communication.Requests.User;
using Teste.Communication.Responses.User;

namespace Teste.Communication.Repository.User {
    public interface IUserRepository {
        IEnumerable<ModelUser> FindAllUsers();
        Task<ModelUser> FindById(int id);
        Task<ModelUser> FindByEmail(string email);
        Task<ResponseMessageRegisterUser> Create(ModelUser user);
        void Update(int id, RequestRegisterUser user);
        void Delete(int id);
    }
}
