using AutoMapper;
using CRUDCliente.Application.DTOs;
using CRUDCliente.Domain.Entidades;

namespace CRUDCliente.Application.Mapping;

public class DomainToDTOMapping : Profile
{
    public DomainToDTOMapping()
    {
        CreateMap<Cliente, ClienteDTO>().ReverseMap();   
    }
}
