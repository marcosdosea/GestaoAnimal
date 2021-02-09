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
        IEnumerable<ConsultaDTO> ObterPorDescricao(string nome);
        IEnumerable<ConsultaDTO> ObterTodasConsultas();
        IEnumerable<Consulta> ObterTodos();
        void Remover(int idConsulta);
        //IEnumerable<ConsultaDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
