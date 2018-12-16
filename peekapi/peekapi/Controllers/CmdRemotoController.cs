using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using peekapi.Dao;
using peekapi.Models;

namespace peekapi.Controllers
{
    public class CmdRemotoController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public List<CmdRemoto> Get(int idComputador, string comando, string oque)
        {
            if (oque == "inserir")
                return new CmdRemotoDAO().InserirComandoCMD(idComputador, comando);
            else if (oque == "apagar")
            {
                new CmdRemotoDAO().LimparComandoCMD(idComputador);
                return null;
            }
            else if (oque == "historico")
            {
                return new CmdRemotoDAO().TodosRetornos(new CmdRemotoDAO().PegarIdComandoCmd(idComputador));
            }

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