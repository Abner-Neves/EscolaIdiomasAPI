using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Escola.Domain.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Email { get; set; }

        [ForeignKey("Turma")]
        [AllowNull]
        public int? TurmaId { get; set; }
        public Turma? Turma { get; set; }
    }
}
