using System;
using System.Web.Http;
using LivrariaHBSIS.Models;

namespace LivrariaHBSIS.Controllers
{
    public class LivroController : ApiController
    {
        public Livro[] Get()
        {
            var livros = Livro.Get().ToArray();
            return livros;
        }

        public Livro Post(Livro livro)
        {
            livro.Criar();
            return livro;
        }

        public IHttpActionResult Put(Livro livro)
        {
            try
            {
                livro.Update();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        public IHttpActionResult Delete(Livro livro)
        {
            try
            {
                livro.Delete();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
