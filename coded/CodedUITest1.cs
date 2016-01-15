
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
                    .typeAndSignUpClick("Jan152016@yandex.ru", "rondam", 
                        "Chirca777", "myTestCompany",
                            "Chisinau", "Chisinau", 
                                "Bahamas","Test7Test7Test7","русский",
                                    true,true,true).typeAndLoginClick("Jan152016@yandex.ru","Test7Test7Test7");
                   
        }
        

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
