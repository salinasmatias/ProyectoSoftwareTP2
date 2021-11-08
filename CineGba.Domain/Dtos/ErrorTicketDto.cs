using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGba.Domain.Dtos
{
    public class ErrorTicketDto
    {
        public string Message { get; set; }
        public string Status { get; set; }

        public ErrorTicketDto()
        {
            Message = "Ocurrió un problema. No hay mas tickets para esta función";
            Status = "Error";
        }
    }
}
