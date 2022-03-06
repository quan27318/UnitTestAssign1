using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MVCAssign.Controllers;
using MVCAssign.Models;
using MVCAssign.Service;
using NUnit.Framework;

namespace UnitTest;

public class Tests
{
    private Mock<ILogger<PeopleController>> _loggerMock;
    private Mock<IPeople> _peopleMock;
    static List<PersonModel> _people = new List<PersonModel>(){
        new PersonModel{
                Id = 1,
                FirstName = "Pham",
                LastName = "Quan",
                Address = "Thai Binh",
                Gender = "Male"
            },

            new PersonModel{
                Id = 2,
                FirstName = "Nguyen",
                LastName  = "Binh",
                Address = "Ha Noi",
                Gender = "Male"
            },

            new PersonModel{
                Id = 3,
                FirstName = "Tran",
                LastName = "Nam",
                Address = "Hai Phong",
                Gender = "Male"
            }
    };
    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<PeopleController>>();
        _peopleMock = new Mock<IPeople>();
        //SetUP
        _peopleMock.Setup(x => x.GetAll()).Returns(_people);
    }

    [Test]
    public void Test1()
    {
        
        //Arrage
        var controller = new PeopleController(_loggerMock.Object, _peopleMock.Object);

        //Act
        var result = controller.Index();

        //Assert
        Assert.IsInstanceOf<ViewResult>(result, "Test");
    }
}