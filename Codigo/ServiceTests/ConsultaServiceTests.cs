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
    public class ConsultaServiceTests
    {
		private GestaoAnimalContext _context;
		//GestaoAnimalContext
		private IConsultaService _consultaService;

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
			var consultas = new List<Consulta>
			{
				new Consulta
				{
					IdConsulta = 1,
					Descricao = "Consulta de Rotina",
					Data = DateTime.Parse("2021-05-10"),
					Preco = 150,
					IdAnimal = 1,
					IdPessoa = 1
				},
				new Consulta
				{
					IdConsulta = 2,
					Descricao = "Exames",
					Data = DateTime.Parse("2021-07-11"),
					Preco = 256,
					IdAnimal = 1,
					IdPessoa = 1
				},
				new Consulta
				{
					IdConsulta = 3,
					Descricao = "Verificação da Pata",
					Data = DateTime.Parse("2021-02-11"),
					Preco = 50,
					IdAnimal = 1,
					IdPessoa = 1
				}
			};

			_context.AddRange(consultas);
			_context.SaveChanges();

			_consultaService = new ConsultaService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_consultaService.Inserir(
				new Consulta() {
					IdConsulta = 4,
					Descricao = "Retorno",
					Data = DateTime.Parse("2022-05-10"),
					Preco = 100,
					IdAnimal = 1,
					IdPessoa = 1
				}
			);
			// Assert
			Assert.AreEqual(4, _consultaService.ObterTodos().Count());
			var consulta = _consultaService.Obter(4);
			Assert.AreEqual("Retorno", consulta.Descricao);
			Assert.AreEqual(1, consulta.IdAnimal);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var consulta = _consultaService.Obter(3);
			consulta.Descricao = "Verificação da Pata";
			consulta.IdAnimal = 1;
			_consultaService.Editar(consulta);
			consulta = _consultaService.Obter(3);
			Assert.AreEqual("Verificação da Pata", consulta.Descricao);
			Assert.AreEqual(1, consulta.IdAnimal);
		}


		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaConsulta = _consultaService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaConsulta, typeof(IEnumerable<Consulta>));
			Assert.IsNotNull(listaConsulta);
			Assert.AreEqual(3, listaConsulta.Count());
			Assert.AreEqual(1, listaConsulta.First().IdConsulta);
			Assert.AreEqual("Consulta de Rotina", listaConsulta.First().Descricao);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var consulta = _consultaService.Obter(1);
			Assert.IsNotNull(consulta);
			Assert.AreEqual("Consulta de Rotina", consulta.Descricao);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_consultaService.Remover(2);
			// Assert
			Assert.AreEqual(2, _consultaService.ObterTodos().Count());
			var consulta = _consultaService.Obter(2);
			Assert.AreEqual(null, consulta);
		}
	}
}
