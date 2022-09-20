using System;
using System.ComponentModel.DataAnnotations;
using API_Folha.Validations;

//Data Annotations
namespace API.Models
{
    public class Funcionario
    {
        public int Id {get; set;}

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome {get; set;}

        [Required(ErrorMessage = "O campo cpf é obrigatório")]
        [StringLength(
            11,
            MinimumLength = 11,
            ErrorMessage = "O campo cpf deve conter 11 caracters"
            )]
        // [CpfEmUso]
        public string CPF {get; set;}

        public string Nascimento {get ; set;}

        public int CriadoEm {get; set;}
        
        [Range(
            0,
            1000,
            ErrorMessage = "O valor deve estar entre 0.00 e 1.000,00"
        )]
        public double Salario {get; set;}

        [EmailAddress(
            ErrorMessage = "Email inválido"
        )]
        public string Email {get; set;}
        
    }
}