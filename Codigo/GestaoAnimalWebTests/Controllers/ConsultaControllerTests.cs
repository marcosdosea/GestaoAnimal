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
    public class ConsultaControllerTests
    {
        private static ConsultaController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            // Arrange
            var mockService = new Mock<IConsultaService>();

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new ConsultaProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodasConsultas())
                .Returns(GetTestConsultas());
            mockService.Setup(service => service.Obter(1))
                .Returns(GetTargetConsulta());
            mockService.Setup(service => service.Editar(It.IsAny<Consulta>()))
                .Verifiable();
            mockService.Setup(service => service.Inserir(It.IsAny<Consulta>()))
                .Verifiable();

            //Animal
            var animalMockService = new Mock<IAnimalService>();
            animalMockService.Setup(service => service.Obter(1)).Returns(GetTargetAnimal());
            animalMockService.Setup(service => service.ObterTodos()).Returns(GetTestAnimais());

            //Pessoa
            var pessoaMockService = new Mock<IPessoaService>();
            pessoaMockService.Setup(service => service.Obter(1)).Returns(GetTargetPessoa());
            pessoaMockService.Setup(service => service.ObterTodos()).Returns(GetTestPessoas());

            controller = new ConsultaController(mockService.Object, mapper, animalMockService.Object, pessoaMockService.Object);
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
			ViewResult viewResult = (ViewResult) result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ConsultaDTO>));
			List<ConsultaDTO> lista = (List<ConsultaDTO>) viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ConsultaModel));
            ConsultaModel consultaModel = (ConsultaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Consulta de Rotina", consultaModel.Descricao);
            Assert.AreEqual(1, consultaModel.IdAnimal);
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
            var result = controller.Create(GetNewConsulta());

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
            controller.ModelState.AddModelError("Descricao", "Campo requerido");

            // Act
            var result = controller.Create(GetNewConsulta());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ConsultaModel));
            ConsultaModel consultaModel = (ConsultaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Consulta de Rotina", consultaModel.Descricao);
            Assert.AreEqual(1, consultaModel.IdAnimal);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(GetTargetConsultaModel().IdConsulta, GetTargetConsultaModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ConsultaModel));
            ConsultaModel consultaModel = (ConsultaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Consulta de Rotina", consultaModel.Descricao);
            Assert.AreEqual(1, consultaModel.IdAnimal);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Edit(GetTargetConsultaModel().IdConsulta, GetTargetConsultaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        //Consulta
        private static ConsultaModel GetNewConsulta()
        {
            return new ConsultaModel
            {
                IdConsulta = 4,
                Descricao = "Retorno",
                Data = DateTime.Parse("2022-05-10"),
                Preco = 100,
                IdAnimal = 1,
                IdPessoa = 1
            };

        }

        private static Consulta GetTargetConsulta()
        {
            return new Consulta
            {
                IdConsulta = 1,
                Descricao = "Consulta de Rotina",
                Data = DateTime.Parse("2021-05-10"),
                Preco = 150,
                IdAnimal = 1,
                IdPessoa = 1
            };
        }

        private static ConsultaModel GetTargetConsultaModel()
        {
            return new ConsultaModel
            {
                IdConsulta = 2,
                Descricao = "Exames",
                Data = DateTime.Parse("2021-07-11"),
                Preco = 256,
                IdAnimal = 1,
                IdPessoa = 1
            };
        }

        private static IEnumerable<ConsultaDTO> GetTestConsultas()
        {
            return new List<ConsultaDTO>
            {
                new ConsultaDTO
                {
                    IdConsulta = 1,
                    Descricao = "Consulta de Rotina",
                    Data = DateTime.Parse("2021-05-10"),
                    Preco = 150,
                    IdAnimal = 1,
                    IdPessoa = 1
                },
                new ConsultaDTO
                {
                    IdConsulta = 2,
                    Descricao = "Exames",
                    Data = DateTime.Parse("2021-07-11"),
                    Preco = 256,
                    IdAnimal = 1,
                    IdPessoa = 1
                },
                new ConsultaDTO
                {
                    IdConsulta = 3,
                    Descricao = "Verificação da Pata",
                    Data = DateTime.Parse("2021-02-11"),
                    Preco = 50,
                    IdAnimal = 1,
                    IdPessoa = 1
                },
            };
        }

        //Pessoa
        private static IEnumerable<Pessoa> GetTestPessoas()
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    IdPessoa = 1,
                    Nome = "Márcio Almeida",
                    Email = "marcio33akg@gmail.com",
                    Senha = "111111111",
                    Endereco = "Rua A",
                    Telefone = "79997172718",
                    Cpf = "018.526.548-45",
                    DataNascimento = DateTime.Parse("1979-01-10"),
                    Sexo = "M",
                    TipoPessoa = "F",
                    Cnpj = "",
                    Crmv = ""
                },
                new Pessoa
                {
                    IdPessoa = 2,
                    Nome = "Márcia Almeida",
                    Email = "marcia33akg@gmail.com",
                    Senha = "111111111",
                    Endereco = "Rua V",
                    Telefone = "79997172719",
                    Cpf = "018.526.548-45",
                    DataNascimento = DateTime.Parse("1985-01-10"),
                    Sexo = "F",
                    TipoPessoa = "F",
                    Cnpj = "",
                    Crmv = ""
                },
            };
        }
        private static Pessoa GetTargetPessoa()
        {
            return new Pessoa
            {
                IdPessoa = 1,
                Nome = "Márcio Almeida",
                Email = "marcio33akg@gmail.com",
                Senha = "111111111",
                Endereco = "Rua A",
                Telefone = "79997172718",
                Cpf = "018.526.548-45",
                DataNascimento = DateTime.Parse("1979-01-10"),
                Sexo = "M",
                TipoPessoa = "F",
                Cnpj = "",
                Crmv = ""
            };
        }

        //Animal
        private static IEnumerable<Animal> GetTestAnimais()
        {
            return new List<Animal>
            {
                new Animal
                {
                    IdAnimal = 1,
                    Nome = "Bob",
                    IdEspecieAnimal = 1,
                    Raca = "Pit-Bull",
                    DataNascimento = DateTime.Parse("2018-05-10"),
                    Sexo = "M",
                    Peso = 20,
                    Status = "Ativo",
                    Castrado = 1,
                    Falecido = 0,
                    IdPessoa = 1,
                    IdOrganizacao = 1,
                    IdLote = 1
                },
                new Animal
                {
                    IdAnimal = 2,
                    Nome = "Jack",
                    IdEspecieAnimal = 1,
                    Raca = "Vira-Lata",
                    DataNascimento = DateTime.Parse("2019-01-10"),
                    Sexo = "M",
                    Peso = 18,
                    Status = "Ativo",
                    Castrado = 1,
                    Falecido = 0,
                    IdPessoa = 1,
                    IdOrganizacao = 1,
                    IdLote = 1
                },
            };
        }
        private static Animal GetTargetAnimal()
        {
            return new Animal
            {
                IdAnimal = 1,
                Nome = "Bob",
                IdEspecieAnimal = 1,
                Raca = "Pit-Bull",
                DataNascimento = DateTime.Parse("2018-05-10"),
                Sexo = "M",
                Peso = 20,
                Status = "Ativo",
                Castrado = 1,
                Falecido = 0,
                IdPessoa = 1,
                IdOrganizacao = 1,
                IdLote = 1
            };
        }
    }
}