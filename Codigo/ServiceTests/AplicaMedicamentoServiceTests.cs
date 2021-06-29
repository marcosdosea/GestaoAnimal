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
    public class AplicaMedicamentoServiceTests
    {
        private GestaoAnimalContext context;
        private IAplicaMedicamentoService aplicaMedicamentoService;

        [TestInitialize()]
        public void Initialize()
        {
            var builder = new DbContextOptionsBuilder<GestaoAnimalContext>();
            builder.UseInMemoryDatabase("Gestao Animal");
            var options = builder.Options;

            context = new GestaoAnimalContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var aplicacoesMedicamento = new List<Aplicamedicamento>
            {
                new Aplicamedicamento { 
                    IdAplicaMedicamento = 1, 
                    IdMedicamento = 1, 
                    IdAnimal = 1, 
                    IdPessoa = 1, 
                    DataAplicacao = DateTime.Parse("2020-10-20 15:00:00"), 
                    Dosagem = "12 mg", 
                    Observacoes = "Sem observações." 
                },
                new Aplicamedicamento {
                    IdAplicaMedicamento = 2,
                    IdMedicamento = 3,
                    IdAnimal = 2, 
                    IdPessoa = 1,
                    DataAplicacao = DateTime.Parse("2020-12-17 16:00:00"),
                    Dosagem = "25 mg",
                    Observacoes = "Retornar para clínica em 7 dias."
                },
                new Aplicamedicamento {
                    IdAplicaMedicamento = 3,
                    IdMedicamento = 2,
                    IdAnimal = 2, 
                    IdPessoa = 1,
                    DataAplicacao = DateTime.Parse("2021-03-04 13:00:00"),
                    Dosagem = "200 mg",
                    Observacoes = "Utilizado como medida preventiva."
                },
            };

            var medicamentos = new List<Medicamento>
            {
                new Medicamento {
                    IdMedicamento = 1,
                    Nome = "M1"
                },
                new Medicamento {
                    IdMedicamento = 2,
                    Nome = "M2"
                },
                new Medicamento {
                    IdMedicamento = 3,
                    Nome = "Floral"
                },
            };

            var animais = new List<Animal>
            {
                new Animal
                {
                    IdAnimal = 1,
                    Nome = "Totó"
                },
                new Animal
                {
                    IdAnimal = 2,
                    Nome = "Belinha"
                }
            };

            var pessoas = new List<Pessoa>
            {
                new Pessoa {
                    IdPessoa = 1,
                    Nome = "Joana",
                    DataNascimento =
                    DateTime.Parse("1992-06-06")
                }
            };

            context.AddRange(aplicacoesMedicamento);
            context.AddRange(medicamentos);
            context.AddRange(animais);
            context.AddRange(pessoas);
            context.SaveChanges();

            aplicaMedicamentoService = new AplicaMedicamentoService(context);
        }

        [TestMethod()]
        public void InserirTest()
        {
            aplicaMedicamentoService.Inserir(
                new Aplicamedicamento
                {
                    IdAplicaMedicamento = 4,
                    IdMedicamento = 1,
                    IdAnimal = 2,
                    IdPessoa = 1,
                    DataAplicacao = DateTime.Parse("2021-05-17 09:00:00"),
                    Dosagem = "60 mg",
                    Observacoes = "Sem observações"
                }
            );
            Assert.AreEqual(4, aplicaMedicamentoService.ObterTodos().Count());
            var aplicaMedicamento = aplicaMedicamentoService.Obter(4);
            Assert.AreEqual(2, aplicaMedicamento.IdAnimal);
            Assert.AreEqual("60 mg", aplicaMedicamento.Dosagem);
            Assert.AreEqual(DateTime.Parse("2021-05-17 09:00:00"), aplicaMedicamento.DataAplicacao);
        }

        [TestMethod()]
        public void EditarTest()
        {
            var apMedicamento = aplicaMedicamentoService.Obter(3);
            apMedicamento.IdAnimal = 2;
            apMedicamento.DataAplicacao = DateTime.Parse("2021-05-20 17:00:00");
            aplicaMedicamentoService.Editar(apMedicamento);
            apMedicamento = aplicaMedicamentoService.Obter(3);
            Assert.AreEqual(2, apMedicamento.IdAnimal);
            Assert.AreEqual(DateTime.Parse("2021-05-20 17:00:00"), apMedicamento.DataAplicacao);
        }

        [TestMethod()]
        public void RemoverTest()
        {
            aplicaMedicamentoService.Remover(2);
            Assert.AreEqual(2, aplicaMedicamentoService.ObterTodos().Count());
            var apMedicamento = aplicaMedicamentoService.Obter(2);
            Assert.AreEqual(null, apMedicamento);
        }

        [TestMethod()]
        public void ObterTest()
        {
            var apMedicamento = aplicaMedicamentoService.Obter(1);
            Assert.IsNotNull(apMedicamento);
            Assert.AreEqual(1, apMedicamento.IdAnimal);
        }

        /*
        [TestMethod()]
        public void ObterPorNomeOrdenadoDescendingTest()
        {
            Assert.Fail();
        }
        */

        [TestMethod()]
        public void ObterTodosTest()
        {
            var listaAplicacoes = aplicaMedicamentoService.ObterTodos();
            // Assert
            Assert.IsInstanceOfType(listaAplicacoes, typeof(IEnumerable<AplicamedicamentoDTO>));
            Assert.IsNotNull(listaAplicacoes);
            Assert.AreEqual(3, listaAplicacoes.Count());
            Assert.AreEqual(1, listaAplicacoes.First().IdAplicaMedicamento);
            Assert.AreEqual("12 mg", listaAplicacoes.First().Dosagem);
        }

        /*
        [TestMethod()]
        public void ObterTodosPorNomeTest()
        {
            Assert.Fail();
        }
        */

    }
}