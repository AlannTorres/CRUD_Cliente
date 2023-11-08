using CRUDCliente.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace CRUDCliente.Application.Tests;

public class ClienteDTOTests
{
    [Fact(DisplayName = "Declaração sem o atributo nome")]
    public void Nome_RequiredValidation_Success()
    {
        // Arranjo
        var cliente = new ClienteDTO();

        // Ação
        var resultadosDeValidacao = ValidateModel(cliente);

        // Afirmação
        var resultadoDeValidacaoNome = resultadosDeValidacao
            .Find(result => result.MemberNames.Contains(nameof(ClienteDTO.Nome)));
        Assert.NotNull(resultadoDeValidacaoNome);
        Assert.Contains("The Nome is Required", resultadoDeValidacaoNome.ErrorMessage);
    }

    [Fact(DisplayName = "Declaração com atributo nome menor que 3 caracteres")]
    public void Nome_MinLengthValidation_Success()
    {
        // Arranjo
        var cliente = new ClienteDTO
        {
            Nome = "A"
        };

        // Ação
        var resultadosDeValidacao = ValidateModel(cliente);

        // Afirmação
        var resultadoDeValidacaoNome = resultadosDeValidacao
            .Find(result => result.MemberNames.Contains(nameof(ClienteDTO.Nome)));
        Assert.NotNull(resultadoDeValidacaoNome);
        Assert.Contains("The field Nome must be a string or array type with a minimum length of '3'.", resultadoDeValidacaoNome.ErrorMessage);
    }

    [Fact(DisplayName = "Declaração com atributo nome maior que 100 caracteres")]
    public void Nome_MaxLengthValidation_Success()
    {
        var cliente = new ClienteDTO
        {
            Nome = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec id est tristique, semper augue quis, lobortis leo. Aliquam sed viverra nisl, quis accumsan erat. Curabitur posuere ligula vitae sapien euismod, sed mattis dui feugiat. Etiam et placerat sapien. In vitae ligula pretium, mattis augue in, interdum augue."
        };

        var resultadosDeValidacao = ValidateModel(cliente);

        var resultadoDeValidacaoNome = resultadosDeValidacao
            .Find(result => result.MemberNames.Contains(nameof(ClienteDTO.Nome)));
        Assert.NotNull(resultadoDeValidacaoNome);
        Assert.Contains("The field Nome must be a string or array type with a maximum length of '100'.", resultadoDeValidacaoNome.ErrorMessage);
    }

    [Fact(DisplayName = "Declaração sem o atributo cpf")]
    public void Cpf_RequiredValidation_Success()
    {
        // Arranjo
        var cliente = new ClienteDTO();

        // Ação
        var resultadosDeValidacao = ValidateModel(cliente);

        // Afirmação
        var resultadoDeValidacaoCpf = resultadosDeValidacao
            .Find(result => result.MemberNames.Contains(nameof(ClienteDTO.Cpf)));
        Assert.NotNull(resultadoDeValidacaoCpf);
        Assert.Contains("The Cpf is Required", resultadoDeValidacaoCpf.ErrorMessage);
    }

    [Fact(DisplayName = "Declaração com atributo cpf menor que 11 caracteres")]
    public void Cpf_MinLengthValidation_Success()
    {
        // Arranjo
        var cliente = new ClienteDTO
        {
            Cpf = "5421"
        };

        // Ação
        var resultadosDeValidacao = ValidateModel(cliente);

        // Afirmação
        var resultadoDeValidacaoCpf = resultadosDeValidacao
            .Find(result => result.MemberNames.Contains(nameof(ClienteDTO.Cpf)));
        Assert.NotNull(resultadoDeValidacaoCpf);
        Assert.Contains("The field Cpf must be a string or array type with a minimum length of '11'.", resultadoDeValidacaoCpf.ErrorMessage);
    }

    [Fact(DisplayName = "Declaração com atributo nome maior que 11 caracteres")]
    public void Cpf_MaxLengthValidation_Success()
    {
        var cliente = new ClienteDTO
        {
            Cpf = "054221635558566654454336"
        };

        var resultadosDeValidacao = ValidateModel(cliente);

        var resultadoDeValidacaoCpf = resultadosDeValidacao
            .Find(result => result.MemberNames.Contains(nameof(ClienteDTO.Cpf)));
        Assert.NotNull(resultadoDeValidacaoCpf);
        Assert.Contains("The field Cpf must be a string or array type with a maximum length of '11'.", resultadoDeValidacaoCpf.ErrorMessage);
    }

    [Fact(DisplayName = "Declaração sem o atributo telefone")]
    public void Telefone_RequiredValidation_Success()
    {
        // Arranjo
        var cliente = new ClienteDTO();

        // Ação
        var resultadosDeValidacao = ValidateModel(cliente);

        // Afirmação
        var resultadoDeValidacaoTelefone = resultadosDeValidacao
            .Find(result => result.MemberNames.Contains(nameof(ClienteDTO.Telefone)));
        Assert.NotNull(resultadoDeValidacaoTelefone);
        Assert.Contains("The Telefone is Required", resultadoDeValidacaoTelefone.ErrorMessage);
    }

    [Fact(DisplayName = "Declaração com atributo telefone menor que 9 caracteres")]
    public void Telefone_MinLengthValidation_Success()
    {
        // Arranjo
        var cliente = new ClienteDTO
        {
            Telefone = "5421"
        };

        // Ação
        var resultadosDeValidacao = ValidateModel(cliente);

        // Afirmação
        var resultadoDeValidacaoTelefone = resultadosDeValidacao
            .Find(result => result.MemberNames.Contains(nameof(ClienteDTO.Telefone)));
        Assert.NotNull(resultadoDeValidacaoTelefone);
        Assert.Contains("The field Telefone must be a string or array type with a minimum length of '9'.", resultadoDeValidacaoTelefone.ErrorMessage);
    }

    private List<ValidationResult> ValidateModel(object model)
    {
        var contexto = new ValidationContext(model, null, null);
        var resultados = new List<ValidationResult>();
        Validator.TryValidateObject(model, contexto, resultados, true);
        return resultados;
    }
}
