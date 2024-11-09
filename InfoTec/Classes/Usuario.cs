using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTec.Classes
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {

        }

        public Usuario(string login,string senha)
        {
            this.Login = login;
            this.Senha = senha;

        }

        public Usuario(int id, string login, string senha)
        {
            Id = id;
            Login = login;
            Senha = senha;
        }


    }
}
