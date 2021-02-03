using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IConsultaService
    {
        void Editar(Consulta consulta);
        int Inserir(Consulta consulta);
        Consulta Obter(int idConsulta);
        IEnumerable<Consulta> ObterPorDescricao(string nome);
        IEnumerable<Consulta> ObterTodos();
        IEnumerable<ConsultaDTO> ObterTodasConsultas();
        void Remover(int idConsulta);
        //IEnumerable<ConsultaDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
