using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Tests
{
    [TestClass()]
    public class PessoaServiceTests
    {
		private GestaoAnimalContext _context;
		//GestaoAnimalContext
		private IPessoaService _pessoaService;

		[TestInitialize]
		public void Initialize()
		{
			//Arrange
			var builder = new DbContextOptionsBuilder<GestaoAnimalContext>();
			builder.UseInMemoryDatabase("Gestao Animal");
			var options = builder.Options;

			_context = new GestaoAnimalContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var pessoas = new List<Pessoa>
				{
					new Pessoa { IdPessoa = 1, Nome = "Joana", DataNascimento = DateTime.Parse("1992-06-06")},
					new Pessoa { IdPessoa = 2, Nome = "Lys", DataNascimento = DateTime.Parse("2018-06-06")},
					new Pessoa { IdPessoa = 3, Nome = "Marcos Dosea", DataNascimento = DateTime.Parse("1952-03-03")},
				};

			_context.AddRange(pessoas);
			_context.SaveChanges();

			_pessoaService = new PessoaService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_pessoaService.Inserir(new Pessoa() { IdPessoa = 4, Nome = "Carlos", DataNascimento = DateTime.Parse("1975-12-25") });
			// Assert
			Assert.AreEqual(4, _pessoaService.ObterTodos().Count());
			var pessoa = _pessoaService.Obter(4);
			Assert.AreEqual("Carlos", pessoa.Nome);
			Assert.AreEqual(DateTime.Parse("1975-12-25"), pessoa.DataNascimento);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var pessoa = _pessoaService.Obter(3);
			pessoa.Nome = "Marcos Dosea";
			pessoa.DataNascimento = DateTime.Parse("1952-03-03");
			_pessoaService.Editar(pessoa);
			pessoa = _pessoaService.Obter(3);
			Assert.AreEqual("Marcos Dosea", pessoa.Nome);
			Assert.AreEqual(DateTime.Parse("1952-03-03"), pessoa.DataNascimento);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_pessoaService.Remover(2);
			// Assert
			Assert.AreEqual(2, _pessoaService.ObterTodos().Count());
			var pessoa = _pessoaService.Obter(2);
			Assert.AreEqual(null, pessoa);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaPessoa = _pessoaService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaPessoa, typeof(IEnumerable<Pessoa>));
			Assert.IsNotNull(listaPessoa);
			Assert.AreEqual(3, listaPessoa.Count());
			Assert.AreEqual(1, listaPessoa.First().IdPessoa);
			Assert.AreEqual("Joana", listaPessoa.First().Nome);
		}

		[TestMethod()]
		/*public void ObterTodosOrdenadoPorNomeTest()
		{
			var listaPessoa = _pessoaService.ObterTodosOrdenadoPorNome();
			Assert.IsInstanceOfType(listaPessoa, typeof(IEnumerable<Pessoa>));
			Assert.IsNotNull(listaPessoa);
			Assert.AreNotEqual(0, listaPessoa.Count());
			Assert.AreEqual(3, listaPessoa.First().IdPessoa);
			Assert.AreEqual("Gleford Myers", listaPessoa.First().Nome);
		}*/

		
		public void ObterTest()
		{
			var pessoa = _pessoaService.Obter(1);
			Assert.IsNotNull(pessoa);
			Assert.AreEqual("Joana", pessoa.Nome);
		}

		
		/*public void ObterPorNomeTest()
		{
			var pessoaes = _pessoaService.ObterPorNome("Machado");
			Assert.IsNotNull(pessoaes);
			Assert.AreEqual(1, pessoaes.Count());
			Assert.AreEqual("Machado de Assis", pessoaes.First().Nome);
		}

		[TestMethod()]
		public void ObterPorNomeContendoTest()
		{
			var pessoaes = _pessoaService.ObterPorNomeContendo("Sommervile");
			Assert.IsNotNull(pessoaes);
			Assert.AreEqual(1, pessoaes.Count());
			Assert.AreEqual("Ian S. Sommervile", pessoaes.First().Nome);
		}*/

		[TestMethod()]
		public void ObterPorNomeOrdenadoDescendingTest()
		{
			var pessoaes = _pessoaService.ObterPorNomeOrdenadoDescending("Ma");
			Assert.IsNotNull(pessoaes);
			Assert.AreEqual(3, pessoaes.Count());
			Assert.AreEqual("Marcos Dosea", pessoaes.First().Nome);
		}
	}
}
