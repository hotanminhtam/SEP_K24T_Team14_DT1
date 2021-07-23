using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Areas.QuanLy.Controllers;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Tests.Controllers
{
    [TestClass]
    public class QuanLy
    {
        [TestMethod]
        public void TestTrangChu()
        {
            // Arrange
            HomeController home = new HomeController();

            // Act
            ViewResult result = home.TrangChu() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
