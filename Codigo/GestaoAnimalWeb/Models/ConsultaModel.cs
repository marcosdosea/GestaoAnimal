using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace GestaoAnimalWeb.Models
{
    public class ConsultaModel
    {
        public int IdConsulta { get; set; }
        [Required(ErrorMessage = "Descrição não pode estar vazio.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Horário não pode estar vazio.")]
        public TimeSpan Horario { get; set; }
        public DateTime Data { get; set; }

        [Range(0, 5000,
        ErrorMessage = "O valor da consulta deve variar de $0 (grátis) até $5.000,00")]
        public double Preco { get; set; }

        [Display(Name = "Animal")]
        [Required(ErrorMessage = "Selecione um animal.")]
        public int IdAnimal { get; set; }
        [Display(Name = "Dono")]
        [Required(ErrorMessage = "Selecione um dono para o animal.")]
        public int IdPessoa { get; set; }

      
    }
}
