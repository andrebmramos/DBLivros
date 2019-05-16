// Exemplo didático, Entity Framework Core 2.2 -- 15/05/2019

using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace DBLivros
{
    public class Program
    {

        public static IServiceProvider Container { get; private set; }
        public const string ConnectionString = @"server=.\SQLEXPRESS;database=LivrosDB;User Id=sa; Password=123456;";


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RegisterServices();
            var context = Container.GetService<LivroContext>();
            ExemploMostrarCategoria(context, "Mais Vendidos"); // Obs.: Não é case sensitive!
        }


        private static void ExemploMostrarCategoria(LivroContext context, string categoria = "Ficção")
        {
            var query = from b in context.Livros
                        join a in context.Autores on b.AutorId equals a.AutorId 
                        join lc in context.LivroCategorias on b.LivroId equals lc.LivroId
                        join c in context.Categorias on lc.CategoriaId equals c.CategoriaId
                        where c.Descricao == categoria 
                        select new { Categoria = c.Descricao, Livro = b.Nome, Autor = a.Nome };

            Console.WriteLine($">>>> Mostrando itens localizados na categoria {categoria}");
            foreach (var item in query)
                Console.WriteLine($">> Categoria = {item.Categoria}, Livro = {item.Livro}, Autor = {item.Autor}");
        }


       
        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<LivroContext>(options => options.UseSqlServer(ConnectionString));
            services.AddLogging(loggingBuilder => loggingBuilder.AddConsole());
            // services.AddDbContext<PaymentContext>(options => options.UseLazyLoadingProxies());
            Container = services.BuildServiceProvider();
        }

    }

}
