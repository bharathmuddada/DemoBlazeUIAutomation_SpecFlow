using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazePages.Pages
{
    public class HeaderNav 
    {
        private IWebDriver driver;

        public HeaderNav(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public IWebElement homePage_link => driver.FindElement(By.XPath("//a[contains(text(),'Home')]"));

        public IWebElement contactPage_link => driver.FindElement(By.XPath("//a[contains(text(),'Contact')]"));

        public IWebElement aboutusPage_link => driver.FindElement(By.XPath("//a[contains(text(),'About')]"));

        public IWebElement cartPage_link => driver.FindElement(By.XPath("//a[contains(text(),'Cart')]"));

        public IWebElement loginPage_link => driver.FindElement(By.XPath("//a[contains(text(),'Log in')]"));


        public LoginPage NavigateToLoginPage() {
            loginPage_link.Click();
           
            return new LoginPage(driver);

        }

        public CartPage NavigateToCartPage()
        {
            cartPage_link.Click();
            return new CartPage(driver);

        }

        public HomePage NavigateToHomePage()
        {
            homePage_link.Click();
            return new HomePage(driver);

        }


    }
}
