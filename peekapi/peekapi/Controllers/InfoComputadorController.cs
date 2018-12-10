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
    public class InfoComputadorController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "informe um computador!", "?idComputador=xy" };
        }

        // GET api/<controller>/5
        public InfoComputador Get(int idComputador)
        {
            return this.PegarInfoComputador(idComputador);
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

        private InfoComputador PegarInfoComputador(int idComputador)
        {
            InfoComputador info = new InfoComputador();
            info.Computador = new ComputadorDAO().PegarComputador(idComputador);
            info.Macs = new MacAddressDAO().PegarMacs(idComputador);
            info.Rede = new RedeDAO().PegarRede(idComputador);
            info.Hd = new HdDAO().PegarHD(idComputador);
            info.Processos = new ProcessoDAO().PegarProcessos(idComputador);
            info.MemoriaRam = new MemoriaRamDAO().PegarMemoriaRam(idComputador);
            info.Processador = new ProcessadorDAO().PegarProcessador(idComputador);



            return info;
        }
    }
}