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
    public class RedeController : ApiController
    {

        // GET api/<controller>/?idUsuario=xy
        public EnviarVelocidadeDeRede Get(int idUsuario)
        {
            if (new UsuarioDAO().UsuarioExiste(idUsuario))
            {
                EnviarVelocidadeDeRede rede = new EnviarVelocidadeDeRede();
                double[] velocidades = new RedeDAO().SomaDownloadUploadDeTodosOsLaboratorios(idUsuario);
                rede.Download = velocidades[0];
                rede.Upload = velocidades[1];

                return rede;
            }
            else
            {
                return null;
            }
        }

        public List<LabConsumo> Get(int idUsuario, string oque)
        {
            if (!new UsuarioDAO().UsuarioExiste(idUsuario))
                return null;

            if(oque == "consumoPorLab")
                return this.PegarConsumoDosLabs(new RedeDAO().PegarTodosLaboratoriosDeUmUsuario(idUsuario), new RedeDAO().PegarLaboratoriosQueEstaoConsumindoInternet(idUsuario));

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

        private List<LabConsumo> PegarConsumoDosLabs(List<Lab> todosLaboratorios, List<LabConsumo> consumoLaboratorio)
        {
            List<LabConsumo> listRetorno = new List<LabConsumo>();

            foreach (Lab lab in todosLaboratorios)
            {
                LabConsumo labConsumo = new LabConsumo();

                labConsumo.IDdLab = lab.IDdLab;
                labConsumo.Nome = lab.Nome;
                labConsumo.Capacidade = lab.Capacidade;
                labConsumo.Andar = lab.Andar;

                foreach (LabConsumo consu in consumoLaboratorio)
                {
                    if(consu.IDdLab == lab.IDdLab)
                    {
                        labConsumo.Download = consu.Download;
                        labConsumo.Upload = consu.Upload;
                        break;
                    }
                    else
                    {
                        labConsumo.Download = 0;
                        labConsumo.Upload = 0;
                    }
                }


                listRetorno.Add(labConsumo);
            }
            listRetorno.Sort((x,y) => y.Download.CompareTo(x.Download));
            return listRetorno;

        }

    }
}