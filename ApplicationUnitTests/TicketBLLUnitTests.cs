using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using SD_340_W22SD_2021_2022___Final_Project_2.BLL;
using SD_340_W22SD_2021_2022___Final_Project_2.DAL;
using SD_340_W22SD_2021_2022___Final_Project_2.Data;
using SD_340_W22SD_2021_2022___Final_Project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUnitTests
{
    [TestClass]
    public class TicketBLLUnitTests
    {
        private TicketBusinessLogic TicketBusinessLogic;
        private ProjectBusinessLogic ProjectBusinessLogic;
        private UserManager<ApplicationUser> userManager;

        public TicketBLLUnitTests()
        {
            // Project DbSet
            var projData = new List<Project>
            {
                new Project{Id = 1, Name = "Project 1"},
                new Project{Id = 2, Name = "Project 2"},
                new Project{Id = 3, Name = "Project 3"},
            }.AsQueryable();

            var ProjMockDbSet = new Mock<DbSet<Project>>();

            ProjMockDbSet.As<IQueryable<Project>>().Setup(m => m.Provider).Returns(projData.Provider);
            ProjMockDbSet.As<IQueryable<Project>>().Setup(m => m.Expression).Returns(projData.Expression);
            ProjMockDbSet.As<IQueryable<Project>>().Setup(m => m.ElementType).Returns(projData.ElementType);
            ProjMockDbSet.As<IQueryable<Project>>().Setup(m => m.GetEnumerator()).Returns(projData.GetEnumerator());

            var projMockContext = new Mock<ApplicationDbContext>();
            projMockContext.Setup(m => m.Project).Returns(ProjMockDbSet.Object);

            ProjectBusinessLogic = new ProjectBusinessLogic(new ProjectRepository(projMockContext.Object), UserManager);
            
            
            
        }

        [DataRow(6)]
        [TestMethod]
        public void CreateTicket_ValidInput_CreatesNewTicketAndAddsToTickets(int assertedCount)
        {
            // arrange

            // act
            BusinessLogic.CreateTicket(new Ticket());
            int actualCount = BusinessLogic.GetTicketList().Count();

            Assert.AreEqual(assertedCount, actualCount);
        }

        [DataRow(1)]
        [TestMethod]
        public void GetTicket_ValidInput_ReturnsTicketEntity(int assertedId)
        {
            // assert
            // act
            int actualId = BusinessLogic.GetTicket(1).Id;
            Assert.AreEqual(assertedId, actualId);
        }

        [TestMethod]
        public void GetTicket_TicketNotFound_IfInvalidId_ThrowsNullReferenceException()
        {

            Assert.ThrowsException<NullReferenceException>(() =>
            {
                BusinessLogic.GetTicket(10);
            });
        }

        [DataRow(5)]
        [TestMethod]
        public void GetTicketList_ValidInput_ReturnsListOfTickets(int assertedCount)
        {
            int actualCount = BusinessLogic.GetTicketList().Count();
            Assert.AreEqual(assertedCount, actualCount);
        }

        [DataRow(3)]
        [TestMethod]
        public void GetCompletedTickets_ValidInput_ReturnsListofTicketsThatAreCompleted(int assertedCount)
        {
            int actualCount = BusinessLogic.GetCompletedTickets().Count();
            Assert.AreEqual(assertedCount, actualCount);
        }

        [DataRow(2)]
        [TestMethod]
        public void GetUncompletedTickets_ValidInput_ReturnsListOFTicketsThatAreUncompleted(int assertedCount)
        {
            int actualCount = BusinessLogic.GetTicketList().Count();
            Assert.AreEqual(assertedCount, actualCount);
        }

        [TestMethod]
        public void GetUncompletedTickets_ProjectIdNotFound_ThrowsNullReferenceException()
        {
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                BusinessLogic.GetTicketList();
            });
        }

        [TestMethod]
        public void UpdateTicketStatus_ValidInput_UpdatesTheTicketStatusToNewBoolValue()
        {

        }

        [TestMethod]
        public void UpdateTicketStatus_TicketNotFound_ThrowsNullReferenceException()
        {

        }

        [TestMethod]
        public void UpdateTicketRequiredHours_ValidInput_UpdatesTheTicketRequiredHoursToNewIntValue()
        {

        }

        [TestMethod]
        public void UpdateTicketRequiredHours_HoursNotInExpectedRange_ThrowsArgumentException()
        {

        }

        [TestMethod]
        public void UpdateTicketAddWatcher_ValidInput_AddsWatcherToTaskWatchersInTicket()
        {

        }

        [TestMethod]
        public void UpdateTicketRemoveWatcher_ValidInput_RemovesWatcherFromTaskWatchersInTicket()
        {

        }

    }
}
