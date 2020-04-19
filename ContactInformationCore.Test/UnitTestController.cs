using ContactInformationCore.Model;
using ContactInformationCore.WebAPI;
using ContactInformationCore.WebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ContactInformationCore.Test
{
    public class UnitTestController
    {
        private ContactService repository;
        public static DbContextOptions<DatabaseContaxt> DbContextOptions { get; }
        public static string connectionString = "Server=.;Database=ContactDB;Integrated Security=True";

        static UnitTestController()
        {
            DbContextOptions = new DbContextOptionsBuilder<DatabaseContaxt>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public UnitTestController()
        {
            var context = new DatabaseContaxt(DbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.SeedData(context);

            repository = new ContactService(context);

        }


        //Started Test cases

        #region Get By Id

        [Fact]
        public void Task_GetById_Return_OkResult()
        {
            //Arrange
            var controller = new ContactsController(repository);
            int Id = 2;

            //Act
            var data = controller.Get(Id);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetById_Return_NotFoundResult()
        {
            //Arrange
            var controller = new ContactsController(repository);
            int Id = 10;

            //Act
            var data = controller.Get(Id);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public void Task_GetById_Return_BadRequestResult()
        {
            //Arrange
            var controller = new ContactsController(repository);
            int? Id = null;

            //Act
            var data = controller.Get(Id);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public void Task_GetById_MatchResult()
        {
            //Arrange
            var controller = new ContactsController(repository);
            int? postId = 1;

            //Act
            var data = controller.Get(postId);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<Contact>().Subject;

            Assert.Equal("Kennie", post.First_Name);
            Assert.Equal("Guilloton", post.Last_Name);
        }

        #endregion

        #region Add New Contact

        [Fact]
        public void Task_Add_ValidData_Return_CreatedAtRouteResult()
        {
            //Arrange
            var controller = new ContactsController(repository);
            
            var contact = new Contact()
            {
                First_Name = "Vishwas",
                Last_Name = "Kapte",
                Email = "vishwasvkapte@outlook.com",
                Phone_Number = "9561153397",
                Status = Model.Status.Activate
            };

            //Act
            var data = controller.Post(contact);

            //Assert
            Assert.IsType<CreatedAtRouteResult>(data);
        }

        [Fact]
        public void Task_Add_InvalidData_Return_BadRequest()
        {
            //Arrange
            var controller = new ContactsController(repository);

            Contact contact = new Contact()
            {
                First_Name = "Vivek",
                Last_Name = "Kapte",
                Email = "vivekkapte@outlook.com",
                Phone_Number = "8983375690",
                Status = Model.Status.Activate
            };
            
            contact = null;

            //Act            
            var data = controller.Post(contact);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public void Task_Add_ValidData_MatchResult()
        {
            //Arrange
            var controller = new ContactsController(repository);

            var contact = new Contact()
            {
                First_Name = "Vishwas",
                Last_Name = "Kapte",
                Email = "vishwasvkapte@outlook.com",
                Phone_Number = "9561153397",
                Status = Model.Status.Activate
            };

            //Act
            var data = controller.Post(contact);

            //Assert
            Assert.IsType<CreatedAtRouteResult>(data);

            var okResult = data.Should().BeOfType<CreatedAtRouteResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Contact>().Subject;

            Assert.Equal(4, result.Id);
        }

        #endregion

        #region Update Existing Contact

        [Fact]
        public void Task_Update_ValidData_Return_OkResult()
        {
            //Arrange
            var controller = new ContactsController(repository);
            int Id = 2;

            //Act
            var existingPost = controller.Get(Id);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Contact>().Subject;

            var contact = new Contact();
            contact.First_Name = "Eric";
            contact.Last_Name = result.Last_Name;
            contact.Email = result.Email;
            contact.Phone_Number = result.Phone_Number;
            contact.Status = result.Status;

            var updatedData = controller.Put(Id, contact);

            //Assert
            Assert.IsType<OkResult>(updatedData);
        }

        [Fact]
        public void Task_Update_InvalidData_Return_BadRequest()
        {
            //Arrange
            var controller = new ContactsController(repository);
            int Id = 2;

            //Act
            var existingPost = controller.Get(Id);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Contact>().Subject;

            var contact = new Contact();
            contact.First_Name = "madhav";
            contact.Last_Name = result.Last_Name;
            contact.Email = result.Email;
            contact.Phone_Number = result.Phone_Number;
            contact.Status = result.Status;

            contact = null;

            var data = controller.Put(Id, contact);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public void Task_Update_InvalidData_Return_NotFound()
        {
            //Arrange
            var controller = new ContactsController(repository);
            int Id = 15;

            //Act
            var existingPost = controller.Get(Id);
            var okResult = existingPost.Should().BeOfType<NotFoundResult>().Subject;
           
            //Assert
            Assert.IsType<NotFoundResult>(okResult);
        }

        #endregion

        #region Delete Post

        [Fact]
        public void Task_Delete_Contact_Return_OkResult()
        {
            //Arrange
            var controller = new ContactsController(repository);
            int Id = 2;

            //Act
            var data = controller.Delete(Id);

            //Assert
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public void Task_Delete_Contact_Return_NotFoundResult()
        {
            //Arrange
            var controller = new ContactsController(repository);
            int Id = 5;

            //Act
            var data = controller.Delete(Id);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public void Task_Delete_Return_BadRequestResult()
        {
            //Arrange
            var controller = new ContactsController(repository);
            int? Id = null;

            //Act
            var data = controller.Delete(Id);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        #endregion
    }
}
