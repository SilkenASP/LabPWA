using DatabaseLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LabPWA.Repository
{
    public class RCuenta : ICuenta
    {
        private readonly Model1 db = new Model1();

        public async Task<Response> Depositar(Cuenta oCuenta, float monto,int Estado)
        { 
            try
            {
                Transaccion oTransaccion = new Transaccion
                {
                    Accion = "Deposito",
                    Fecha = DateTime.Now,
                    Monto = monto,
                    NuevoSaldo = oCuenta.Saldo + monto,
                    NumeroCuenta = oCuenta.NumeroCuenta
                };
                Usuario user = db.Usuario.FirstOrDefault(x => x.id_Usuario.Equals(oCuenta.Usuario.id_Usuario));
                var index = user.Cuenta.ToList().FindIndex(x => x.id_Cuenta.Equals(oCuenta.id_Cuenta));
                user.Cuenta.ToList()[index].Saldo += monto;
                user.Cuenta.ToList()[index].Activo = Estado;
                user.Transaccion.Add(oTransaccion);
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                var resp = await db.SaveChangesAsync();
                if (resp>0)
                {
                    return new Response
                    {
                        IsSuccess = true,
                        Message = "El deposito ha sido satisfactorio",
                        Result = user
                    };
                }
                else
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se pudo almacenar en la db"
                    };
                }
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

        public Response GetData()
        {
            throw new NotImplementedException();
        }

        public Response GetHistorial()
        {
            throw new NotImplementedException();
        }

        public Response GetSaldo()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Post(Cuenta oCuenta, Usuario oUsuario, Transaccion oTransaccion)
        {
            try
            {
                var user = db.Usuario.FirstOrDefault(x => x.id_Usuario.Equals(oUsuario.id_Usuario));
                user.Cuenta.Add(oCuenta);
                user.Transaccion.Add(oTransaccion);
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                var resp = await db.SaveChangesAsync();
                if (resp>0)
                {
                    return new Response
                    {
                        IsSuccess = true,
                        Message = "La cuenta ha sido agregada",
                        Result = user
                    };
                }
                else
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se ha podido agregar la cuenta",
                        Result = user
                    };
                }

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

        public Response Proyeccion(int tiempo)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Retirar(float monto,ConfigurationClass oConfiguracion,Cuenta cuenta,int Estado)
        {
            try
            {
                if (oConfiguracion.UltimoRetiro.ToShortDateString() != DateTime.Now.ToShortDateString())
                {
                    oConfiguracion.RetiroDiario = 0;
                }
                if (monto > 400)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "El monto a retirar es mayor al permitido"
                    };
                }
                if ((oConfiguracion.RetiroDiario + monto) > 1000)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Se excede el limite permitido"
                    };
                }
                if (cuenta.Saldo-monto<0)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No puede retirar una cantidad mayor a su saldo actual"
                    };
                }
                Usuario user = db.Usuario.FirstOrDefault(x => x.id_Usuario.Equals(cuenta.Usuario.id_Usuario));
                var index = user.Cuenta.ToList().FindIndex(x => x.id_Cuenta.Equals(cuenta.id_Cuenta));
                user.Cuenta.ToList()[index].Saldo -= monto;
                user.Cuenta.ToList()[index].Activo = Estado;
                user.Transaccion.Add(new Transaccion
                {
                    Accion = "Retirar",
                    Fecha = DateTime.Now,
                    Monto = monto,
                    NuevoSaldo = user.Cuenta.ToList()[index].Saldo,
                    NumeroCuenta = cuenta.NumeroCuenta
                });
                if (Estado==0)
                {
                    user.Transaccion.Add(new Transaccion
                    {
                        Accion="Desactivo",
                        Fecha=DateTime.Now,
                        Monto=0,
                        NuevoSaldo=0,
                        NumeroCuenta=cuenta.NumeroCuenta,
                    });
                }
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                var resp = await db.SaveChangesAsync();
                if (resp>0)
                {
                    return new Response
                    {
                        IsSuccess = true,
                        Message = "El retiro fue exitoso",
                        Result=user
                    };
                }
                else
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Error al actualizar el registro"
                    };
                }
                
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

        public Response ValidarMinimo(Cuenta oCuenta, double monto)
        {
            if (oCuenta.Saldo-monto<1)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Si retira el monto su cuenta quedara desactivada, ¿Seguro que desea proseguir?"
                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = "Puede retirar sin problemas"
                };
            }
        }
    }
}