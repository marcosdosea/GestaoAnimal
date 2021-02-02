using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IAnimalService
    {
        void Editar(Animal animal);
        int Inserir(Animal animal);
        Animal Obter(int idAnimal);
        IEnumerable<AnimalDTO> ObterTodosAnimais();
        IEnumerable<Animal> ObterTodos();
        void Remover(int idAnimal);
        IEnumerable<AnimalDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
