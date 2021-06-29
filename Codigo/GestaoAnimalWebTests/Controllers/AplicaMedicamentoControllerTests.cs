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
	public class AplicaMedicamentoControllerTests
	{
		private static AplicaMedicamentoController controller;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<IAplicaMedicamentoService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new AplicaMedicamentoProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestAplicaMedicamento());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetAplicaMedicamento());
			mockService.Setup(service => service.Editar(It.IsAny<Aplicamedicamento>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Aplicamedicamento>()))
				.Verifiable();
			mockService.Setup(service => service.Remover(It.IsAny<int>()))
				.Verifiable();

			var medicamentoMockService = new Mock<IMedicamentoService>();
			medicamentoMockService.Setup(service => service.Obter(1))
				.Returns(GetTargetMedicamento());
			var animalMockService = new Mock<IAnimalService>();
			animalMockService.Setup(service => service.Obter(1))
				.Returns(GetTargetAnimal());
			var pessoaMockService = new Mock<IPessoaService>();
			pessoaMockService.Setup(service => service.Obter(1))
				.Returns(GetTargetPessoa());

			controller = new AplicaMedicamentoController(
				mockService.Object, 
				medicamentoMockService.Object, 
				animalMockService.Object, 
				pessoaMockService.Object, 
				mapper
				);
		}

		private static Medicamento GetTargetMedicamento()
        {
			return new Medicamento
			{
				IdMedicamento = 1,
				Nome = "Floral",
				IdEspecieAnimal = 1
			};

		}

		private static Animal GetTargetAnimal()
		{
			return new Animal
			{
				IdAnimal = 1,
				Nome = "Totó",
			};

		}

		private static Pessoa GetTargetPessoa()
        {
			return new Pessoa
			{
				IdPessoa = 1,
				Nome = "Rafaela"
			};
        }

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult) result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AplicamedicamentoDTO>));
			List<AplicamedicamentoDTO> lista = (List<AplicamedicamentoDTO>) viewResult.ViewData.Model;
			Assert.AreEqual(3, lista.Count);
		}

		[TestMethod()]
		public void DetailsTest()
		{
			// Act
			var result = controller.Details(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult) result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AplicaMedicamentoModel));
			AplicaMedicamentoModel aplicaMedicamentoModel = (AplicaMedicamentoModel) viewResult.ViewData.Model;
			Assert.AreEqual("12 mg", aplicaMedicamentoModel.Dosagem);
			Assert.AreEqual(1, aplicaMedicamentoModel.IdAnimal);
			Assert.AreEqual(1, aplicaMedicamentoModel.IdMedicamento);
			Assert.AreEqual(1, aplicaMedicamentoModel.IdPessoa);
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
			var result = controller.Create(GetNewAplicaMedicamento());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult) result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void CreateTest_InValid()
		{
			// Arrange
			controller.ModelState.AddModelError("Nome", "Campo requerido");

			// Act
			var result = controller.Create(GetNewAplicaMedicamento());

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
			ViewResult viewResult = (ViewResult) result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AplicaMedicamentoModel));
			AplicaMedicamentoModel aplicaMedicamentoModel = (AplicaMedicamentoModel) viewResult.ViewData.Model;
			Assert.AreEqual("12 mg", aplicaMedicamentoModel.Dosagem);
			Assert.AreEqual(1, aplicaMedicamentoModel.IdAnimal);
			Assert.AreEqual(1, aplicaMedicamentoModel.IdMedicamento);
			Assert.AreEqual(1, aplicaMedicamentoModel.IdPessoa);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetAplicaMedicamentoModel().IdAplicaMedicamento, GetTargetAplicaMedicamentoModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult) result;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AplicaMedicamentoModel));
			AplicaMedicamentoModel aplicaMedicamentoModel = (AplicaMedicamentoModel) viewResult.ViewData.Model;
			Assert.AreEqual("12 mg", aplicaMedicamentoModel.Dosagem);
			Assert.AreEqual(1, aplicaMedicamentoModel.IdAnimal);
			Assert.AreEqual(1, aplicaMedicamentoModel.IdMedicamento);
			Assert.AreEqual(1, aplicaMedicamentoModel.IdPessoa);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetAplicaMedicamentoModel().IdMedicamento, GetTargetAplicaMedicamentoModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult) result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static AplicaMedicamentoModel GetNewAplicaMedicamento()
		{
			return new AplicaMedicamentoModel
			{
				IdAplicaMedicamento = 4,
				IdAnimal = 1,
				IdMedicamento = 1,
				IdPessoa = 1,
				DataAplicacao = DateTime.Parse("2020-10-25 17:00:00"),
				Dosagem = "12 mg",
			};

		}

		private static Aplicamedicamento GetTargetAplicaMedicamento()
		{	
			return new Aplicamedicamento
			{
				IdAplicaMedicamento = 1,
				IdAnimal = 1,
				IdMedicamento = 1,
				IdPessoa = 1,
				DataAplicacao = DateTime.Parse("2018-06-06 06:00:00"),
				Dosagem = "12 mg",
			};
		}

		private static AplicaMedicamentoModel GetTargetAplicaMedicamentoModel()
		{
			return new AplicaMedicamentoModel
			{
				IdAplicaMedicamento = 1,
				IdAnimal = 1,
				IdMedicamento = 1,
				IdPessoa = 1,
				DataAplicacao = DateTime.Parse("2018-06-06 06:00:00"),
				Dosagem = "12 mg",
			};
		}

		private static IEnumerable<AplicamedicamentoDTO> GetTestAplicaMedicamento()
		{
			return new List<AplicamedicamentoDTO>
			{
				new AplicamedicamentoDTO
				{
					IdAplicaMedicamento = 1,
					NomeMedicamento = "Floral",
					NomeAnimal = "Totó",
					DataAplicacao = DateTime.Parse("2018-06-06 06:00:00"),
					Dosagem = "12 mg",
					NomePessoa = "Rafaela"
				},
				new AplicamedicamentoDTO
				{
					IdAplicaMedicamento = 2,
					NomeMedicamento = "Floral",
					NomeAnimal = "Totó",
					DataAplicacao = DateTime.Parse("2019-07-05 13:00:00"),
					Dosagem = "12 mg",
					NomePessoa = "Rafaela"
				},
				new AplicamedicamentoDTO
				{
					IdAplicaMedicamento = 3,
					NomeMedicamento = "Floral",
					NomeAnimal = "Totó",
					DataAplicacao = DateTime.Parse("2020-10-20 18:00:00"),
					Dosagem = "12 mg",
					NomePessoa = "Rafaela"
				},
			};
		}
	}
}