using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using peekapi.Dao;


namespace peekapi.Controllers
{
    public class ProcessadorController : ApiController
    {

        // GET api/<controller>/5
        public string Get(int idUsuario)
        {
            if (new UsuarioDAO().UsuarioExiste(idUsuario))
            {
                return new ProcessadorDAO().PegarMediaUsoTodosLab(idUsuario).ToString();
            }
          return "";
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