using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft;
using Newtonsoft.Json;
using peekapi.Models;

namespace peekapi.controller
{
    public class ToJSON
    {
        public string getUsuarioToJson()
        {
            List<Usuario> l = new EntidadeUsuario().getUsuarios();

           
            return JsonConvert.SerializeObject(l);
        }

        public List<Usuario> JsonToListUsuario(string json)
        {
            JsonConvert.DeserializeObject(json);

            List<Usuario> list = JsonConvert.DeserializeObject<List<Usuario>>(json);
            
            return list;
        }

    }
}