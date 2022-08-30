using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazePages.Pages
{
    public class HomePage : BasePage
    {
        //private IWebDriver driver;
        public HomePage(IWebDriver driver) : base(driver)
        {
            //this.driver = driver;
         }


        public IWebElement Menu_selection(string menu_name)  => driver.FindElement(By.XPath($"//a[text()='{menu_name}']"));
        public IWebElement ItemSelected(string name) => driver.FindElement(By.XPath($"//a[text()='{name}']"));



        public HomePage  clickOnMenu(string menuname) {

            //for (int i = 0; i <= 2; i++)
            //{
            //    try
            //    {
            //        ClickElement(Menu_selection(menuname));
            //        break;
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //}

            driver.Navigate().Refresh();
            ClickElement(Menu_selection(menuname));
            return this;

        }

        public ProductPage SelectItemToView(string productName)
        {
            try
            {
                ClickElement(Menu_selection(productName));
            }
            catch (StaleElementReferenceException e) 
            {
                Console.WriteLine(e.Message);
                driver.Navigate().Refresh();
                Console.WriteLine("Page refreshed to handle stale element exception");
                ClickElement(Menu_selection(productName));
            }

            //ClickElement(ItemSelected(productName));
            return new ProductPage(driver);
        }






    }
}
