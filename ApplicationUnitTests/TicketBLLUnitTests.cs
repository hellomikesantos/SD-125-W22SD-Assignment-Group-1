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
        private CommentBusinessLogic CommentBusinessLogic;
        private UserBusinessLogic UserBusinessLogic;
        private UserManager<ApplicationUser> UserManager;
        private Mock<UserManager<ApplicationUser>> UserManagerMock;

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

            // Ticket DbSet
            var ticketData = new List<Ticket>
            {
                //Add comment, dev, owner, watcher
                new Ticket{Id = 1, ProjectId = 1,Project = projData.First(p => p.Id == 1), Completed = false, Priority = Priority.medium, Hours = 5, Name = "Ticket 1 of Project 1"},
                new Ticket{Id = 2, ProjectId = 1,Project = projData.First(p => p.Id == 1), Completed = true, Priority = Priority.low, Hours = 3, Name = "Ticket 2 of Project 1"},
                new Ticket{Id = 3, ProjectId = 2,Project = projData.First(p => p.Id == 2), Completed = false, Priority = Priority.medium, Hours = 5, Name = "Ticket 1 of Project 2"},
                new Ticket{Id = 4, ProjectId = 3,Project = projData.First(p => p.Id == 3), Completed = false, Priority = Priority.medium, Hours = 5, Name = "Ticket 1 of Project 3"},
                //new Ticket{Id = 4, ProjectId = 4,Project = projData.First(p => p.Id == 4), Completed = false, Priority = Priority.medium, Hours = 5, Name = "Ticket 4"},
                //new Ticket{Id = 5, ProjectId = 5,Project = projData.First(p => p.Id == 5), Completed = false, Priority = Priority.medium, Hours = 5, Name = "Ticket 5"},
            }.AsQueryable();

            var ticketMockDbSet = new Mock<DbSet<Ticket>>();

            ticketMockDbSet.As<IQueryable<Ticket>>().Setup(m => m.Provider).Returns(ticketData.Provider);
            ticketMockDbSet.As<IQueryable<Ticket>>().Setup(m => m.Expression).Returns(ticketData.Expression);
            ticketMockDbSet.As<IQueryable<Ticket>>().Setup(m => m.ElementType).Returns(ticketData.ElementType);
            ticketMockDbSet.As<IQueryable<Ticket>>().Setup(m => m.GetEnumerator()).Returns(ticketData.GetEnumerator());

            var ticketMockContext = new Mock<ApplicationDbContext>();
            ticketMockContext.Setup(m => m.Ticket).Returns(ticketMockDbSet.Object);

            TicketBusinessLogic = new TicketBusinessLogic(new TicketRepository(ticketMockContext.Object), UserManager);

            // Comment DbSet
            var commentData = new List<Comment>
            {
                //Add User
                new Comment{Id = 1, Content = "Comment One", TicketId = 1, Ticket = ticketData.First(t => t.Id == 1)},
                new Comment{Id = 2, Content = "Comment Two", TicketId = 2, Ticket = ticketData.First(t => t.Id == 2)},
                new Comment{Id = 3, Content = "Comment Three", TicketId = 3, Ticket = ticketData.First(t => t.Id == 3)},
                }.AsQueryable();

            var commentMockDbSet = new Mock<DbSet<Comment>>();

            commentMockDbSet.As<IQueryable<Comment>>().Setup(m => m.Provider).Returns(commentData.Provider);
            commentMockDbSet.As<IQueryable<Comment>>().Setup(m => m.Expression).Returns(commentData.Expression);
            commentMockDbSet.As<IQueryable<Comment>>().Setup(m => m.ElementType).Returns(commentData.ElementType);
            commentMockDbSet.As<IQueryable<Comment>>().Setup(m => m.GetEnumerator()).Returns(commentData.GetEnumerator());

            var commentMockContext = new Mock<ApplicationDbContext>();
            commentMockContext.Setup(m => m.Comment).Returns(commentMockDbSet.Object);

            CommentBusinessLogic = new CommentBusinessLogic(new CommentRepository(commentMockContext.Object), UserManager);

            // User DbSet
            var userData = new List<ApplicationUser>
            {
                new ApplicationUser{Id = "9ac002a1-5cc3-499e-bcc7-36849706b9ff", Email = "mockUser1", Projects = projData.ToList(), Tickets = ticketData.ToList(), Comments = commentData.ToList()},
                new ApplicationUser{Id = "df646de0-62a4-480a-8fe5-aa7fe98341bf", Email = "mockUser2", Projects = projData.ToList(), Tickets = ticketData.ToList(), Comments = commentData.ToList()},
                new ApplicationUser{Id = "df646de0-62a4-480a-8fe5-aa7fe98341sf", Email = "mockUser3", Projects = projData.ToList(), Tickets = ticketData.ToList(), Comments = commentData.ToList()},
            }.AsQueryable();

            var userMockDbSet = new Mock<DbSet<ApplicationUser>>();

            userMockDbSet.As<IQueryable<ApplicationUser>>().Setup(m => m.Provider).Returns(userData.Provider);
            userMockDbSet.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(userData.Expression);
            userMockDbSet.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            userMockDbSet.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());

            var userMockContext = new Mock<ApplicationDbContext>();
            userMockContext.Setup(m => m.Users).Returns(userMockDbSet.Object);

            UserBusinessLogic = new UserBusinessLogic(UserManager);

        }

        [TestInitialize]
        public void TestInitializer()
        {
            var ticketFalse = TicketBusinessLogic.GetTicket(1).Completed = false;
            var ticketTrue = TicketBusinessLogic.GetTicket(2).Completed = true;
        }

        [DataRow(2)]
        [TestMethod]
        public void CreateTicket_ValidInput_CreatesNewTicketAndAddsToTickets(int assertedCount)
        {
            // arrange
            // act
            TicketBusinessLogic.CreateTicket(new Ticket { ProjectId = 1, Project = ProjectBusinessLogic.GetAllProjects().First(p => p.Id == 1)});
            
            int actualCount = TicketBusinessLogic.GetTicketList(1).Count();
            Assert.AreEqual(assertedCount, actualCount);
        }

        [DataRow(1)]
        [TestMethod]
        public void GetTicket_ValidInput_ReturnsTicketEntity(int assertedId)
        {
            // assert
            // act
            int actualId = TicketBusinessLogic.GetTicket(1).Id;
            Assert.AreEqual(assertedId, actualId);
        }

        [TestMethod]
        public void GetTicket_TicketNotFound_IfInvalidId_ThrowsNullReferenceException()
        {

            Assert.ThrowsException<NullReferenceException>(() =>
            {
                TicketBusinessLogic.GetTicket(10);
            });
        }

        [DataRow(2)]
        [TestMethod]
        public void GetTicketList_ValidInput_ReturnsListOfTickets(int assertedCount)
        {
            int actualCount = TicketBusinessLogic.GetTicketList(1).Count();
            Assert.AreEqual(assertedCount, actualCount);
        }

        [DataRow(1)]
        [TestMethod]
        public void GetCompletedTickets_ValidInput_ReturnsListofTicketsThatAreCompleted(int assertedCount)
        {
            int actualCount = TicketBusinessLogic.GetCompletedTickets(1).Count();
            Assert.AreEqual(assertedCount, actualCount);
        }

        [DataRow(1)]
        [TestMethod]
        public void GetUncompletedTickets_ValidInput_ReturnsListOFTicketsThatAreUncompleted(int assertedCount)
        {
            int actualCount = TicketBusinessLogic.GetUncompletedTickets(1).Count();
            Assert.AreEqual(assertedCount, actualCount);    
        }

        [DataRow(true)]
        [TestMethod]
        public void UpdateTicketStatus_ValidInput_UpdatesTheTicketStatusToNewBoolValue(bool assertedStatus)
        {
            Ticket ticket = TicketBusinessLogic.GetTicket(3);
            TicketBusinessLogic.UpdateTicketStatus(ticket);
            bool actualStatus = ticket.Completed;
            Assert.AreEqual(assertedStatus, actualStatus);
        }

        [DataRow(4)]
        [TestMethod]
        public void UpdateTicketRequiredHours_ValidInput_UpdatesTheTicketRequiredHoursToNewIntValue(int assertedHours)
        {
            Ticket ticket = TicketBusinessLogic.GetTicket(4);
            TicketBusinessLogic.UpdateTicketRequiredHours(ticket, 4);
            int actualHours = ticket.Hours;
            Assert.AreEqual(assertedHours, actualHours);
        }

        [TestMethod]
        public void UpdateTicketRequiredHours_HoursNotInExpectedRange_ThrowsArgumentException()
        {
            Ticket ticket = TicketBusinessLogic.GetTicket(4);
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TicketBusinessLogic.UpdateTicketRequiredHours(ticket, 2000);
            });
        }

        [DataRow(1)]
        [TestMethod]
        public void UpdateTicketAddWatcher_ValidInput_AddsWatcherToTaskWatchersInTicket(int assertedCount)
        {
            ApplicationUser user = new ApplicationUser();
            Ticket entity = TicketBusinessLogic.GetTicket(1);
            TicketBusinessLogic.UpdateTicketAddWatcher(entity, user);
            int actualCount = entity.TaskWatchers.Count();
            Assert.AreEqual(assertedCount, actualCount);
        }

        [DataRow(0)]
        [TestMethod]
        public void UpdateTicketRemoveWatcher_ValidInput_RemovesWatcherFromTaskWatchersInTicket(int assertedCount)
        {
            ApplicationUser user = new ApplicationUser();
            Ticket entity = TicketBusinessLogic.GetTicket(2);
            TicketBusinessLogic.UpdateTicketAddWatcher(entity, user);
            TicketBusinessLogic.UpdateTicketRemoveWatcher(entity, user);
            int actualCount = entity.TaskWatchers.Count();
            Assert.AreEqual(assertedCount, actualCount);
        }
    }
}