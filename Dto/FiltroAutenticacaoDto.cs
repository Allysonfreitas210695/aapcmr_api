using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_aapcmr.Dto
{
    public class FiltroAutenticacaoDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class AuthenticateDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Perfil { get; set; }
        public string Token { get; set; }
        public DateTime? Expires { get; set; }
    }
}