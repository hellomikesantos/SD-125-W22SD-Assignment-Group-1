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
        private TicketBusinessLogic BusinessLogic;
        private UserManager<ApplicationUser> userManager;

        public TicketBLLUnitTests()
        {
            var ticketData = new List<Ticket>
            {
                new Ticket {Id = 1},
                new Ticket {Id = 2},
                new Ticket {Id = 3},
                new Ticket {Id = 4},
                new Ticket {Id = 5},
            }.AsQueryable();

            var mockDbSetTicket = new Mock<DbSet<Ticket>>();

            mockDbSetTicket.As<IQueryable<Ticket>>().Setup(m => m.Provider).Returns(ticketData.Provider);
            mockDbSetTicket.As<IQueryable<Ticket>>().Setup(m => m.Expression).Returns(ticketData.Expression);
            mockDbSetTicket.As<IQueryable<Ticket>>().Setup(m => m.ElementType).Returns(ticketData.ElementType);
            mockDbSetTicket.As<IQueryable<Ticket>>().Setup(m => m.GetEnumerator()).Returns(ticketData.GetEnumerator());


            var mockContextTicket = new Mock<ApplicationDbContext>();
            mockContextTicket.Setup(c => c.Ticket).Returns(mockDbSetTicket.Object);

            BusinessLogic = new TicketBusinessLogic(new TicketRepository(mockContextTicket.Object),
                userManager);
        }

        [TestMethod]
        public void CreateTicket_ValidInput_CreatesNewTicketAndAddsToTickets()
        {
            //BusinessLogic.CreateTicket(new Ticket)

            //Assert.AreEqual()
        }

        [TestMethod]
        public void GetTicket_ValidInput_ReturnsTicketEntity()
        {

        }

        [TestMethod]
        public void GetTicket_TicketNotFound_IfInvalidId_ThrowsNullReferenceException()
        {

        }

        [TestMethod]
        public void GetTicketList_ValidInput_ReturnsListOfTickets()
        {

        }

        [TestMethod]
        public void GetCompletedTickets_ValidInput_ReturnsListofTicketsThatAreCompleted()
        {

        }

        [TestMethod]
        public void GetCompletedTickets_NoTicketList_ThrowsInvalidDataException()
        {

        }

        [TestMethod]
        public void GetUncompletedTickets_ValidInput_ReturnsListOFTicketsThatAreUncompleted()
        {

        }

        [TestMethod]
        public void GetUncompletedTickets_NoTicketList_ThrowsInvalidDataException()
        {

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
