﻿using Castle.Core.Resource;
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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUnitTests
{
    [TestClass]
    public class CommentBLLUnitTests
    {
        private CommentBusinessLogic BusinessLogic;
        private UserManager<ApplicationUser> UserManager;
        public CommentBLLUnitTests()
        {
            //DbSet
            var data = new List<Comment>
            {
                new Comment {Id = 1, Content = "Good", TicketId = 1, UserId = "1"},
                new Comment {Id = 2, Content = "Great"},
                new Comment {Id = 3, Content = "Nice"},
            }.AsQueryable();
        

            var mockDbSet = new Mock<DbSet<Comment>>();

            mockDbSet.As<IQueryable<Comment>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<Comment>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<Comment>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<Comment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Comment).Returns(mockDbSet.Object);

            BusinessLogic = new CommentBusinessLogic(new CommentRepository(mockContext.Object), UserManager);

        }
         
        [DataRow()]
        [TestMethod]
        public void GetAllCommentsByTask_ValidInput_ReturnsListOfCommentsByTicketId()
        {
            // Arrange
            
            // Act
            // Assert
        }

        [DataRow(4)]
        [TestMethod]
        public void CreateComment_ValidInput_CreatesNewCommentAndAddsToComments(int assertedCount)
        {
            // Arrange
            var actualComment = new Comment();

            // Act
            BusinessLogic.CreateComment(actualComment);
            int actualCommentCount = BusinessLogic.GetAllCommentsByTask(1).Count();
            // Assert
            Assert.AreEqual(assertedCount, actualCommentCount);

        }
    }
}
