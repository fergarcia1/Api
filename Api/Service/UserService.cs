using Api.Authorization;
using Api.Context;
using Api.Entities;
using Api.Helpers;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Api.Service
{
    public class UserService : IUserService
    {
        private ApplicationDBContext _context;
        private IJwtUtils jwtUtils;
        private readonly AppSettings appsettings;

        public UserService(ApplicationDBContext context, IJwtUtils jwtUtils, IOptions<AppSettings> appSettings)
        {
            this._context = context;
            this.jwtUtils = jwtUtils;
            this.appsettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            User? user = this._context.Users.FirstOrDefault(x => x.Username == model.Username); //busca en db el username
            //!BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash)
            if (user == null || !model.Password.Equals(user.PasswordHash))
                throw new AppException("username o password incorrecto");

            string jwtToken = this.jwtUtils.GenerateJwtToken(user); //genera el token

            return new AuthenticateResponse(user, jwtToken);
        }

        public IEnumerable<User> GetAll()
        {
            return this._context.Users;
        }

        public User GetById(int id)
        {
            User? user = this._context.Users.Find(id);
            if (user == null)
                throw new KeyNotFoundException("user not found");
            return user;
        }
    }
}