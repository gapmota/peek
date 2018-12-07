using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using peekapi.Dao;

namespace peekapi.Controllers
{
    public class HdController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public int Get(int idUsuario, int porc, string diretorio)
        {
            if (new UsuarioDAO().UsuarioExiste(idUsuario))
            {
                return new HdDAO().PegarPorcetagemUsoTodosLab(idUsuario, porc, diretorio);
            }
            return 0;
            
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