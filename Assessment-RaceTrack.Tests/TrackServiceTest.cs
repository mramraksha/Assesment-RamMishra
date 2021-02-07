using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment_RaceTrack;
using Assessment_RaceTrack.Controllers;
using Moq;
using Assessment_RaceTrack.Data;
using Assessment_RaceTrack.Services;
using Assessment_RaceTrack.Models;
using System.Data.Entity;
using Assessment_RaceTrack.Core.Repository;
using Assessment_RaceTrack.Core.Repository.Common;
using System.Linq.Expressions;

namespace Assessment_RaceTrack.Tests
{
    [TestClass]
    public class TrackServiceTest
    {
        #region GLOBAL DECLRATION

        private ITrackService trackService;
        private IList<VehicleDto> mockdata;
        private Mock<IVehicleRepository> mockRepository;
       
        Guid mockedVehicleId;

        #endregion

        #region TEST SETUP

        private void Setup()
        {
            Mock<IRaceTrackContext> mockContext;
            mockedVehicleId = Guid.NewGuid();
            Mock<IUnitOfWork> mockUnitOfWork;
            mockdata = new List<VehicleDto>()
            {
                //Prepaire vehicle data for mock
                new VehicleDto()
                {
                    Id = mockedVehicleId,
                    Name = "This is 1St vehicle on race track",
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now,
                    OnTrack=true
                },
                 new VehicleDto ()
                {
                    Id = Guid.NewGuid(),
                    Name = "This is 2nd vehicle on race track",
                    HandBreak = true,
                    TowStrap = true,
                    Lift = 5,
                    Image= "v1.PNG",
                    IsActive=true,
                    CreatedDate=DateTime.Now,
                     OnTrack=true
                },
            };

            mockContext = new Mock<IRaceTrackContext>();
            mockUnitOfWork = new Mock<IUnitOfWork>();
            mockRepository = new Mock<IVehicleRepository>();
            trackService = new TrackService(mockRepository.Object);
        }

        private IDbSet<T> GetMockDbSet<T>(IList<T> data) where T : class
        {
            var queryable = data.AsQueryable();
            var mockSet = new Mock<IDbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => data.Add(s));

            return mockSet.Object;
        }

        #endregion

        [TestMethod]
        public void Should_Add_Vehicle_OnTrack()
        {
            // Arrange
            Setup();
            mockRepository.Setup(d => d.Insert(It.IsAny<Vehicle>())).Returns(() => mockdata[0]);

            var mockVehicleDto = mockdata[0];

            //Act
            var actualResult = trackService.AddVehiclesOnTrack(mockdata[0]);

            //Assert
            Assert.AreEqual(Response.Inserted, actualResult);
        }

        [TestMethod]
        public void Should_Remove_Vehicle_FromTrack()
        {
            // Arrange
            Setup();

            //Act
            var actualResult = trackService.RemoveVehiclesFromTrack(mockedVehicleId);

            //Assert
            Assert.AreEqual(Response.Deleted, actualResult);
        }

        [TestMethod]
        public void Should_Get_VehiclesOnTrack()
        {
            // Arrange
            Setup();
            mockRepository.Setup(d => d.GetVehiclesOnTrack(It.IsAny<int>())).Returns(() => mockdata);

            //Act
            var actualResult = trackService.GetVehiclesOnTrack();

            //Assert
            Assert.IsTrue(actualResult.Count() > 0);
        }
    }
}
