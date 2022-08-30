using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazePages.Pages
{
    public class ProductPage : BasePage
    {

        private HeaderNav headernav;
        public ProductPage(IWebDriver driver) : base(driver)
        {
            headernav = new HeaderNav(driver);
        }

        public IWebElement producttitle => driver.FindElement(By.XPath("//h2[@class='name']"));

        public IWebElement AddtoCartbutton => driver.FindElement(By.XPath("//a[text()='Add to cart']"));

        public IWebElement ProductPriceElement => driver.FindElement(By.XPath("//h2[@class='name']//following::h3[@class='price-container']"));



        public CartPage AddProductToCart() {
            ClickElement(AddtoCartbutton);
            getAlertText();
            headernav.NavigateToCartPage();
            return new CartPage(driver);

        }

        //public int GetProductPrice() { 
        
        //      string pricetag =   GetTextFromElement(ProductPriceElement);
        //    Console.WriteLine($"Product price is {pricetag}");
        //    int indexposition = pricetag.IndexOf('*');
        //     Console.WriteLine($"Product price is {pricetag.Substring(1,(indexposition-2))}");
        //     int prod_price = int.Parse(pricetag.Substring(1, (indexposition - 2)));
        //     Console.WriteLine($"return value is {prod_price}");
        //      return prod_price;

        
        //}

       

    }
}
