using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Models
{
    public class AlunoTurma
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Aluno")]
        [Required]
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }

        [ForeignKey("Turma")]
        [Required]
        public int TurmaId { get; set; }
        public Turma? Turma { get; set; }

    }
}
