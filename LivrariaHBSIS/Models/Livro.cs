using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace LivrariaHBSIS.Models
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }

        public static List<Livro> Get()
        {
            using (IDbConnection db = new MySqlConnection("Database=Livraria;Data Source=localhost;User Id=root;"))
            {
                return db.Query<Livro>("Select * From Livro").ToList();
            }
        }

        public void Criar()
        {
            using (IDbConnection db = new MySqlConnection("Database=Livraria;Data Source=localhost;User Id=root;"))
            {
                db.Execute("Insert into Livro values(@id, @nome, @autor)", new { id = Id.ToString(), nome = Nome, autor = Autor });
            }
        }

        public void Update()
        {
            using (IDbConnection db = new MySqlConnection("Database=Livraria;Data Source=localhost;User Id=root;"))
            {
                db.Execute("update Livro set Nome = @nome, Autor =  @autor where Id = @id", new { id = Id.ToString(), nome = Nome, autor = Autor });
            }
        }

        public void Delete()
        {
            using (IDbConnection db = new MySqlConnection("Database=Livraria;Data Source=localhost;User Id=root;"))
            {
                db.Execute("delete from Livro where Id = @id", new { id = Id.ToString() });
            }
        }

        public static Livro Get(Guid guid)
        {
            using (IDbConnection db = new MySqlConnection("Database=Livraria;Data Source=localhost;User Id=root;"))
            {
                return db.QueryFirstOrDefault<Livro>("Select * From Livro where Id = @LivroId", new { LivroId = guid });
            }
        }
    }


}