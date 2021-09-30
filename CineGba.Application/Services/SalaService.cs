using CineGba.Domain.Commands;
using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGba.Application.Services
{
    public interface ISalaService
    {
        List<Sala> GetAllSalas();
        Sala GetSalaById(int id);
    }

    public class SalaService : ISalaService
    {
        IGenericRepository _repository;

        public SalaService(IGenericRepository repository)
        {
            _repository = repository;
        }
        public List<Sala> GetAllSalas()
        {
            throw new NotImplementedException();
        }

        public Sala GetSalaById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
