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
    public class ProjectBLLUnitTests
    {
        private ProjectBusinessLogic ProjectBusinessLogic;
        private TicketBusinessLogic TicketBusinessLogic;
        private CommentBusinessLogic CommentBusinessLogic;
        private UserBusinessLogic UserBusinessLogic;
        private UserManager<ApplicationUser> UserManager;

        public ProjectBLLUnitTests()
        {
            // Project DbSet
            var projData = new List<Project>
            {
                new Project{Id = 1, Name = "Project 1", Developers = {new ApplicationUser()}},
                new Project{Id = 2, Name = "Project 2", Developers = {new ApplicationUser()}},
                new Project{Id = 3, Name = "Project 3", Developers = {new ApplicationUser()}},
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
                new Ticket{Id = 1, ProjectId = 1,Project = projData.First(p => p.Id == 1), Completed = false, Priority = Priority.medium, Hours = 5, Name = "Ticket 1"},
                new Ticket{Id = 2, ProjectId = 2,Project = projData.First(p => p.Id == 2), Completed = false, Priority = Priority.medium, Hours = 5, Name = "Ticket 2"},
                new Ticket{Id = 3, ProjectId = 3,Project = projData.First(p => p.Id == 3), Completed = false, Priority = Priority.medium, Hours = 5, Name = "Ticket 3"},
                new Ticket{Id = 4, ProjectId = 4,Project = projData.First(p => p.Id == 4), Completed = false, Priority = Priority.medium, Hours = 5, Name = "Ticket 4"},
                new Ticket{Id = 5, ProjectId = 5,Project = projData.First(p => p.Id == 5), Completed = false, Priority = Priority.medium, Hours = 5, Name = "Ticket 5"},
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
        }

        [DataRow("9ac002a1-5cc3-499e-bcc7-36849706b9ff", 3)]
        [TestMethod]
        public void GetAllProjectsByDeveloperAsync_ValidInput_ReturnsListOfProjectsByDeveloper(string devId, int expectedProjCount)
        {
            ApplicationUser dev = UserBusinessLogic.GetUserByUserId(devId);
            int actualProjectCount = dev.Projects.Count();

            Assert.AreEqual(expectedProjCount, actualProjectCount);
        }

        [TestMethod]
        public void GetAllProjectsByDeveloperAsync_TicketNotFound_ThrowsNullReferenceException()
        {

        }

        [TestMethod]
        public void GetAllProjects_Valid_ReturnsAllProjects()
        {

        }

        [TestMethod]
        public void GetProjectDetails_ValidInput_ReturnsAProjectByProjectId()
        {

        }

        [TestMethod]
        public void GetProjectDetails_ProjectNotFound_ThrowsNullReferenceException()
        {

        }

        [TestMethod]
        public void CreateProject_ValidInput_CreatesNewProjectAndAddsToProjects()
        {

        }

    }
}
