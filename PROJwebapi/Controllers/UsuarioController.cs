using System;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase /* : = significa herança ou extensão, só se usa para isso*/
    {
        //dotnet restore: faz rodar projetos com bibliotecas no github
        private static List<Usuario> usuarios = new List<Usuario>(); //comando para pegar as informaçoes dos usuarios     //static: para armazenar mais de um dado
        //GET: /api/usuario/listar
        [HttpGet] /*método get = devolve os dados que estão pedindo*/
        [Route("listar")] /*Route = da uma rota para o metodo solicitado*/
        public IActionResult /*retorno de uma ação*/ Listar()
        {
            return Ok(usuarios);
        }

        //POST: /api/usuario/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody]Usuario usuario) 
       {
           usuarios.Add(usuario);
           return Created("",usuario); // created: so uma mensagem
       }


         //GET: /api/usuario/buscar
        [HttpGet] 
        [Route("buscar/{email}")] //buscar algo em especifico
        public IActionResult Buscar([FromRoute] string email)//FromRoute = de onde ele vai pegar a informação
        {
            Usuario usuario = usuarios.FirstOrDefault //FirstOrDefault : só retorna o primeiro usuario
            (
                u => u.Email.Equals(email) //Equals= igual    //u = representa o usuário, pode ser qualquer coisa(um a ou b ou u...)
            );
           if(usuario == null) 
           {
               return NotFound();
           }
           return Ok(usuario);
        }
        
    }
}