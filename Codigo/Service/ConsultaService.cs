using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Service
{
    public class ConsultaService:IConsultaService
    {
		private readonly GestaoAnimalContext _context;
		public ConsultaService(GestaoAnimalContext context)
		{
			_context = context;
		}


		public void Editar(Consulta consulta)
		{

			_context.Update(consulta);
			_context.SaveChanges();
		}

		/// <summary>
		/// Insere um novo autor no base de dados
		/// </summary>
		/// <param name="autor">dados do autor</param>
		/// <returns></returns>
		public int Inserir(Consulta consulta)
		{
			_context.Add(consulta);
			_context.SaveChanges();
			return consulta.IdConsulta;
		}
		public Consulta Obter(int IdConsulta)
		{
			IEnumerable<Consulta> consultas = GetQuery().Where(consultaModel => consultaModel.IdConsulta.Equals(IdConsulta));

			return consultas.ElementAtOrDefault(0);
		}
		/// <summary>
		/// Atualiza os dados do autor na base de dados
		/// </summary>
		/// <param name="autor">dados do autor</param>


		/// <summary>
		/// Remove um autor da base de dados
		/// </summary>
		/// <param name="idAutor">identificado do autor</param>
		
		
		/// <summary>
		/// Consulta genérica aos dados do autor
		/// </summary>
		/// <returns></returns>
		private IQueryable<Consulta> GetQuery()
		{
			IQueryable<Consulta> Consulta = _context.Consulta;
			var query = from consulta in Consulta
						select consulta;
			return query;
		}


		
		

		/// <summary>
		/// Obtém todos os autores
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Consulta> ObterTodos()
		{
			return GetQuery();
		}
		/// <summary>
		/// REtorna o número de autores cadastrados
		/// </summary>
		/// <returns></returns>



		/// <summary>
		/// Obtém autores que iniciam com o nome
		/// </summary>
		/// <param name="nome">nome a ser buscado</param>
		/// <returns></returns>
		
		public IEnumerable<ConsultaDTO> ObterPorDescricao(string descricao)
		{
			IQueryable<Consulta> consulta = _context.Consulta;
			var query = from consulta2 in consulta
						where descricao.StartsWith(descricao)
						orderby consulta2.Descricao descending
						select new ConsultaDTO
						{
							Descricao = consulta2.Descricao
						};
			return query;
		}

      
		public void Remover(int IdConsulta)
		{
			var _consulta = _context.Consulta.Find(IdConsulta);
			_context.Consulta.Remove(_consulta);
			_context.SaveChanges();
		}
	}
}
