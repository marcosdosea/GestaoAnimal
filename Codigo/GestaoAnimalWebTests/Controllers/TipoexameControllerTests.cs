using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestaoAnimalWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Core;
using AutoMapper;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace GestaoAnimalWeb.Controllers.Tests
{
    [TestClass()]
    public class TipoexameControllerTests
    {
       
		private static TipoexameController controller;


		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			// Arrange
			var mockService = new Mock<ITipoexameService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new TipoexameProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestTipoexames());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetTargetTipoexame());
			mockService.Setup(service => service.Editar(It.IsAny<Tipoexame>()))
				.Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Tipoexame>()))
				.Verifiable();
			controller = new TipoexameController(mockService.Object, mapper);
		}

		[TestMethod()]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<TipoexameModel>));
			List<TipoexameModel> lista = (List<TipoexameModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipoexameModel));
			TipoexameModel tipoexameModel = (TipoexameModel)viewResult.ViewData.Model;
			Assert.AreEqual("Colesterol", tipoexameModel.Tipo);
			//Assert.AreEqual(DateTime.Parse("2018-06-06"), TipoexameModel.DataNascimento);//////OBESRVAÇÃO
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
			var result = controller.Create(GetNewTipoexame());

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
			var result = controller.Create(GetNewTipoexame());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipoexameModel));
			TipoexameModel tipoexameModel = (TipoexameModel)viewResult.ViewData.Model;
			Assert.AreEqual("Colesterol", tipoexameModel.Tipo);
			//Assert.AreEqual(DateTime.Parse("2018-06-06"), pessoaModel.DataNascimento);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetTipoexameModel().IdTipoExame, GetTargetTipoexameModel());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipoexameModel));
			TipoexameModel tipoexameModel = (TipoexameModel)viewResult.ViewData.Model;
			Assert.AreEqual("Colesterol", tipoexameModel.Tipo);
			//Assert.AreEqual(DateTime.Parse("2018-06-06"), pessoaModel.DataNascimento);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetTipoexameModel().IdTipoExame, GetTargetTipoexameModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static TipoexameModel GetNewTipoexame()
		{
			return new TipoexameModel
			{
				IdTipoExame = 4,
				Tipo = "Colesterol",
				
			};

		}
		private static Tipoexame GetTargetTipoexame()
		{
			return new Tipoexame
			{
				IdTipoExame = 1,
				Tipo = "Colesterol",
				
			};
		}

		private static TipoexameModel GetTargetTipoexameModel()
		{
			return new TipoexameModel
			{
				IdTipoExame = 2,
				Tipo = "Colesterol",
				
			};
		}

		private static IEnumerable<Tipoexame> GetTestTipoexames()
		{
			return new List<Tipoexame>
			{
				new Tipoexame
				{
					IdTipoExame = 1,
					Tipo = "Colesterol",
					
				},
				new Tipoexame
				{
					IdTipoExame = 2,
					Tipo = "Colesterol",
					
				},
				new Tipoexame
				{
					IdTipoExame = 3,
					Tipo = "Glicemia",
					
				},
			};
		}
	}
}