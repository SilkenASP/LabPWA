
using DatabaseLayer.Model;
using LabPWA.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ICuenta db = new RCuenta();
            Cuenta oCuenta = new Cuenta
            {
                Activo=1,
                Interes=1f,
                NumeroCuenta="12345678",
                Saldo=1000,
                
            };
            var response = db.Depositar(oCuenta,100);
            Assert.IsTrue(response.Result.IsSuccess);
        }
    }
}
