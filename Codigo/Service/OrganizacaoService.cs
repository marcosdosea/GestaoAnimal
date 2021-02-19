using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Service
{
    public class OrganizacaoService: IOrganizacaoService
    {
        private readonly GestaoAnimalContext _context;

        public OrganizacaoService(GestaoAnimalContext context)
        {
            _context = context;
        }
        public void Editar(Organizacao organizacao)
        {
            _context.Update(organizacao);
            _context.SaveChanges();
        }
        public int Inserir(Organizacao organizacao)
        {
            _context.Add(organizacao);
            _context.SaveChanges();
            return organizacao.IdOrganizacao;
        }
        public Organizacao Obter(int idOrganizacao)
        {
            IEnumerable<Organizacao> lotes = GetQuery()
                .Where(loteModel => loteModel.IdOrganizacao.Equals(idOrganizacao));

            return lotes.ElementAtOrDefault(0);
        }
        
        private IQueryable<Organizacao> GetQuery()
        {


            IQueryable<Organizacao> Organizacao = _context.Organizacao;
            var query = from organizacao in Organizacao
                        select organizacao;
            return query;
        }
        public IEnumerable<OrganizacaoDTO> ObterTodos()
        {
            IQueryable<Organizacao> organizacoes = _context.Organizacao;
            var query = from organizacao in organizacoes
                        select new OrganizacaoDTO
                        {
                            IdOrganizacao = organizacao.IdOrganizacao,
                            Cnpj = organizacao.Cnpj,
                            DataAbertura = organizacao.DataAbertura,
                            Nome = organizacao.Nome,
                            Telefone = organizacao.Telefone,
                            Endereco = organizacao.Endereco,
                            Email = organizacao.Email
                        };
            return query;
        }
        public void Remover(int idOrganizacao)
        {
            var _organizacao = _context.Animal.Find(idOrganizacao);
            _context.Animal.Remove(_organizacao);
            _context.SaveChanges();
        }
        public IEnumerable<OrganizacaoDTO> ObterTodosPorNome(string nome)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<OrganizacaoDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
