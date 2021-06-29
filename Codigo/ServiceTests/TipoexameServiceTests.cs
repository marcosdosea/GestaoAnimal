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
    public class TipoexameServiceTests
    {
		private GestaoAnimalContext _context;
		//GestaoAnimalContext
		private ITipoexameService _tipoexameService;

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
			var tipoexames = new List<Tipoexame>
				{
					new Tipoexame{IdTipoExame = 1, Tipo = "Glicemia"},
					new Tipoexame{IdTipoExame = 2, Tipo = "Colesterol"},
					new Tipoexame{IdTipoExame = 3, Tipo = "Raio-X"}
				};

			_context.AddRange(tipoexames);
			_context.SaveChanges();

			_tipoexameService = new TipoexameService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_tipoexameService.Inserir(new Tipoexame() { IdTipoExame = 4, Tipo = "Vitamina D"});
			// Assert
			Assert.AreEqual(4, _tipoexameService.ObterTodos().Count());
			var tipoexame = _tipoexameService.Obter(4);
			Assert.AreEqual("Vitamina D", tipoexame.Tipo);
			//Assert.AreEqual(DateTime.Parse("1975-12-25"), tipoexame.DataNascimento);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var tipoexame = _tipoexameService.Obter(3);
			tipoexame.Tipo = "Raio-X";
			_tipoexameService.Editar(tipoexame);
			tipoexame = _tipoexameService.Obter(3);
			Assert.AreEqual("Raio-X", tipoexame.Tipo);
			
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_tipoexameService.Remover(2);
			// Assert
			Assert.AreEqual(2, _tipoexameService.ObterTodos().Count());
			var tipoexame = _tipoexameService.Obter(2);
			Assert.AreEqual(null, tipoexame);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaTipoexame = _tipoexameService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaTipoexame, typeof(IEnumerable<Tipoexame>));
			Assert.IsNotNull(listaTipoexame);
			Assert.AreEqual(3, listaTipoexame.Count());
			Assert.AreEqual(1, listaTipoexame.First().IdTipoExame);
			Assert.AreEqual("Glicemia", listaTipoexame.First().Tipo);
		}

		[TestMethod()]
		/*public void ObterTodosOrdenadoPorTipoTest()
		{
			var listaTipoexame = _tipoexameService.ObterTodosOrdenadoPorTipo();
			Assert.IsInstanceOfType(listaTipoexame, typeof(IEnumerable<Tipoexame>));
			Assert.IsNotNull(listaTipoexame);
			Assert.AreNotEqual(0, listaTipoexame.Count());
			Assert.AreEqual(3, listaTipoexame.First().IdTipoexame);
			Assert.AreEqual("Gleford Myers", listaTipoexame.First().Tipo);
		}*/


		public void ObterTest()
		{
			var tipoexame = _tipoexameService.Obter(1);
			Assert.IsNotNull(tipoexame);
			Assert.AreEqual("Glicemia", tipoexame.Tipo);
		}


		/*public void ObterPorTipoTest()
		{
			var tipoexamees = _tipoexameService.ObterPorTipo("Machado");
			Assert.IsNotNull(tipoexamees);
			Assert.AreEqual(1, tipoexamees.Count());
			Assert.AreEqual("Machado de Assis", tipoexamees.First().Tipo);
		}

		[TestMethod()]
		public void ObterPorTipoContendoTest()
		{
			var tipoexamees = _tipoexameService.ObterPorTipoContendo("Sommervile");
			Assert.IsNotNull(tipoexamees);
			Assert.AreEqual(1, tipoexamees.Count());
			Assert.AreEqual("Ian S. Sommervile", tipoexamees.First().Tipo);
		}

		[TestMethod()]
		public void ObterPorTipoOrdenadoDescendingTest()
		{
			var tipoexamees = _tipoexameService.ObterPorTipoOrdenadoDescending("Ma");
			Assert.IsNotNull(tipoexamees);
			Assert.AreEqual(3, tipoexamees.Count());
			Assert.AreEqual("Marcos Dosea", tipoexamees.First().Tipo);
		}*/
	}
}