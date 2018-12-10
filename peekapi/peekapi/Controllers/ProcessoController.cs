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
    public class ProcessoController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Processo> Get(int idUsuario, string oque)
        {

            if(new UsuarioDAO().UsuarioExiste(idUsuario))
            {
                if (oque == "usaInternet")
                    return new ProcessoDAO().PegarProcessosQueUsamInternet(idUsuario);
                else if (oque == "labUsando")
                    return new ProcessoDAO().PegarProcessosEmUsoTodosLab(idUsuario);
            }

            return null;
        }

        public string Get(int idComputador, string processo, string oque)
        {

            if (oque != "finalizar")
                return "opcao invalida";

            if (new ProcessoDAO().FinalizarProcesso(processo, idComputador))
                return "o(s) processos serão finalizados em breve";
            else
                return "nenhum processo será finalizado";
            
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