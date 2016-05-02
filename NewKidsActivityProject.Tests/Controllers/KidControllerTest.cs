using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using NewKidsActivityProject.Controllers;

namespace NewKidsActivityProject.Tests.Controllers
{
    [TestClass]
    public class KidControllerTest
    {
        [TestMethod]
        public void CanViewAllKids()
        {
            // Arrange
            var controller = new KidController();

            // Act
            ViewResult result = controller.AllKids() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void CanViewKidDetails()
        {
            // Arrange
            var controller = new KidController();

            // Act
            ViewResult result = controller.KidDetails(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void CanViewCreate()
        {
            // Arrange
            var controller = new KidController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void CanViewEditChild()
        {
            // Arrange
            var controller = new KidController();

            // Act
            ViewResult result = controller.EditChild() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void CanViewDuplicate()
        {
            // Arrange
            var controller = new KidController();

            // Act
            ViewResult result = controller.Duplicate() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void CanViewRemoveChild()
        {
            // Arrange
            var controller = new KidController();

            // Act
            ViewResult result = controller.RemoveChild() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void CanViewKidDelete()
        {
            // Arrange
            var controller = new ActivityController();

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void CanViewKidDeleteConfirmed()
        {
            // Arrange
            var controller = new KidController();

            // Act
            ViewResult result = controller.DeleteConfirmed(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
    }
}
