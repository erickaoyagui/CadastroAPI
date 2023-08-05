using CadastroAPI.Controllers;
using CadastroAPI.Domain.Entities;
using CadastroAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace TestProject
{
    [TestClass]
    public class ClienteControllerTests
    {
        //https://learn.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api
        //Arrange: Set up any prerequisites for the test to run.
        //Act: Perform the test.
        //Assert: Verify that the test succeeded.

        [TestMethod]
        public void GetClientePorId_Ok()
        {
            // Arrange
            Cliente clienteEsperado = new Cliente { Id = 1, Nome = "João", Sobrenome = "Silva", Idade = 30, Pais = "Brasil" };

            Mock<IClienteRepository> repositoryMock = new Mock<IClienteRepository>();
            Mock<ILogger<ClienteController>> loggerMock = new Mock<ILogger<ClienteController>>();
            repositoryMock.Setup(repo => repo.GetById(1)).Returns(clienteEsperado);

            ClienteController controller = new ClienteController(repositoryMock.Object, loggerMock.Object);

            // Act
            var resultado = controller.GetById(1);

            // Assert
            Assert.IsInstanceOfType(resultado, typeof(OkObjectResult));
            var okResult = resultado as OkObjectResult;
            Assert.IsNotNull(okResult);

            var clienteRetornado = okResult.Value as Cliente;
            Assert.IsNotNull(clienteRetornado);
            Assert.AreEqual(clienteEsperado.Id, clienteRetornado.Id);
            Assert.AreEqual(clienteEsperado.Nome, clienteRetornado.Nome);
            Assert.AreEqual(clienteEsperado.Sobrenome, clienteRetornado.Sobrenome);
            Assert.AreEqual(clienteEsperado.Idade, clienteRetornado.Idade);
            Assert.AreEqual(clienteEsperado.Pais, clienteRetornado.Pais);
        }

        [TestMethod]
        public void GetClienteById_NotFound()
        {
            // Arrange
            Mock<IClienteRepository> repositoryMock = new Mock<IClienteRepository>();
            Mock<ILogger<ClienteController>> loggerMock = new Mock<ILogger<ClienteController>>();
            //repositoryMock.Setup(repo => repo.GetById(999)).Returns((Cliente)null);

            ClienteController controller = new ClienteController(repositoryMock.Object, loggerMock.Object);

            // Act
            var resultado = controller.GetById(999);

            // Assert
            Assert.IsInstanceOfType(resultado, typeof(NotFoundResult));

        }

        [TestMethod]
        public void GetClientes_ListaClientes()
        {
            // Arrange
            Mock<IClienteRepository> repositoryMock = new Mock<IClienteRepository>();
            Mock<ILogger<ClienteController>> loggerMock = new Mock<ILogger<ClienteController>>();
            repositoryMock.Setup(repo => repo.GetAll()).Returns(new List<Cliente>
            {
                new Cliente { Id = 1, Nome = "João", Sobrenome = "Silva", Idade = 30, Pais = "Brasil" },
                new Cliente { Id = 2, Nome = "Maria", Sobrenome = "Silva", Idade = 33, Pais = "Argentina" }
            });

            ClienteController controller = new ClienteController(repositoryMock.Object, loggerMock.Object);

            // Act
            var resultado = controller.Get();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(OkObjectResult));
            var okResult = resultado as OkObjectResult;
            
            Assert.IsNotNull(okResult);
            List<Cliente> listaClientes = okResult.Value as List<Cliente>;
            Assert.IsNotNull(listaClientes);
            Assert.AreEqual(2, listaClientes.Count);
        }

        [TestMethod]
        public void PostCliente_CreatedAtAction()
        {
            // Arrange
            Cliente clienteEsperado = new Cliente { Id = 1, Nome = "João", Sobrenome = "Silva", Idade = 30, Pais = "Brasil" };

            Mock<IClienteRepository> repositoryMock = new Mock<IClienteRepository>();
            Mock<ILogger<ClienteController>> loggerMock = new Mock<ILogger<ClienteController>>();

            ClienteController controller = new ClienteController(repositoryMock.Object, loggerMock.Object);

            // Act
            var resultado = controller.Post(clienteEsperado);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(CreatedAtActionResult));
           
            
            var createdAtActionResult = resultado as CreatedAtActionResult;
            Assert.IsNotNull(createdAtActionResult);
            
            var clienteRetornado = createdAtActionResult.Value as Cliente;
            Assert.IsNotNull(clienteRetornado);
            Assert.AreEqual(clienteEsperado.Id, clienteRetornado.Id);
            Assert.AreEqual(clienteEsperado.Nome, clienteRetornado.Nome);
            Assert.AreEqual(clienteEsperado.Sobrenome, clienteRetornado.Sobrenome);
            Assert.AreEqual(clienteEsperado.Idade, clienteRetornado.Idade);
            Assert.AreEqual(clienteEsperado.Pais, clienteRetornado.Pais);
        }

        [TestMethod]
        public void PatchCliente_NoContent()
        {
            // Arrange
            Cliente clienteEsperado = new Cliente { Id = 1, Nome = "João", Sobrenome = "Silva", Idade = 30, Pais = "Brasil" };

            Mock<IClienteRepository> repositoryMock = new Mock<IClienteRepository>();
            Mock<ILogger<ClienteController>> loggerMock = new Mock<ILogger<ClienteController>>();

            ClienteController controller = new ClienteController(repositoryMock.Object, loggerMock.Object);

            // Act
            var resultado = controller.Patch(clienteEsperado);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(NoContentResult));
        }

        [TestMethod]
        public void DeleteCliente_NoContent()
        {
            // Arrange
            Cliente clienteEsperado = new Cliente { Id = 1, Nome = "João", Sobrenome = "Silva", Idade = 30, Pais = "Brasil" };
            Mock<IClienteRepository> repositoryMock = new Mock<IClienteRepository>();
            Mock<ILogger<ClienteController>> loggerMock = new Mock<ILogger<ClienteController>>();
            repositoryMock.Setup(repo => repo.GetById(1)).Returns(clienteEsperado);

            ClienteController controller = new ClienteController(repositoryMock.Object, loggerMock.Object);

            // Act
            var resultado = controller.Delete(1);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(NoContentResult));
        }

        [TestMethod]
        public void DeleteCliente_NotFound()
        {
            // Arrange
            Cliente clienteEsperado = new Cliente { Id = 1, Nome = "João", Sobrenome = "Silva", Idade = 30, Pais = "Brasil" };
            Mock<IClienteRepository> repositoryMock = new Mock<IClienteRepository>();
            Mock<ILogger<ClienteController>> loggerMock = new Mock<ILogger<ClienteController>>();
            repositoryMock.Setup(repo => repo.GetById(1)).Returns(clienteEsperado);

            ClienteController controller = new ClienteController(repositoryMock.Object, loggerMock.Object);

            // Act
            var resultado = controller.Delete(999);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsInstanceOfType(resultado, typeof(NotFoundResult));
        }


        // TODO: Get, GetById, Post, Patch, Delete (Chamadas)
        // TODO: Ok, NotFound, CreatedAtAction(Post), NoContent(Patch e Delete)  (IActionResult)
        // TODO: GetOk, GetByIdOk, GetByIdNotFound, PostCreatedAtAction, PatchNoContent, DeleteNoContent, DeleteNotFound
    }
}