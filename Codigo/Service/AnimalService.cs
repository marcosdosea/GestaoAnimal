using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Service
{
    public class AnimalService: IAnimalService
    {
		private readonly GestaoAnimalContext _context;

		public AnimalService(GestaoAnimalContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Insere um novo autor no base de dados
		/// </summary>
		/// <param name="autor">dados do autor</param>
		/// <returns></returns>
		public int Inserir(Animal animal)
		{
			_context.Add(animal);
			_context.SaveChanges();
			return animal.IdAnimal;
		}

		/// <summary>
		/// Atualiza os dados do autor na base de dados
		/// </summary>
		/// <param name="autor">dados do autor</param>
		public void Editar(Animal animal)
		{
			

			_context.Update(animal);
			_context.SaveChanges();
		}

		/// <summary>
		/// Remove um autor da base de dados
		/// </summary>
		/// <param name="idAutor">identificado do autor</param>
		public void Remover(int IdAnimal)
		{
			var _animal = _context.Animal.Find(IdAnimal);
			_context.Animal.Remove(_animal);
			_context.SaveChanges();
		}

		/// <summary>
		/// Consulta genérica aos dados do autor
		/// </summary>
		/// <returns></returns>
		private IQueryable<Animal> GetQuery()
		{
			IQueryable<Animal> Animal = _context.Animal;
			var query = from animal in Animal
						select animal;
			return query;
		}

		/// <summary>
		/// Obtém todos os autores
		/// </summary>
		/// <returns></returns>
		public IEnumerable<AnimalDTO> ObterTodosAnimais()
		{
			IQueryable<Animal> animais = _context.Animal;
			var query = from animal in animais
						select new AnimalDTO
						{
							IdAnimal = animal.IdAnimal,
							Nome = animal.Nome,
							Raca = animal.Raca,
							Sexo = animal.Sexo,
							EspecieAnimal = animal.IdEspecieAnimalNavigation.Nome,
							Organizacao = animal.IdOrganizacaoNavigation.Nome,
							Pessoa = animal.IdPessoaNavigation.Nome,
							Peso = animal.Peso,
							DataNascimento = animal.DataNascimento
						};
			return query;
		}
		public IEnumerable<Animal> ObterTodos()
		{
			return GetQuery();
		}
		/// <summary>
		/// REtorna o número de autores cadastrados
		/// </summary>
		/// <returns></returns>
		public int GetNumeroAnimais()
		{
			return _context.Animal.Count();
		}

		/// <summary>
		/// Obtém os dados do primeiro autor cadastrado na base de dados.
		/// </summary>
		/// <returns></returns>
		public Animal ObterPrimeiroAnimal()
		{
			Animal _animal = _context.Animal.FirstOrDefault();
			Animal autor = new Animal();
			if (_animal != null)
			{
				autor.IdAnimal = _animal.IdAnimal;
				autor.Nome = _animal.Nome;
			}
			return autor;
		}


		/// <summary>
		/// Obtém pelo identificado do autor
		/// </summary>
		/// <param name="idAutor"></param>
		/// <returns></returns>
		public Animal Obter(int IdAnimal)
		{
			IEnumerable<Animal> animais = GetQuery().Where(autorModel => autorModel.IdAnimal.Equals(IdAnimal));

			return animais.ElementAtOrDefault(0);
		}

		/// <summary>
		/// Obtém autores que iniciam com o nome
		/// </summary>
		/// <param name="nome">nome a ser buscado</param>
		/// <returns></returns>
		public IEnumerable<Animal> ObterPorNome(string nome)
		{
			IEnumerable<Animal> animais = GetQuery()
				.Where(animalModel => animalModel.Nome.
				StartsWith(nome));
			return animais;
		}

		

		/// <summary>
		/// Obtém autores ordenado de forma descendente
		/// </summary>
		/// <param name="nome"></param>
		/// <returns></returns>
		public IEnumerable<AnimalDTO> ObterPorNomeOrdenadoDescending(string nome)
		{
			IQueryable<Animal> animal = _context.Animal;
			var query = from animal2 in animal
						where nome.StartsWith(nome)
						orderby animal2.Nome descending
						select new AnimalDTO
						{
							Nome = animal2.Nome
						};
			return query;
		}

        public IEnumerable<AnimalDTO> ObterTodosPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
