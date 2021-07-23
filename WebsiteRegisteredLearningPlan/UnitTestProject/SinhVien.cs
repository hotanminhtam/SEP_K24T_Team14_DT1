using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers;
using WebsiteRegisteredLearningPlan.Models;

namespace WebsiteRegisteredLearningPlan.Areas.SinhVien.Controllers
{
    [TestClass]
    public class SinhVien
    {
        [TestMethod]
        public void TestXemCTDT()
        {
            Entities db = new Entities();

            var ctdt = new XemCTDTController();

            var rs = ctdt.ChuongTrinhDaoTao() as ViewResult;
            Assert.IsNotNull(rs);

            var model = rs.Model as List<CTDT>;
            Assert.IsNotNull(model);

            // Assert
            Assert.AreEqual(db.CTDTs.ToList(), model.Count);
        }

        [TestMethod]
        public void TestTimKiem()
        {
        }
    }

    [TestClass]
    public class HomeControllerTest
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

    [TestClass]
    public class CapnhatTaiKhoanControllerTest
    {
        [TestMethod]
        public void TestXemTK(string id)
        {
            Entities db = new Entities();
            var user = new CapnhatTaiKhoanController();

            var rs = user.CapNhatTK(id) as ViewResult;
            Assert.IsNotNull(rs);

            var model = rs.Model as List<CTTAIKHOAN>;
            Assert.IsNotNull(model);

            Assert.AreEqual(db.CTTAIKHOANs.Find(id), model.Count);
        }
    }
}
