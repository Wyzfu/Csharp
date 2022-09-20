/*Criar um projeto WebAPI para a Folha de Pagamento
Realizar todas as operações de CRUD para um funcionário
Um funcionário deverá ter nome, cpf, data de nascimento e criado em.*/

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; /*para usar o list*/
using API.Models; /*para puxar os models*/

namespace API.Controllers
{
    [ApiController]
    [Route("api/funcionario")]
    
    public class FuncionarioController : ControllerBase
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();
        private DataContext _context;

        public FuncionarioController(DataContext context)
        {
            _context = context;
        }

        //cadastro
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody]Funcionario funcionario) 
        {
           _context.Funcionarios.Add(funcionario);
           _context.SaveChanges(); //salva as informaçoes no bd
           return Created("",funcionario);
        }

        //listar
        [HttpGet] 
        [Route("listar")] 
        public IActionResult Listar()
        {
            return Ok(_context.Funcionarios.ToList());
        }

        //buscar
        [HttpGet]
        [Route("buscar/{cpf}")]

        public IActionResult Buscar([FromRoute] string cpf)
        {
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault
            (
                 f => f.CPF.Equals(cpf)
            );
            //  if (funcionario == null)
            // {
            //     return NotFound();
            // }
            return funcionario != null ? Ok(funcionario) : NotFound();
        }

        //deletar
        [HttpDelete]
        [Route("deletar/{cpf}")]

        public IActionResult Deletar([FromRoute] int id)
        {
            Funcionario funcionario = _context.Funcionarios.Find(id); //quando se meche com primary key é melhor usar o find
            if(funcionario != null)/*se n encontrar funcionario*/
            {
               _context.Funcionarios.Remove(funcionario); /*deleta o obj*/
               _context.SaveChanges();
               return Ok(funcionario); 
            }
            return NotFound();
        }

        /*alterar*/
        [HttpPatch]
        [Route("alterar")]

        public IActionResult Alterar([FromBody]Funcionario funcionario)/*chama o cpf no corpo e não na url*/
        {
            _context.Funcionarios.Update(funcionario);
            _context.SaveChanges();
            return Ok(funcionario);
        }
        
        


        
    }

}