using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using peekapi.Dao;

namespace peekapi.Dao
{
    public class LaboratorioController : ApiController
    {

        // GET api/<controller>/5
        public string Get(string oque, int idUsuario)
        {
            if (oque == "quantidade")
                if (new UsuarioDAO().UsuarioExiste(idUsuario))
                    return new LaboratorioDAO().QuantidadeDeLaboratorio(idUsuario).ToString();
                else
                    return "USUARIO NÃO EXISTE";

            return "OPÇÃO NÃO ENCONTRADA!";
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