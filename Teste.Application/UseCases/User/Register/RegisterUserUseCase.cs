using Teste.Communication.Model.User;
using Teste.Communication.Repository.User;
using Teste.Communication.Requests.User;
using Teste.Communication.Responses.User;

namespace Teste.Application.UseCases.User.Register {
    public class RegisterUserUseCase {

        public async Task<ResponseMessageRegisterUser> Execute(ModelUser request) {


            var con = new UserRepository();

            var doesEmailExist =  await con.FindByEmail(request.Email);
               
            if(doesEmailExist != null && doesEmailExist.Email == request.Email) {
                throw new Exception("Usuario já existe!");
               
            }

            if (string.IsNullOrEmpty(request.Name)) {
                throw new Exception("O nome não pode estar vazio!");
            }
        

            if(string.IsNullOrEmpty(request.Email)) {
                throw new Exception("O email não pode ser vazio.");
            }

            if (string.IsNullOrEmpty(request.Password)){
                throw new Exception("A senha não pode ser vazia");
            }


            var user = await con.Create(request);

            return user;

        }
    }
}
