﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment_RaceTrack;
using Assessment_RaceTrack.Controllers;
using Moq;
using Assessment_RaceTrack.Data;

namespace Assessment_RaceTrack.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            // HomeController controller = new HomeController();
            var mockContext = new Mock<RaceTrackContext>();
         //   mockContext.
            // Act
          //  ViewResult result = controller.Index() as ViewResult;

            // Assert
          //  Assert.IsNotNull(result);
        }

       
       
    }
}
