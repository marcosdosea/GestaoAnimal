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
using GestaoAnimalWeb.Controllers;
using GestaoAnimalWeb.Mappers;
using GestaoAnimalWeb.Models;

namespace Controllers.Tests
{
    [TestClass()]
    public class OrganizacaoControllerTests
    {
        private static OrganizacaoController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IOrganizacaoService>();

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new OrganizacaoProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos())
                .Returns(GetTestOrganizacoes());
            mockService.Setup(service => service.Obter(1))
                .Returns(GetTargetOrganizacao());
            mockService.Setup(service => service.Editar(It.IsAny<Organizacao>()))
                .Verifiable();
            mockService.Setup(service => service.Inserir(It.IsAny<Organizacao>()))
                .Verifiable();
            controller = new OrganizacaoController(mockService.Object, mapper);
        }

        [TestMethod()]
        [TestCategory("Unit")]
        [Description("Testando o Index")]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<OrganizacaoDTO>));
            List<OrganizacaoDTO> list = (List<OrganizacaoDTO>)viewResult.ViewData.Model;
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(OrganizacaoModel));
            OrganizacaoModel organizacaoModel = (OrganizacaoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Universidade Federal de Sergipe", organizacaoModel.Nome);
            Assert.AreEqual("49.912.370/0001-94", organizacaoModel.Cnpj);
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
            var result = controller.Create(GetNewOrganizacao());

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
            var result = controller.Create(GetNewOrganizacao());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(OrganizacaoModel));
            OrganizacaoModel organizacaoModel = (OrganizacaoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Universidade Federal de Sergipe", organizacaoModel.Nome);
            Assert.AreEqual("49.912.370/0001-94", organizacaoModel.Cnpj);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(GetTargetOrganizacaoModel().IdOrganizacao, GetTargetOrganizacaoModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(OrganizacaoModel));
            OrganizacaoModel organizacaoModel = (OrganizacaoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Universidade Federal de Sergipe", organizacaoModel.Nome);
            Assert.AreEqual("49.912.370/0001-94", organizacaoModel.Cnpj);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Edit(GetTargetOrganizacaoModel().IdOrganizacao, GetTargetOrganizacaoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static OrganizacaoModel GetNewOrganizacao()
        {
            return new OrganizacaoModel
            {
                IdOrganizacao = 4,
                Cnpj = "90.802.770/0001-40",
                DataAbertura = DateTime.Parse("2001-02-12"),
                Nome = "Abrigo de Animais Pôr do Sol",
                Telefone = "793431-6487",
                Endereco = "Rua A",
                Email = "abrigopordosol@gmail.com"
            };

        }

        private static Organizacao GetTargetOrganizacao()
        {
            return new Organizacao
            {
                IdOrganizacao = 1,
                Cnpj = "49.912.370/0001-94",
                DataAbertura = DateTime.Parse("1963-07-11"),
                Nome = "Universidade Federal de Sergipe",
                Telefone = "793431-2121",
                Endereco = "Avenida Marechal Rondon",
                Email = "ufs@gov.br"
            };
        }

        private static OrganizacaoModel GetTargetOrganizacaoModel()
        {
            return new OrganizacaoModel
            {
                IdOrganizacao = 2,
                Cnpj = "49.912.370/0001-94",
                DataAbertura = DateTime.Parse("1963-07-11"),
                Nome = "Universidade Federal de Sergipe",
                Telefone = "793431-2121",
                Endereco = "Avenida Marechal Rondon",
                Email = "ufs@gov.br"
            };
        }

        private static IEnumerable<OrganizacaoDTO> GetTestOrganizacoes()
        {
            return new List<OrganizacaoDTO>
            {
                new OrganizacaoDTO
                {
                    IdOrganizacao = 1,
                    Cnpj = "49.912.370/0001-94",
                    DataAbertura = DateTime.Parse("1963-07-11"),
                    Nome = "Universidade Federal de Sergipe",
                    Telefone = "793431-2121",
                    Endereco = "Avenida Marechal Rondon",
                    Email = "ufs@gov.br"
                },
                new OrganizacaoDTO
                {
                    IdOrganizacao = 2,
                    Cnpj = "46.581.630/0001-06",
                    DataAbertura = DateTime.Parse("2006-05-06"),
                    Nome = "Fundação Cães Felizes",
                    Telefone = "793431-5489",
                    Endereco = "Rua Maria Fonseca",
                    Email = "caesfelizes@gov.br"
                },
                new OrganizacaoDTO
                {
                    IdOrganizacao = 3,
                    Cnpj = "66.404.554/0001-62",
                    DataAbertura = DateTime.Parse("2020-01-04"),
                    Nome = "Colégio Estadual Professor José Rodrigues",
                    Telefone = "793431-0953",
                    Endereco = "Avenida Governador José Rodrigues",
                    Email = "colegiojoserodrigues@edu.br"
                },
            };
        }
    }
}