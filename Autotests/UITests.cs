using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Autotests
{
    public class Tests
    {
        PageObjects po;

        [SetUp]
        public void Setup()
        {
            po = new();
        }

        [Test]
        public void Test01()
        {
            po.ChangeCategory();
            Assert.AreEqual(po.CheckCategory(), "Dresses");
        }

        [Test]
        public void Test02()
        {
            po.ClickCartButton();
            Assert.AreEqual(po.ProductsCnt(), "Cart is empty");
        }

        [Test]
        public void Test03()
        {
            po.FillSearchBar("Blouse");
            Assert.AreEqual(po.CheckSearch(), "\"BLOUSE\"");
        }

        [Test]
        public void Test04()
        {
            po.ClickAddOneButton();
            Assert.AreEqual(po.CheckElemInCart(), "Faded Short Sleeve T-shirts");
        }

        [Test]
        public void Test05()
        {
            po.AddManyWithPlusButton(3);
            Assert.AreEqual(po.ProductsCnt(), "3 Products");
        }

        [Test]
        public void Test06()
        {
            po.AddManyWithWritingCnt("3");
            Assert.AreEqual(po.ProductsCnt(), "3 Products");
        }

        [Test]
        public void Test07()
        {
            po.AddManyWithWritingCnt("1000000000000");
            Assert.AreEqual(po.ProductsCnt(), "4294967295 Products");
        }

        [Test]
        public void Test08()
        {
            po.AddManyWithPlusButton(3);
            po.DeleteFromCartWithMinusButton(1);
            Assert.AreEqual(po.ProductsCnt(), "2 Products");
        }

        [Test]
        public void Test09()
        {
            po.AddManyWithPlusButton(3);
            po.DeleteFromCartWithDeleteButton();
            Assert.AreEqual(po.ProductsCnt(), "Cart is empty");
        }

        [Test]
        public void Test10()
        {
            po.AddManyWithPlusButton(3);
            po.AddToCartWithPlusButton(3);
            Assert.AreEqual(po.ProductsCnt(), "6 Products");
        }
    }
}