using System.ComponentModel.DataAnnotations;
using API.Models;


namespace API_Folha.Validations
{
    public class CpfEmUso : ValidationAttribute
    {
        // public CpfEmUso(string cpf)
        // { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string CPF =(string) value;

            DataContext context = 
            (DataContext)validationContext.GetService(typeof(DataContext));

            Funcionario funcionario = context.Funcionarios.FirstOrDefault
            (f => f.cpf.Equals(CPF));

            if(CPF.Equals("12345678910"))
            {
                //Caso de erro
                return new ValidationResult("O CPF do funcionário já está em uso");
            }
            //Caso de sucesso
            return ValidationResult.Success;
        }
    }
}