using DatabaseLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository
{
    public interface IUsuario
    {
        Response Login(string user, string passcode);
        Task<Response> RegisterUser(Usuario item);
    }
}
