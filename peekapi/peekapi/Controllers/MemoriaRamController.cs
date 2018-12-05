using peekapi.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace peekapi.Controllers
{
    public class MemoriaRamController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int idUsuario)
        {
            if (new UsuarioDAO().UsuarioExiste(idUsuario))
            {
                return new MemoriaRamDAO().PegarMediaUsoTodosLab(idUsuario).ToString();
            }
            return "0";
            
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