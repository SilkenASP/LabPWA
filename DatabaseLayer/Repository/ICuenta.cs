using DatabaseLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPWA.Repository
{
    public interface ICuenta
    {
        Response GetSaldo();
        Task<Response> Depositar(Cuenta oCuenta , float monto,int Estado);
        Task<Response> Retirar(float monto,ConfigurationClass oConfiguracion, Cuenta cuenta,int Estado);
        Response Proyeccion(int tiempo,Cuenta oCuenta);
        Response GetData();
        Response GetHistorial();
        Task<Response> Post(Cuenta oCuenta, Usuario oUsuario,Transaccion oTransaccion);
        Response ValidarMinimo(Cuenta oCuenta, double monto);
    }
}
