using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewKidsActivityProject.Controllers;
using System.Collections;
using NewKidsActivityProject.Models;

namespace NewKidsActivityProject.Tests.Controllers
{
    [TestClass]
    public class ActivityControllerTest
    {
        [TestMethod]
        public void CanViewAllActivities()
        {
            // Arrange
            var controller = new ActivityController();

            // Act
            ViewResult result = controller.AllActivities() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void CanViewEnrollments()
        {
            // Arrange
            var controller = new ActivityController();

            // Act
            ViewResult result = controller.Enrollments() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void CanViewEnrollmentsForActivity()
        {
            // Arrange
            var controller = new ActivityController();

            // Act
            //ViewResult result = controller.EnrollmentsForActivity(1) as ViewResult;
            var result = controller.EnrollmentsForActivity(1) as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
            Assert.AreEqual("EnrollmentsForActivity", result.ViewName);
        }


        [TestMethod]
        public void CanViewCreate()
        {
            // Arrange
            var controller = new ActivityController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void CanViewEditActivity()
        {
            // Arrange
            var controller = new ActivityController();

            // Act
            ViewResult result = controller.EditActivity() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void CanViewEdit()
        {
            // Arrange
            var controller = new ActivityController();

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void RemoveActivity()
        {
            // Arrange
            var controller = new ActivityController();

            // Act
            ViewResult result = controller.RemoveActivity() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void CanViewDelete()
        {
            // Arrange
            var controller = new ActivityController();

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void CanViewDeleteConfirmed()
        {
            // Arrange
            var controller = new ActivityController();

            // Act
            ViewResult result = controller.DeleteConfirmed(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void CanViewActivityDup()
        {
            // Arrange
            var controller = new ActivityController();

            // Act
            ViewResult result = controller.Duplicate() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
    }
}
