using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IExameService
    {
        void Editar(Exame exame);
        int Inserir(Exame exame);
        Exame Obter(int idExame);
        IEnumerable<ExameDTO> ObterTodosPorNome(string nome);
        IEnumerable<Exame> ObterTodos();
        void Remover(int idExame);
        IEnumerable<ExameDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
