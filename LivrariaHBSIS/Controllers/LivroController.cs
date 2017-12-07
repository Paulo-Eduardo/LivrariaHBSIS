using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
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

        public IHttpActionResult Post(Livro livro)
        {
            try
            {
                livro.Criar();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
