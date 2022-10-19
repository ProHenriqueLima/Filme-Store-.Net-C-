using TesteWiPro.Api.ViewModels.Cliente;
using TesteWiPro.Api.ViewModels.Filme;
using TesteWiPro.Business.Dto;
using TesteWiPro.Business.Models;

namespace TesteWiPro.Api.Configuration
{
    public class AutomapperConfig : AutoMapper.Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Filme, RequestFilmeVM>()
                .ReverseMap();
            
            CreateMap<ResponseFilmeDto, Filme>()
                .ReverseMap();
            
            CreateMap<ResponseClienteDto, Cliente>()
                .ReverseMap();
            
            CreateMap<Cliente, RequestClienteVM>()
                .ReverseMap();
            
            CreateMap<Aluguel, RequestAluguelVM>()
                .ReverseMap();

        }

    }
}
