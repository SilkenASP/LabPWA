using LabPWA.Model;
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
        Task<Response> Depositar(Cuenta oCuenta , float monto);
        Task<Response> Retirar(float monto);
        Response Proyeccion(int tiempo);
        Response GetData();
        Response GetHistorial();
    }
}
