using System;
using ClassLibrary3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RetAutorization()
        {
            Functions aut1 = new Functions();
            bool qwe = aut1.AutorizationFunc("vad7043@mail.ru", "cfb3a21c21c9845f493bf6c6e388a8b0d010f95c", "https://vad7043.amocrm.ru/private/api/auth.php?type=json");
            Assert.AreEqual(true, qwe);
        }
        [TestMethod]
        public void AddTask()
        {
            Functions addtask = new Functions();
            string qwe = addtask.AddTask("vad7043@mail.ru", "cfb3a21c21c9845f493bf6c6e388a8b0d010f95c", "https://vad7043.amocrm.ru/private/api/v2/json/tasks");
            Assert.IsNotNull(qwe);
        }
    }
}
