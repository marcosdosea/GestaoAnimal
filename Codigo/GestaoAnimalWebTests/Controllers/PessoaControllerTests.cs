using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Mappers;

namespace Controllers.Tests
{
	[TestClass()]
	public class PessoaControllerTests
	{
		private static PessoaController controller;


		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<IPessoaService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new PessoaProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestPessoas());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetPessoa());
			mockService.Setup(service => service.Editar(It.IsAny<Pessoa>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Pessoa>()))
				.Verifiable();
			controller = new PessoaController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PessoaModel>));
			List<PessoaModel> lista = (List<PessoaModel>)viewResult.ViewData.Model;
			Assert.AreEqual(3, lista.Count);
		}

		[TestMethod()]
		public void DetailsTest()
		{
			// Act
			var result = controller.Details(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
			PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Lys", pessoaModel.Nome);
			Assert.AreEqual(DateTime.Parse("2018-06-06"), pessoaModel.DataNascimento);
		}

		[TestMethod()]
		public void CreateTest()
		{
			// Act
			var result = controller.Create();
			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
		}

		[TestMethod()]
		public void CreateTest_Valid()
		{
			// Act
			var result = controller.Create(GetNewPessoa());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void CreateTest_InValid()
		{
			// Arrange
			controller.ModelState.AddModelError("Nome", "Campo requerido");

			// Act
			var result = controller.Create(GetNewPessoa());

			// Assert
			Assert.AreEqual(1, controller.ModelState.ErrorCount);
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void EditTest_Post()
		{
			// Act
			var result = controller.Edit(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
			PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Lys", pessoaModel.Nome);
			Assert.AreEqual(DateTime.Parse("2018-06-06"), pessoaModel.DataNascimento);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetPessoaModel().IdPessoa, GetTargetPessoaModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void DeleteTest_Post()
		{
			// Act
			var result = controller.Delete(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
			PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
			Assert.AreEqual("Lys", pessoaModel.Nome);
			Assert.AreEqual(DateTime.Parse("2018-06-06"), pessoaModel.DataNascimento);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetPessoaModel().IdPessoa, GetTargetPessoaModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static PessoaModel GetNewPessoa()
		{
			return new PessoaModel
			{
				IdPessoa = 4,
				Nome = "Isabela",
				DataNascimento = DateTime.Parse("2016-03-03")
			};

		}
		private static Pessoa GetTargetPessoa()
		{
			return new Pessoa
			{
				IdPessoa = 1,
				Nome = "Lys",
				DataNascimento = DateTime.Parse("2018-06-06")
			};
		}

		private static PessoaModel GetTargetPessoaModel()
		{
			return new PessoaModel
			{
				IdPessoa = 2,
				Nome = "Lys",
				DataNascimento = DateTime.Parse("2018-06-06")
			};
		}

		private static IEnumerable<Pessoa> GetTestPessoas()
		{
			return new List<Pessoa>
			{
				new Pessoa
				{
					IdPessoa = 1,
					Nome = "Joana",
					DataNascimento = DateTime.Parse("1992-06-06")
				},
				new Pessoa
				{
					IdPessoa = 2,
					Nome = "Lys",
					DataNascimento = DateTime.Parse("2018-06-06")
				},
				new Pessoa
				{
					IdPessoa = 3,
					Nome = "Marcos Dosea",
					DataNascimento = DateTime.Parse("1952-03-03")
				},
			};
		}
	}
}