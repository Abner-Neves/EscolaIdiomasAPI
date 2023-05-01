using AutoMapper;
using Escola.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Aluno, GetAlunoDto>().ReverseMap();
            CreateMap<Aluno, InsertAlunoDto>().ReverseMap();
        }
    }
}
