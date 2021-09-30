using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGba.Domain.Dtos
{
    public class FuncionDto
    {
        public int PeliculaId { get; set; }
        public int SalaId { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set;}
    }
}
