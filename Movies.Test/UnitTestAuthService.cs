using System;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Services;

namespace Movies.Test
{
    [TestClass]
    public class UnitTestAuthService
    {
        //PeliculasContext Context;
        IAuthService AuthService;
        public UnitTestAuthService()
        {
            var settings = Options.Create(new AuthSettings()
            {
                SigningKey = "TheKey"
            });
            AuthService = new AuthService(settings);
        }
        [TestMethod]
        public void TestMethodValidateUser() {
            Console.WriteLine("Validar usuarios");
            Assert.IsTrue(AuthService.ValidateUser("admin", "admin"));
        }
    }
}