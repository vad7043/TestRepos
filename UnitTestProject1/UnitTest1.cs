using System;
using ClassLibrary3;
using ClassLibrary3.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAutorization()
        {
            Functions aut1 = new Functions();
            var result = aut1.Authorization("vad7043@mail.ru", "cfb3a21c21c9845f493bf6c6e388a8b0d010f95c", "https://vad7043.amocrm.ru/private/api/auth.php?type=json");
            Assert.AreEqual(true, result.Response.auth);
        }
        [TestMethod]
        public void TestAddTask()
        {
            Functions addtask = new Functions();
            var newAmoTask = new AmoApiAddTask
            {
                element_id = 185241,
                element_type = 2,
                complete_till_at = (long)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds,
                task_type = 1,
                text = "Тестовое задние",
                created_at = (long)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds,
                updated_at = (long)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds,
                responsible_user_id = 3455599,
                created_by = 3455599,
            };
            var authResCookie = addtask.Authorization("vad7043@mail.ru", "cfb3a21c21c9845f493bf6c6e388a8b0d010f95c", "https://vad7043.amocrm.ru/private/api/auth.php?type=json");
            var result = addtask.AddTask(newAmoTask, "https://vad7043.amocrm.ru/api/v2/tasks", authResCookie.Cookie);
            Assert.IsNotNull(result);
        }
    }
}
