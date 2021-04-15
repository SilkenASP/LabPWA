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

        public Task<Response> Depositar(Cuenta oCuenta, float monto)
        {
            try
            {
                var cuenta = db.Cuenta.Find(oCuenta);
                Transaccion oTransaccion = new Transaccion
                {
                    Accion = "Deposito",
                    Fecha = DateTime.Now,
                    Monto = monto,
                    NuevoSaldo = cuenta.Saldo + monto,
                    NumeroCuenta = cuenta.NumeroCuenta
                };
                db.Transaccion.Add(oTransaccion);
                db.
            }
            catch (Exception ex)
            {
                //return new Response
                //{
                //    IsSuccess = false,
                //    Message = ex.Message
                //};
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

        public Response Proyeccion(int tiempo)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Retirar(float monto)
        {
            throw new NotImplementedException();
        }
    }
}