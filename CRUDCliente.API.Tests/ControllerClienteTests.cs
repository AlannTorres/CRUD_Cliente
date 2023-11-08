using Microsoft.AspNetCore.Mvc;
using CRUDCliente.API.Controller;
using CRUDCliente.Application.Interfaces;
using Moq;

namespace CRUDCliente.API.Tests;

public class ControllerClienteTests
{
    [Fact(DisplayName = "Buscar Lista de Clientes")]
    public async Task GetClientes_ReturnsListOfClientes()
    {
        // Arrange
        var clienteServiceMock = new Mock<IClienteService>();
        var controller = new ClienteController(clienteServiceMock.Object);

        var expectedClientes = new List<ClienteDTO>();
        expectedClientes.Add(new ClienteDTO {
            Id = 1,
            Nome = "Alan",
            Cpf = "022230589128",
            Telefone = "8999355087"
        });
        expectedClientes.Add(new ClienteDTO
        {
            Id = 3,
            Nome = "Maria",
            Cpf = "022230589128",
            Telefone = "8999355087"
        });

        clienteServiceMock.Setup(service 
            => service.GetClientes()).ReturnsAsync(expectedClientes);

        // Act
        var result = await controller.GetClientes();

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<ClienteDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var model = Assert.IsAssignableFrom<IEnumerable<ClienteDTO>>(okResult.Value);
        Assert.Same(expectedClientes, model);
    }

    [Fact(DisplayName = "Buscar Cliente com id valido")]
    public async Task GetClienteById_WithValidId_ReturnsCliente()
    {
        // Arrange
        var clienteServiceMock = new Mock<IClienteService>();
        var controller = new ClienteController(clienteServiceMock.Object);

        var expectedCliente = new ClienteDTO()
        {
            Id = 1,
            Nome = "Alan",
            Cpf = "022230589128",
            Telefone = "8999355087"
        }; 
        clienteServiceMock.Setup(service 
            => service.GetClienteById(It.IsAny<int>())).ReturnsAsync(expectedCliente);

        // Act
        var result = await controller.GetClienteById(1);

        // Assert
        var actionResult = Assert.IsType<ActionResult<ClienteDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var model = Assert.IsType<ClienteDTO>(okResult.Value);
        Assert.Same(expectedCliente, model);
    }

    [Fact(DisplayName = "Buscar Cliente com id não existente")]
    public async Task GetClienteById_WithInvalidId_ReturnsNotFound()
    {
        // Arrange
        var clienteServiceMock = new Mock<IClienteService>();
        var controller = new ClienteController(clienteServiceMock.Object);

        clienteServiceMock.Setup(service 
            => service.GetClienteById(It.IsAny<int>())).ReturnsAsync((ClienteDTO)null);

        // Act
        var result = await controller.GetClienteById(1);

        // Assert
        var actionResult = Assert.IsType<ActionResult<ClienteDTO>>(result);
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        Assert.Equal("Cliente não encontrado", notFoundResult.Value);
    }

    [Fact(DisplayName = "Criar Cliente Válido")]
    public async Task CreateCliente_WithValidData_ReturnsOkResult()
    {
        // Arrange
        var clienteServiceMock = new Mock<IClienteService>();
        var controller = new ClienteController(clienteServiceMock.Object);

        var clienteDTO = new ClienteDTO
        {
            Nome = "João",
            Cpf = "12345678901",
            Telefone = "9999999999"
        };

        // Act
        var result = await controller.CreateCliente(clienteDTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsType<ClienteDTO>(okResult.Value);
        Assert.Equal(clienteDTO.Nome, model.Nome);
        Assert.Equal(clienteDTO.Cpf, model.Cpf);
        Assert.Equal(clienteDTO.Telefone, model.Telefone);
    }

    [Fact(DisplayName = "Atualizar Cliente Válido")]
    public async Task UpdateCliente_WithValidData_ReturnsOkResult()
    {
        // Arrange
        var clienteServiceMock = new Mock<IClienteService>();
        var controller = new ClienteController(clienteServiceMock.Object);

        var clienteDTO = new ClienteDTO
        {
            Id = 1, // ID válido de um cliente existente
            Nome = "Novo Nome",
            Cpf = "12345678901",
            Telefone = "9999999999"
        };

        // Act
        var result = await controller.EditCliente(1, clienteDTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsType<ClienteDTO>(okResult.Value);
        Assert.Equal(clienteDTO.Nome, model.Nome);
        Assert.Equal(clienteDTO.Cpf, model.Cpf);
        Assert.Equal(clienteDTO.Telefone, model.Telefone);
    }
}