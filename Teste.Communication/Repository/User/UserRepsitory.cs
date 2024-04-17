using Teste.Communication.Model.User;
using Teste.Communication.Requests.User;
using Teste.Communication.Responses.User;

namespace Teste.Communication.Repository.User {
    public class UserRepository : IUserRepository {
        private List<ModelUser> users = new List<ModelUser>();

        public UserRepository() {
            // Exemplo: inicializando o repositório com alguns usuários
            users.Add(new ModelUser { Id = 6, Name = "Arlan", Email = "arlan.carloz@gmail.com", Password = "123456" });
            users.Add(new ModelUser { Id = 4, Name = "Bob", Email = "bob@example.com", Password = "" });
        }

        public IEnumerable<ModelUser> FindAllUsers() {
            return users;
        }

        public async Task<ModelUser> FindById(int id) {
            return await Task.FromResult(users.Find(u => u.Id == id));
        }

        public async Task<ModelUser> FindByEmail(string email) {
            return await Task.FromResult(users.Find(u => u.Email == email));
        }

        public async Task<ResponseMessageRegisterUser> Create(ModelUser user) {
            // Simplesmente adiciona o usuário à lista
            users.Add(user);
            return await Task.FromResult(new ResponseMessageRegisterUser {
                Message = "Usuario criado com sucesso!"
            });
        }

        public void Update(int id, RequestRegisterUser user) {
            // Procura pelo usuário na lista e atualiza seus dados
            var existingUser = users.Find(u => u.Id == id);
            if (existingUser != null) {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
        }

        public void Delete(int id) {
            // Remove o usuário da lista com base no ID
            users.RemoveAll(u => u.Id == id);
        }
    }
}
