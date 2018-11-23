using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using peekapi.Models;
using peekapi.Dao;

namespace peekapi.Controllers
{
    public class ComputadorController : ApiController
    {
        // GET api/<controller>
     //   public IEnumerable<Computador> Get()
       // {
         //   return new ComputadorDAO().PegarTodosComputadores();
       // }

        public List<Computador> Get(int id, string contexto)
        {
            if (contexto == "todos")
                return new ComputadorDAO().PegarTodosComputadores();

            else if (contexto.ToLower() == "laboratario")
                return new ComputadorDAO().PegarTodosComputadoresByLab(id);

            else if (contexto.ToLower() == "individual")
            {
                List<Computador> l = new List<Computador>();
                l.Add(new ComputadorDAO().PegarComputador(id));
                return l;
            }

            return null;
        }

        public string Get(int idUsuario)
        {
            if(new UsuarioDAO().UsuarioExiste(idUsuario))
                return new ComputadorDAO().PegarQuantidadeDePC(idUsuario).ToString();

            return null;
        }

 
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}