
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using coded.pages;
using System;

namespace coded
{
    /// <summary>
    /// Сводное описание для CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            mainPage main = new mainPage();
            main.launchPage().goToRegistration().
                typeAndLoginClick()
                    .typeAndSignUpClick("rondam888@yandex.ru", "Natalia777", 
                        "Chirca888", "myTestCompany",
                            "Chisinau", "Chisinau", 
                                "Bahamas","TestIsSuccessfull66","русский",
                                    true,true,true);
                   
        }
        /*[TestMethod]
        public void CodedUITestMethod2(){
            POP3client client = new POP3client("pop3.yandex.ru", 995, true, "rondam888@yandex.ru", "asdfghjkl888");
            string link = client.getTextOfLink("<a href=\" http://www.get.com/val?a=111&b=234\">http://www.get.com/val?a=111&b=234</a>");
        }*/

        #region Дополнительные атрибуты тестирования

        // При написании тестов можно использовать следующие дополнительные атрибуты:

        ////TestInitialize используется для выполнения кода перед запуском каждого теста 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // Чтобы создать код для этого теста, выберите в контекстном меню команду "Формирование кода для кодированного теста пользовательского интерфейса", а затем выберите один из пунктов меню.
        //}

        ////TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // Чтобы создать код для этого теста, выберите в контекстном меню команду "Формирование кода для кодированного теста пользовательского интерфейса", а затем выберите один из пунктов меню.
        //}

        #endregion

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
