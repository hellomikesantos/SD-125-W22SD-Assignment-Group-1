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
            // mock data
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

    }
}
