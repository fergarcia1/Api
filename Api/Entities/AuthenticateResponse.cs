using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
        public AuthenticateResponse(User user, string token)
        {
            this.Id = user.Id;
            this.Username = user.Username;
            this.Role = user.Role;
            this.Token = token;
        }
    }
}