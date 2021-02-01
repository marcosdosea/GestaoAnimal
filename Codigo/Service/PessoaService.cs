using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    class PessoaService : IPessoaService
    {
        private readonly GestaoAnimalContext _context;

        public PessoaService(GestaoAnimalContext context)
        {
            _context = context;
        }
        public void Editar(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();
        }

        public int Inserir(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
            return pessoa.IdPessoa;
        }

        private IQueryable<Pessoa> GetQuery()
        {
            IQueryable<Pessoa> Pessoa = _context.Pessoa;
            var query = from pessoa in Pessoa
                        select pessoa;
            return query;
        }

        public Pessoa Obter(int idPessoa)
        {
            IEnumerable<Pessoa> pessoa = GetQuery().Where(autorModel => autorModel.IdPessoa.Equals(idPessoa));

            return pessoa.ElementAtOrDefault(0);
        }

        public IEnumerable<PessoaDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Pessoa> pessoa = _context.Pessoa;
            var query = from pessoa2 in pessoa
                        where nome.StartsWith(nome)
                        orderby pessoa2.Nome descending
                        select new PessoaDTO
                        {
                            Nome = pessoa2.Nome
                        };
            return query;
        }

        public IEnumerable<Pessoa> ObterTodos()
        {
            return GetQuery();
        }

        public IEnumerable<PessoaDTO> ObterTodosPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Remover(int idPessoa)
        {
            var _pessoa = _context.Pessoa.Find(idPessoa);
            _context.Pessoa.Remove(_pessoa);
            _context.SaveChanges();
        }

        public int GetNumeroPessoa()
        {
            return _context.Pessoa.Count();
        }
    }
}
