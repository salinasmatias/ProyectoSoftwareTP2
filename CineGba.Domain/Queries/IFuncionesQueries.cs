using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGba.Domain.Queries
{
    public interface IFuncionesQueries
    {
        int GetTicketsDisponiblesByFuncion(int funcionId);
    }
}
