using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazePages.Pages
{
    public class BasePage
    {
     
        public HeaderNav HeaderBar;

        protected WebDriverWait wait;
        protected IWebDriver driver;


        public BasePage(IWebDriver driver) {
            this.driver = driver;
            HeaderBar = new HeaderNav(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            

        }

       
        public bool WaitForElementTobeDisplayed(IWebElement element)
        {
          
            var web_element = wait.Until(drv => element);
            return web_element.Displayed;
            
        }
       
        public bool WaitForElementsTobeDisplayed(IReadOnlyCollection<IWebElement> elements)
        {
            bool status = false;
            foreach (var element in elements)
            {
                var web_element = wait.Until(drv => element);
                status = web_element.Displayed;
            }
            return status;

        
        }

        public bool WaitForElementTobeEnabled(IWebElement element)
        {

            var web_element = wait.Until(drv => element);
            return web_element.Enabled;

        }

        public void ClickElement(IWebElement element)
        {

            if (WaitForElementTobeEnabled(element) && WaitForElementTobeDisplayed(element))
            {
                Console.WriteLine(element.Text+" element is clicked");
                element.Click();

            }


        }

        public void SendTextToElement(IWebElement element, string text)
        {
            ClickElement(element);
            Console.WriteLine($"Sending {text} to element");
            element.SendKeys(text);


        }

        public string GetTextFromElement(IWebElement element)
        {
            WaitForElementTobeDisplayed(element);
            Console.WriteLine($"text from the element is  {element.Text}");
           
            return element.Text;


        }

        public string getAlertText() {

            IAlert alert = wait.Until(drv => driver.SwitchTo().Alert()) ;
            //alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            alert.Accept();
            return alertText;
           
        }



    }


}
