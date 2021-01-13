using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Service
{
    public class AplicaMedicamentoService : IAplicaMedicamentoService
    {
        private readonly GestaoAnimalContext _context;

        public AplicaMedicamentoService(GestaoAnimalContext context)
        {
            _context = context;
        }

        public void Editar(Aplicamedicamento aplicaMedicamento)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Aplicamedicamento aplicamedicamento)
        {
            _context.Add(aplicamedicamento);
            _context.SaveChanges();
            return aplicamedicamento.IdAplicaMedicamento;
        }

        public Aplicamedicamento Obter(int idAplicacao)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AplicamedicamentoDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aplicamedicamento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AplicamedicamentoDTO> ObterTodosPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Remover(int idAplicacao)
        {
            throw new NotImplementedException();
        }
    }
}
