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
	public class MedicamentoControllerTests
	{
		private static MedicamentoController controller;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<IMedicamentoService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new MedicamentoProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestMedicamentos());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetMedicamento());
			mockService.Setup(service => service.Editar(It.IsAny<Medicamento>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Medicamento>()))
				.Verifiable();

			var especieAnimalMockService = new Mock<IEspecieAnimalService>();

			especieAnimalMockService.Setup(service => service.Obter(1)).Returns(GetTargetEspecieAnimal());
			especieAnimalMockService.Setup(service => service.ObterTodos()).Returns(GetTestEspecieAnimais());
			controller = new MedicamentoController(mockService.Object, especieAnimalMockService.Object, mapper);
		}

		[TestMethod("Deve conter 3 itens do index")]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult) result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<MedicamentoDTO>));
			List<MedicamentoDTO> lista = (List<MedicamentoDTO>) viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(MedicamentoModel));
			MedicamentoModel medicamentoModel = (MedicamentoModel) viewResult.ViewData.Model;
			Assert.AreEqual("Raiva", medicamentoModel.Nome);
			Assert.AreEqual(1, medicamentoModel.IdEspecieAnimal);

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
			var result = controller.Create(GetNewMedicamento());

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
			var result = controller.Create(GetNewMedicamento());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(MedicamentoModel));
			MedicamentoModel medicamentoModel = (MedicamentoModel) viewResult.ViewData.Model;
			Assert.AreEqual("Raiva", medicamentoModel.Nome);
			Assert.AreEqual(1, medicamentoModel.IdEspecieAnimal);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetMedicamentoModel().IdMedicamento, GetTargetMedicamentoModel());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(MedicamentoModel));
			MedicamentoModel medicamentoModel = (MedicamentoModel) viewResult.ViewData.Model;
			Assert.AreEqual("Raiva", medicamentoModel.Nome);
			Assert.AreEqual(1, medicamentoModel.IdEspecieAnimal);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetMedicamentoModel().IdMedicamento, GetTargetMedicamentoModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult) result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static MedicamentoModel GetNewMedicamento()
		{
			return new MedicamentoModel
			{
				IdMedicamento = 4,
				Nome = "Vermífugo",
				IdEspecieAnimal = 1
			};

		}

		private static IEnumerable<Especieanimal> GetTestEspecieAnimais()
        {
			return new List<Especieanimal>
			{
				new Especieanimal
				{
					IdEspecieAnimal = 1,
					Nome = "Cachorro"
				},
				new Especieanimal
				{
					IdEspecieAnimal = 2,
					Nome = "Gato"
				},
			};
        }

		private static Especieanimal GetTargetEspecieAnimal()
        {
			return new Especieanimal
			{
				IdEspecieAnimal = 1,
				Nome = "Cachorro"
			};
        }

		private static Medicamento GetTargetMedicamento()
		{
			return new Medicamento
			{
				IdMedicamento = 2,
				Nome = "Raiva",
				IdEspecieAnimal = 1
			};
		}

		private static MedicamentoModel GetTargetMedicamentoModel()
		{
			return new MedicamentoModel
			{
				IdMedicamento = 2,
				Nome = "Raiva",
				IdEspecieAnimal = 1
			};
		}

		private static IEnumerable<MedicamentoDTO> GetTestMedicamentos()
		{
			return new List<MedicamentoDTO>
			{
				new MedicamentoDTO
				{
					IdMedicamento = 1,
					Nome = "Floral",
					IdEspecieAnimal = 1,
					NomeEspecie = "Cachorro"
				},
				new MedicamentoDTO
				{
					IdMedicamento = 2,
					Nome = "Raiva",
					IdEspecieAnimal = 1,
					NomeEspecie = "Cachorro"
				},
				new MedicamentoDTO
				{
					IdMedicamento = 3,
					Nome = "Antipulgas",
					IdEspecieAnimal = 1,
					NomeEspecie = "Cachorro"
				},
			};
		}
	}
}