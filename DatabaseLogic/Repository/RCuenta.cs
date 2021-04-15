using LabPWA.Model;
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
        public async Task<Response> Depositar(Cuenta oCuenta,float monto)
        {
            try
            {
                var cuenta = db.Cuenta.Find(oCuenta);
                cuenta.Saldo += monto;
                Transaccion oTransaccion = new Transaccion
                {
                    Accion = "Deposito",
                    Fecha = DateTime.Now,
                    Monto=monto,
                    NuevoSaldo=cuenta.Saldo,
                    NumeroCuenta=cuenta.NumeroCuenta
                };
                db.Transaccion.Add(oTransaccion);
                var response = await db.SaveChangesAsync();
                return new Response
                {
                    IsSuccess = true,
                    Message = "El deposito fue exitoso"
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

        public Response GetData()
        {
            try
            {
                return new Response
                {
                    IsSuccess = true,
                    Result = Singleton.Instance.cuenta
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

        public Response GetHistorial()
        {
            try
            {
                return new Response
                {
                    IsSuccess = true,
                    Result = Singleton.Instance.cuenta.Transacciones
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

        public Response GetSaldo()
        {
            try
            {
                return new Response
                {
                    IsSuccess = true,
                    Result = Singleton.Instance.cuenta.Saldo
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

        public Response Proyeccion(int tiempo)
        {
            try
            {
                if (tiempo <= 0)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "El tiempo es invalido"
                    };
                }
                double InteresProyectado;
                Cuenta cuenta = Singleton.Instance.cuenta;
                InteresProyectado = cuenta.Saldo * cuenta.Interes * tiempo;
                return new Response
                {
                    IsSuccess = true,
                    Result = InteresProyectado,
                    Message = "La proyeccion para " + tiempo + " año/s es de $" + InteresProyectado
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

        public async Task<Response> Retirar(float monto)
        {
            try
            {
                if (Singleton.Instance.cuenta.FechaUltimaRetiro != DateTime.Now.ToShortDateString())
                {
                    Singleton.Instance.cuenta.RetiroDiario = 0;
                }
                if (monto > 400)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "El monto a retirar es mayor al permitido"
                    };
                }
                if ((Singleton.Instance.cuenta.RetiroDiario + monto) > 1000)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Se excede el limite permitido"
                    };
                }
                Singleton.Instance.cuenta.Saldo -= monto;
                Singleton.Instance.cuenta.RetiroDiario += monto;
                Singleton.Instance.cuenta.FechaUltimaRetiro = DateTime.Now.ToShortDateString();
                Singleton.Instance.cuenta.Transacciones.Add(new Transacciones { Accion = "Retiro", Fecha = DateTime.Now, Monto = monto, Nuevo_Saldo = Singleton.Instance.cuenta.Saldo });
                return new Response
                {
                    IsSuccess = true,
                    Message = "El deposito fue exitoso"
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