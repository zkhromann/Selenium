using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace SeleniumTutorial
{
    public class SeleniumTests
    {
        private IWebDriver driver;



        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://new.chitai-gorod.ru/");
            driver.Manage().Window.Maximize();

        }
       
         
        [Test]
        public void SearchTest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[1]/div/a")).Click(); //старая версия

            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[3]/div/div[2]/form/input")).Click(); //клик поиска
            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[3]/div/div[2]/form/input")).SendKeys("Дежавю"); //ввод слова
            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[3]/div/div[2]/form/button")).Click(); //клик лупы
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollBy(0,350)");
            driver.FindElement(By.XPath("/html/body/div[2]/main/div/div/div[2]/div[3]/div[1]/div[1]/a")).Click(); //клик по книге
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollBy(0,270)");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/main/div[2]/div[1]/div[1]/div[4]/div[1]/button")).Click(); //добавить в корзину
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[3]/div/div[3]/div/a[1]/span[1]")).Click(); //клик корзины
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[3]/div/div[1]/a/img")).Click(); //клик лого



        }
        

        [Test]
        public void GlavnayaStr()
        {
            driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[1]/div/a")).Click(); //старая версия

            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/nav/div/ul/li[1]/a/b")).Click(); //клик меню книг
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[3]/div/div[1]/a/img")).Click(); //клик лого
            Thread.Sleep(1000);
        }
      
        [Test]
        public void SocSeti()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver; //драйвер js
            driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[1]/div/a")).Click(); //старая версия
            js.ExecuteScript("window.scrollBy(0,15000)"); 
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/footer/div/div[1]/section[3]/div/ul/li[1]/a")).Click();//клик по кнопки вк
            Thread.Sleep(4000);
            string newTabHandle = driver.WindowHandles.First();//возврат на первую вкладку
            var newTab = driver.SwitchTo().Window(newTabHandle);
            Thread.Sleep(4000);
            js.ExecuteScript("window.scrollBy(0,-15000)");

        }
        [Test]
        public void SignIn()
        {
            driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[1]/div/a")).Click(); //старая версия

            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[2]/div/ul/li[6]/button")).Click(); //войти 
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html/body/div[5]/div/div/div[2]/div[1]/p[2]")).Click(); //Войти с логином и паролем
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"popup-email\"]")).SendKeys("Lipovka55912@yandex.ru");
            driver.FindElement(By.XPath("//*[@id=\"popup-password\"]")).SendKeys("0pz8hlbo");
            driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]")).Click();//клик войти
            Thread.Sleep(1000);
        }
        
        [Test]
        public void Rabota()
        {
            driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[1]/div/a")).Click(); //старая версия

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver; //драйвер js
            js.ExecuteScript("window.scrollBy(0,15000)");
            driver.FindElement(By.XPath("/html/body/div[2]/footer/div/div[1]/section[1]/ul/li[5]/a")).Click(); //работать у нас 
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[4]/div[2]/a[3]")).Click(); //заполнить анкету
            driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/label[2]/span")).Click();//Магазин
            js.ExecuteScript("window.scrollBy(0,500)");
            driver.FindElement(By.XPath("//*[@id=\"form_city\"]")).SendKeys("Москва");//город
            driver.FindElement(By.XPath("//*[@id=\"form_position\"]")).SendKeys("Уборщица");//должность
            driver.FindElement(By.XPath("//*[@id=\"form_wages\"]")).SendKeys("45000");//зп
            driver.FindElement(By.XPath("//*[@id=\"form_family\"]")).SendKeys("Иванова");//фамилия
            driver.FindElement(By.XPath("//*[@id=\"form_name\"]")).SendKeys("Гульнара");//имя
            driver.FindElement(By.XPath("//*[@id=\"form_additional_name\"]")).SendKeys("Решатовна");//отчество
            driver.FindElement(By.XPath("//*[@id=\"form_country_name\"]")).SendKeys("почти Русское");//гражданство
            driver.FindElement(By.XPath("//*[@id=\"form_tel\"]")).SendKeys("+79001324421");//телефон
            driver.FindElement(By.XPath("//*[@id=\"form_email\"]")).SendKeys("QWERTY@yandex.ru");//почта
            driver.FindElement(By.XPath("//*[@id=\"form_metro\"]")).SendKeys("Измайловская");//метро
            driver.FindElement(By.XPath("//*[@id=\"form_schedule\"]")).SendKeys("7/0");//график
            driver.FindElement(By.XPath("//*[@id=\"form_file\"]")).SendKeys("/Users/romanzaharov/Desktop/ПРАКТИЧЕСКАЯ РАБОТА 8.docx");//прикрепление файла
            Thread.Sleep(3000);

        }
        [Test]
        public void Podderjka()
        {
            driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[1]/div/a")).Click();//старая версия
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;//драйвер js
            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[1]/div/div[4]/a")).Click();
            js.ExecuteScript("window.scrollBy(0,1500)");//спусться вниз до выбора обращения 
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/main/div[4]/div[4]/div[9]")).Click();//клик обращайтесь по всем вопросам
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"name\"]")).SendKeys("Roman");//имя 
            driver.FindElement(By.XPath("//*[@id=\"email\"]")).SendKeys("Qqwerr@yandex.ru");//почта
            driver.FindElement(By.XPath("//*[@id=\"suggestion\"]")).SendKeys("Это проверка 5 тест кейса");//текст
            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[3]/div/div[1]/a/img")).Click();//клик лого
        }
        [Test]
        public void Korzina()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.FindElement(By.XPath("//*[@id=\"__layout\"]/div/div[1]/div/a")).Click(); //старая версия
            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/nav/div/ul/li[5]/a")).Click();//творчество
            js.ExecuteScript("window.scrollBy(0,350)");
            driver.FindElement(By.XPath("/html/body/div[2]/main/div[1]/div/div[2]/section[1]/div/div/div[2]/div[3]/div/div[1]/div[2]/div[3]/div[2]/button")).Click();//добавить в корзину
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[3]/div/div[3]/a/img")).Click();//корзина
            Thread.Sleep(500);
            driver.FindElement(By.XPath("/ html /body/div[2]/main/div/div[2]/div/div[1]/div[3]/div/div/div[2]/div[1]/div[1]/div[2]\n")).Click();//+1
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div[2]/main/div/div[2]/ul/div")).Click();//удалить все товары
            driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[3]/div/div[1]/a/img")).Click();//лого
        }


        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }
        
    }
}