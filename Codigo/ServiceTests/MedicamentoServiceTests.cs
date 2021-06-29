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
    public class MedicamentoServiceTests
    {
        private GestaoAnimalContext context;
        private IMedicamentoService medicamentoService;

        [TestInitialize()]
        public void Initialize()
        {
            var builder = new DbContextOptionsBuilder<GestaoAnimalContext>();
            builder.UseInMemoryDatabase("Gestao Animal");
            var options = builder.Options;

            context = new GestaoAnimalContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var medicamentos = new List<Medicamento>
            {
                new Medicamento {
                    IdMedicamento = 1,
                    Nome = "Floral",
                    IdEspecieAnimal = 1
                },
                new Medicamento {
                    IdMedicamento = 2,
                    Nome = "Raiva",
                    IdEspecieAnimal = 2
                },
                new Medicamento {
                    IdMedicamento = 3,
                    Nome = "Cloril",
                    IdEspecieAnimal = 2
                },
            };

            var especies = new List<Especieanimal>
            {
                new Especieanimal {
                    IdEspecieAnimal = 1,
                    Nome = "Cachorro"
                },
                new Especieanimal {
                    IdEspecieAnimal = 2,
                    Nome = "Gato"
                },
            };

            context.AddRange(medicamentos);
            context.AddRange(especies);
            context.SaveChanges();

            medicamentoService = new MedicamentoService(context);
        }

        [TestMethod()]
        public void InserirTest()
        {
            medicamentoService.Inserir(
                new Medicamento
                {
                    IdMedicamento = 4,
                    Nome = "Remédio para pulgas",
                    IdEspecieAnimal = 1
                }
            );
            Assert.AreEqual(4, medicamentoService.ObterTodos().Count());
            var medicamento = medicamentoService.Obter(4);
            Assert.AreEqual("Remédio para pulgas", medicamento.Nome);
            Assert.AreEqual(1, medicamento.IdEspecieAnimal);
        }

        [TestMethod()]
        public void EditarTest()
        {
            var medicamento = medicamentoService.Obter(3);
            medicamento.Nome = "Vermitech v2";
            medicamento.IdEspecieAnimal = 1;
            medicamentoService.Editar(medicamento);
            medicamento = medicamentoService.Obter(3);
            Assert.AreEqual(1, medicamento.IdEspecieAnimal);
            Assert.AreEqual("Vermitech v2", medicamento.Nome);
        }

        [TestMethod()]
        public void RemoverTest()
        {
            medicamentoService.Remover(2);
            Assert.AreEqual(2, medicamentoService.ObterTodos().Count());
            var medicamento = medicamentoService.Obter(2);
            Assert.AreEqual(null, medicamento);
        }

        [TestMethod()]
        public void ObterTest()
        {
            var medicamento = medicamentoService.Obter(1);
            Assert.IsNotNull(medicamento);
            Assert.AreEqual(1, medicamento.IdMedicamento);
            Assert.AreEqual("Floral", medicamento.Nome);
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
            var listaAplicacoes = medicamentoService.ObterTodos();
            // Assert
            Assert.IsInstanceOfType(listaAplicacoes, typeof(IEnumerable<MedicamentoDTO>));
            Assert.IsNotNull(listaAplicacoes);
            Assert.AreEqual(3, listaAplicacoes.Count());
            Assert.AreEqual(1, listaAplicacoes.First().IdMedicamento);
            Assert.AreEqual("Floral", listaAplicacoes.First().Nome);
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