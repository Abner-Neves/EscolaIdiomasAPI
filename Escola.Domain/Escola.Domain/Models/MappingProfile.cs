using AutoMapper;
using Escola.Domain.DTOs.Aluno;
using Escola.Domain.DTOs.AlunoTurma;
using Escola.Domain.DTOs.Turma;
using Escola.Domain.Interfaces.Applications;
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
            CreateMap<Aluno, UpdateAlunoDto>().ReverseMap();

            CreateMap<Turma, GetTurmaDto>().ReverseMap();
            CreateMap<Turma, InsertTurmaDto>().ReverseMap();
            CreateMap<Turma, UpdateTurmaDto>().ReverseMap();

            CreateMap<AlunoTurma, InsertAlunoTurmaDto>().ReverseMap();
        }
    }
}
