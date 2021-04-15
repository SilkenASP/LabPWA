using LabPWA.Model;
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
                
            };
            db.Depositar(oCuenta,100);
        }
    }
}
