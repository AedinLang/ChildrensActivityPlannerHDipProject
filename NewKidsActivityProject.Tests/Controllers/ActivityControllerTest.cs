using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewKidsActivityProject.Controllers;

namespace NewKidsActivityProject.Tests.Controllers
{
    [TestClass]
    public class ActivityControllerTest
    {
        [TestMethod]
        public void AllActivities()
        {
            // Arrange
            var controller = new ActivityController();

            // Act
            ViewResult result = controller.AllActivities() as ViewResult;

            // Assert
            Assert.AreEqual("AllActivities", result.ViewName);    
        }

        /*[TestMethod]
        public void TestEnrollments()
        {
            // Arrange
            ActivityController controller = new ActivityController();

            // Act
            ViewResult result = controller.Enrollments() as ViewResult;

            // Assert
            Assert.AreEqual("AllA")
        }*/
    }
}
