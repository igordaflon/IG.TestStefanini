using AutoMapper;
using IG.TestStefanini.Api.ViewModels;
using IG.TestStefanini.Business.Models;

namespace IG.TestStefanini.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
            CreateMap<Cidade, CidadeViewModel>().ReverseMap();
        }
    }
}
