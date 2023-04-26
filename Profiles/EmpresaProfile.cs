using AutoMapper;
using Crud.Data.Dtos;
using Crud.Models;

namespace Crud.Profiles;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<CreateEmpresaDto, Empresa>();
        CreateMap<UpdateEmpresaDto, Empresa>();
        CreateMap<Empresa, UpdateEmpresaDto>();
        CreateMap<Empresa, ReadEmpresasDto>();
    }
}
