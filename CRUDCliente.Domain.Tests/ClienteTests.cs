using CRUDCliente.Domain.Validation;
using FluentAssertions;
using CRUDCliente.Domain.Entidades;

namespace CRUDCliente.Domain.Tests;

public class ClienteTests
{
    [Fact(DisplayName = "Criar Cliente Valido")]
    public void CreateCliente_WhitValidParam_ResultObjetcValidState()
    {
        Action action = () => new Cliente(1, "Maria", "09426168425", "994325987");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Criar Cliente com id negativo")]
    public void CreateCliente_NegativeIdValue_DomainExeceptionInvalidId()
    {
        Action action = () => new Cliente(-1, "Maria", "09426168425", "994325987");
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Criar Cliente com cpf invalido")]
    public void CreateProduct_InvalidCpf_DomainExceptionInvalidCpf()
    {
        Action action = () => new Cliente(1, "Maria", "09426168425987", "994325987");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid cpf, required 11 characters");
    }

    [Fact(DisplayName = "Criar Cliente com telefone invalido")]
    public void CreateProduct_InvaliTelefone_DomainExceptionInvalidTelefone()
    {
        Action action = () => new Cliente(1, "Maria", "09426168425", "99432971235987");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid telefone,required 9 characters");
    }

    [Fact(DisplayName = "Criar Cliente com nome nulo")]
    public void CreateCliente_NullName_DomainExceptionNullName()
    {
        Action action = () => new Cliente(1, null, "09426168425", "994325987");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Criar Cliente com CPF nulo")]
    public void CreateCliente_NullCpf_DomainExceptionNullCpf()
    {
        Action action = () => new Cliente(1, "Maria", null, "994325987");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid cpf. CPF is required");
    }

    [Fact(DisplayName = "Criar Cliente com telefone nulo")]
    public void CreateCliente_NullTelefone_DomainExceptionNullTelefone()
    {
        Action action = () => new Cliente(1, "Maria", "09426168425", null);
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid telefone. Telefone is required");
    }

}