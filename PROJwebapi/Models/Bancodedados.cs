using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    //Entity Framework Code First
    //é a classe que define a estrutura do banco de dados
    public class DataContext : DbContext  //traduz pro script sql
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
        //definir quais as classes de modelo servirão para as tabelas no banco de dados
        public DbSet<Funcionario> Funcionarios { get; set; } //criando uma tabela no bd com a classe Funcionario
        //sempre  usar a propriedade DbSet
        
    }
}