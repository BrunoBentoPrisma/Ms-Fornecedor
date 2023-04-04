using AutoMapper;
using MsFornecedor.Dtos;
using MsFornecedor.Repositorys.Entidades;

namespace MsFornecedor.Profiles
{
    public class FornecedorProfile : Profile
    {
        public FornecedorProfile()
        {
            CreateMap<Fornecedor, FornecedorDto>().ReverseMap();
        }
    }
}
