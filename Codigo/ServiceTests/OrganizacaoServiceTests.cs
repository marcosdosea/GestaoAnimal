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
    public class OrganizacaoServiceTests
    {
		private GestaoAnimalContext _context;
		//GestaoAnimalContext
		private IOrganizacaoService _organizacaoService;

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
			var organizacoes = new List<Organizacao>
			{
				new Organizacao
				{
					IdOrganizacao = 1,
					Cnpj = "49.912.370/0001-94",
					DataAbertura = DateTime.Parse("1963-07-11"),
					Nome = "Universidade Federal de Sergipe",
					Telefone = "793431-2121",
					Endereco = "Avenida Marechal Rondon",
					Email = "ufs@gov.br"
				},
				new Organizacao
				{
					IdOrganizacao = 2,
					Cnpj = "46.581.630/0001-06",
					DataAbertura = DateTime.Parse("2006-05-06"),
					Nome = "Fundação Cães Felizes",
					Telefone = "793431-5489",
					Endereco = "Rua Maria Fonseca",
					Email = "caesfelizes@gov.br"
				},
				new Organizacao
				{
					IdOrganizacao = 3,
					Cnpj = "66.404.554/0001-62",
					DataAbertura = DateTime.Parse("2020-01-04"),
					Nome = "Colégio Estadual Professor José Rodrigues",
					Telefone = "793431-0953",
					Endereco = "Avenida Governador José Rodrigues",
					Email = "colegiojoserodrigues@edu.br"
				}
			};

			_context.AddRange(organizacoes);
			_context.SaveChanges();

			_organizacaoService = new OrganizacaoService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_organizacaoService.Inserir(
				new Organizacao() {
					IdOrganizacao = 4,
					Cnpj = "90.802.770/0001-40",
					DataAbertura = DateTime.Parse("2001-02-12"),
					Nome = "Abrigo de Animais Pôr do Sol",
					Telefone = "793431-6487",
					Endereco = "Rua A",
					Email = "abrigopordosol@gmail.com"
				}
			);
			// Assert
			Assert.AreEqual(4, _organizacaoService.ObterTodos().Count());
			var organizacao = _organizacaoService.Obter(4);
			Assert.AreEqual("Abrigo de Animais Pôr do Sol", organizacao.Nome);
			Assert.AreEqual("90.802.770/0001-40", organizacao.Cnpj);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var organizacao = _organizacaoService.Obter(3);
			organizacao.Nome = "Colégio Estadual Professor José Rodrigues";
			organizacao.Cnpj = "66.404.554/0001-62";
			_organizacaoService.Editar(organizacao);
			organizacao = _organizacaoService.Obter(3);
			Assert.AreEqual("Colégio Estadual Professor José Rodrigues", organizacao.Nome);
			Assert.AreEqual("66.404.554/0001-62", organizacao.Cnpj);
		}


		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaOrganizacao = _organizacaoService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaOrganizacao, typeof(IEnumerable<OrganizacaoDTO>));
			Assert.IsNotNull(listaOrganizacao);
			Assert.AreEqual(3, listaOrganizacao.Count());
			Assert.AreEqual(1, listaOrganizacao.First().IdOrganizacao);
			Assert.AreEqual("Universidade Federal de Sergipe", listaOrganizacao.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var organizacao = _organizacaoService.Obter(1);
			Assert.IsNotNull(organizacao);
			Assert.AreEqual("Universidade Federal de Sergipe", organizacao.Nome);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_organizacaoService.Remover(2);
			// Assert
			Assert.AreEqual(2, _organizacaoService.ObterTodos().Count());
			var organizacao = _organizacaoService.Obter(2);
			Assert.AreEqual(null, organizacao);
		}
	}
}
