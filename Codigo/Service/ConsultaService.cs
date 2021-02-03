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


		//Consulta Obter(int IdConsulta);
		//IEnumerable<Consulta> ObterPorDescricao(string descricao);



		/// <summary>
		/// Insere uma nova consulta no base de dados
		/// </summary>
		/// <param name="autor">dados do autor</param>
		/// <returns></returns>
		public int Inserir(Consulta consulta)
		{
			_context.Add(consulta);
			_context.SaveChanges();
			return consulta.IdConsulta;
		}

		/// <summary>
		/// Atualiza os dados do autor na base de dados
		/// </summary>
		/// <param name="autor">dados do autor</param>
		public void Editar(Consulta consulta)
		{

			_context.Update(consulta);
			_context.SaveChanges();
		}

		/// <summary>
		/// Remove um autor da base de dados
		/// </summary>
		/// <param name="idAutor">identificado do autor</param>
		public void Remover(int IdConsulta)
		{
			var _consulta = _context.Consulta.Find(IdConsulta);
			_context.Consulta.Remove(_consulta);
			_context.SaveChanges();
		}
		public Consulta Obter(int idConsulta)
		{
			IEnumerable<Consulta> consultas = GetQuery().Where(consultaModel => consultaModel.IdConsulta.Equals(idConsulta));

			return consultas.ElementAtOrDefault(0);
		}
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
		public int GetNumeroConsultas()
		{
			return _context.Consulta.Count();
		}


		/// <summary>
		/// Obtém autores que iniciam com o nome
		/// </summary>
		/// <param name="nome">nome a ser buscado</param>
		/// <returns></returns>
		public IEnumerable<Consulta> ObterPorDescricao(string descricao)
		{
			IEnumerable<Consulta> consultas = GetQuery()
				.Where(animalModel => animalModel.Descricao.
				StartsWith(descricao));
			return consultas;
		}

		

		public IEnumerable<ConsultaDTO> ObterTodasConsultas()
        {
			IQueryable<Consulta> consultas = _context.Consulta;
			var query = from consulta in consultas
						select new ConsultaDTO
						{
							Descricao = consulta.Descricao,
							Horario = consulta.Horario,
							Data = consulta.Data,
							Preco = consulta.Preco,
							IdAnimal = consulta.IdAnimal

						};
			return query;
		}
    }
}
