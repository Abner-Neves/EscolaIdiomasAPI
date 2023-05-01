using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.DTOs.Turma
{
    public class UpdateTurmaDto
    {
        [Required]
        public int Numero { get; set; }
        [Required]
        public int AnoLetivo { get; set; }
    }
}
