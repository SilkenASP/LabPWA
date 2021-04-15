using DatabaseLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository
{
    public class RUsuario : IUsuario
    {
        private readonly Model1 db = new Model1();
        public Response Login(string user, string passcode)
        {
            try
            {
                var usuario = db.Usuario.FirstOrDefault(x => x.Username.Equals(user) && x.clave.Equals(passcode));
                if (usuario == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Credenciales invalidas",
                        Result=usuario
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = usuario
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> RegisterUser(Usuario item)
        {
            try
            {
                db.Usuario.Add(item);
                var resp = await db.SaveChangesAsync();
                if (resp==0)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se pudo registrar el usuario"
                    };
                }
                return new Response
                {
                    IsSuccess = false,
                    Message = "Usuario registrado exitosamente en la base"
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
