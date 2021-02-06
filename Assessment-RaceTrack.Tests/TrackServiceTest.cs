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
        private IList<Vehicle> mockdata;
        private Mock<IRaceTrackContext> mockContext;
        private Mock<IVehicleRepository> mockRepository;
        private Mock<IUnitOfWork> mockUnitOfWork;
        private VehicleDto mockVehicleDto;
        Guid mockedVehicleId;

        #endregion

        #region TEST SETUP

        private void Setup()
        {
            mockedVehicleId = Guid.NewGuid();
            mockdata = new List<Vehicle>()
            {
                //Prepaire vehicle data for migration
                new Vehicle()
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
                 new Vehicle ()
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

            var dbSetGenres = GetMockDbSet<Vehicle>(mockdata);
            mockContext = new Mock<IRaceTrackContext>();

            mockUnitOfWork = new Mock<IUnitOfWork>();
            mockRepository = new Mock<IVehicleRepository>();

            //mockRepository.Setup(d => d.Get(null, null, null)).Returns(() => mockdata);

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

            mockVehicleDto = new VehicleDto()
            {
                Id = Guid.NewGuid(),
                Name = "This is 1St vehicle on race track",
                HandBreak = true,
                TowStrap = true,
                Lift = 5,
                Image = "v1.PNG",
                IsActive = true,
                CreatedDate = DateTime.Now,
                OnTrack = true
            };

            //ACT
            var actualResult = trackService.AddVehiclesOnTrack(mockVehicleDto);

            //ASSERT
            Assert.AreEqual(Response.Inserted, actualResult);
        }

        [TestMethod]
        public void Should_Remove_Vehicle_FromTrack()
        {
            // Arrange
            Setup();

            //ACT
            var actualResult = trackService.RemoveVehiclesFromTrack(mockedVehicleId);

            //ASSERT
            Assert.AreEqual(Response.Deleted, actualResult);
        }

        [TestMethod]
        public void Should_Get_VehiclesOnTrack()
        {
            // Arrange
            Setup();
            mockRepository.Setup(d => d.GetVehiclesOnTrack(It.IsAny<int>())).Returns(() => mockdata);

            //ACT
            var actualResult = trackService.GetVehiclesOnTrack();

            //ASSERT
            Assert.IsTrue(actualResult.Count() > 0);
        }
    }
}
