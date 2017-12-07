using LivrariaHBSIS.Models;
using NUnit.Framework;
using System;

namespace LivrariaHBSIS.Tests.Models
{
    [TestFixture]
    class LivroTest
    {
        [Test]
        public void CriaLivro()
        {
            var livro = new Livro();
            livro.Id = Guid.NewGuid();
            livro.Nome = "Nayara";
            livro.Autor = "Paulo";

            livro.Criar();

            var getLivro = Livro.Get(livro.Id);
            Assert.AreEqual(livro.Id, getLivro.Id);
            Assert.AreEqual(livro.Nome, getLivro.Nome);
            Assert.AreEqual(livro.Autor, getLivro.Autor);
        }

        [Test]
        public void AtualizaLivro()
        {
            var getLivros = Livro.Get();
            var livro = getLivros[0];
            livro.Nome = "Novo Nome";

            livro.Update();

            var getLivro = Livro.Get(livro.Id);
            Assert.AreEqual(getLivro.Nome, "Novo Nome");
        }

        [Test]
        public void DeletaLivro()
        {
            var getLivros = Livro.Get();
            var livro = getLivros[0];

            livro.Delete();

            var getLivro = Livro.Get(livro.Id);
            Assert.Null(getLivro);
        }

        [Test]
        public void BuscarLivros()
        {
            var livros = Livro.Get();
            Assert.NotNull(livros);
        }

        [Test]
        public void BuscarLivro()
        {
            var livro = new Livro();
            livro.Nome = "Nayara";
            livro.Autor = "Paulo";

            livro.Criar();

            var getLivro = Livro.Get(livro.Id);
            Assert.AreEqual(livro.Id, getLivro.Id);
            Assert.AreEqual(livro.Nome, getLivro.Nome);
            Assert.AreEqual(livro.Autor, getLivro.Autor);
        }
    }
}
