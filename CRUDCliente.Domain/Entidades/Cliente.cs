using CRUDCliente.Domain.Validation;

namespace CRUDCliente.Domain.Entidades;

public sealed class Cliente
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public string Telefone { get; private set; }

    public Cliente(int id, string nome, string cpf, string telefone)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        Id = id;
        ValidationDomain(nome, cpf, telefone);
    }

    public Cliente(string nome, string cpf, string telefone)
    {
        ValidationDomain(nome, cpf, telefone);
    }

    public void ValidationDomain(string nome, string cpf, string telefone)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Invalid name. Name is required");
        DomainExceptionValidation.When(nome.Length < 3,"Invalid name, too short, minimum 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "Invalid cpf. Cpf is required");
        DomainExceptionValidation.When(cpf.Length != 11, "Invalid cpf, required 11 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "Invalid telefone. Telefone is required");
        DomainExceptionValidation.When(telefone.Length != 9, "Invalid telefone,required 9 characters");

        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
    }
}
