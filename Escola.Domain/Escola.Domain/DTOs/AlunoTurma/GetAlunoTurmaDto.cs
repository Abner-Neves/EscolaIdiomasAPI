using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.DTOs.AlunoTurma
{
    public class GetAlunoTurmaDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AlunoID { get; set; }
        [Required]
        public int TurmaId { get; set; }
    }
}
