using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ObterStringConexao());
            base.OnConfiguring(optionsBuilder);
        }

        //Aqui estamos setando para cada classe o nome da tabela no banco de dados
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet<SistemaFinanceiro> SistemaFinanceiro { get; set; }
        public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiro { get; set; }

        //Essa função é necessária para que o Identity funcione corretamente
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Aqui estamos configurando para ele conseguir mapear qual o id da tabela "AspNetUsers" para a tabela ApplicationUser
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        public String ObterStringConexao()
        {
            return "Server=localhost;Database=Financeiro;User Id=SA;Password=root;MultipleActiveResultSets=true";

            //String de conexão via windows authentication
            //return "Server=localhost;Database=Financeiro;Trusted_Connection=True;MultipleActiveResultSets=true";
        }


    }
}
