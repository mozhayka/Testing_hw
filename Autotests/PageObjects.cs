using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autotests
{
    class PageObjects
    {
        IWebDriver driver;
        string url = "http://automationpractice.com/index.php";

        public PageObjects()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public void ClickAddOneButton()
        {
            driver.FindElement(By.XPath("//*[@id=\"homefeatured\"]/li[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"add_to_cart\"]/button")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]")).Click();
        }

        public string CheckElemInCart()
        {
            return driver.FindElement(By.XPath("//*[@id=\"product_1_1_0_0\"]/td[2]/p/a")).Text;
        }


        public void FillSearchBar(string str = "Blouse")
        {
            driver.FindElement(By.XPath("//*[@id='search_query_top']")).SendKeys(str);
            driver.FindElement(By.XPath("//*[@id='searchbox']/button")).Click();
        }
        public string CheckSearch()
        {
            return driver.FindElement(By.XPath("//*[@id=\"center_column\"]/h1/span[1]")).Text;
        }


        public void ClickCartButton()
        {
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[3]/div/div/div[3]/div/a")).Click();
        }

        public string ProductsCnt()
        {
            try
            {
                return driver.FindElement(By.XPath("//*[@id=\"summary_products_quantity\"]")).Text;
            }
            catch
            {
                return "Cart is empty";
            }
        }


        public void ChangeCategory()
        {
            driver.FindElement(By.LinkText("DRESSES")).Click();
        }

        public string CheckCategory()
        {
            return driver.FindElement(By.XPath("//*[@id=\"center_column\"]/div[1]/div/div/span")).Text;
        }


        public void AddManyWithPlusButton(int cnt, string name = "Blouse")
        {
            driver.FindElement(By.LinkText(name)).Click();
            var plusButton = driver.FindElement(By.XPath("//*[@id=\"quantity_wanted_p\"]/a[2]"));
            for(int i = 1; i < cnt; i++)
                plusButton.Click();

            driver.FindElement(By.XPath("//*[@id=\"add_to_cart\"]/button")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]")).Click();
        }

        public void AddManyWithWritingCnt(string cnt, string name = "Blouse")
        {
            driver.FindElement(By.LinkText(name)).Click();
            driver.FindElement(By.Id("quantity_wanted")).Clear();
            driver.FindElement(By.Id("quantity_wanted")).SendKeys(cnt.ToString());


            driver.FindElement(By.XPath("//*[@id=\"add_to_cart\"]/button")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]")).Click();
        }

        public void DeleteFromCartWithMinusButton(int cnt)
        {
            var minusButton = driver.FindElement(By.XPath("//*[@id=\"cart_quantity_down_2_7_0_0\"]"));
            for (int i = 0; i < cnt; i++)
            {
                minusButton.Click();
            }
            Thread.Sleep(6000);
        }

        public void DeleteFromCartWithDeleteButton()
        {
            driver.FindElement(By.ClassName("cart_quantity_delete")).Click();
            Thread.Sleep(6000);
        }

        public void AddToCartWithPlusButton(int cnt)
        {
            var plusButton = driver.FindElement(By.Id("cart_quantity_up_2_7_0_0"));
            for (int i = 0; i < cnt; i++)
            {
                plusButton.Click();
            }
            Thread.Sleep(6000);
        }
    }
}
